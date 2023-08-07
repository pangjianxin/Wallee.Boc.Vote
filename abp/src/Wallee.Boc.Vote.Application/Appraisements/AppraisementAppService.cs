using AutoFilterer.Extensions;
using RulesEngine.Extensions;
using RulesEngine.Models;
using SkiaSharp;
using SkiaSharp.QrCode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.BlobStoring;
using Volo.Abp.Content;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Json;
using Volo.Abp.Settings;
using Wallee.Boc.Vote.Blobs;
using Wallee.Boc.Vote.RulesEngines;
using Wallee.Boc.Vote.Settings;

namespace Wallee.Boc.Vote.Appraisements
{
    public class AppraisementAppService :
        CrudAppService<Appraisement, AppraisementDto, Guid, GetAppraisementsInputDto, AppraisementCreateDto, AppraisementUpdateDto>,
        IAppraisementAppService, ITransientDependency
    {
        private readonly IBlobContainer<QrcodeBgImgContainer> _bgImgContainer;
        private readonly IBlobContainer<QrcodeBgImgFontContainer> _bgImgFontContainer;
        private readonly ISettingProvider _settingProvider;
        private readonly IRulesEngineProvider _rulesEngineProvider;
        private readonly IJsonSerializer _jsonSerializer;
        public readonly IAppraisementRepository _appraisementRepository;
        public AppraisementAppService(
            IAppraisementRepository appraisementRepository,
            IBlobContainer<QrcodeBgImgContainer> bgImgContainer,
            IBlobContainer<QrcodeBgImgFontContainer> bgImgFontContainer,
            ISettingProvider settingProvider,
            IRulesEngineProvider rulesEngineProvider,
            IJsonSerializer jsonSerializer) : base(appraisementRepository)
        {
            _appraisementRepository = appraisementRepository;
            _bgImgContainer = bgImgContainer;
            _bgImgFontContainer = bgImgFontContainer;
            _settingProvider = settingProvider;
            _rulesEngineProvider = rulesEngineProvider;
            _jsonSerializer = jsonSerializer;
        }



        public async override Task<AppraisementDto> CreateAsync(AppraisementCreateDto input)
        {
            var appraisement = new Appraisement(GuidGenerator.Create(),
                input.Name,
                input.Description,
                input.Category,
                input.Start,
                input.End);

            await _appraisementRepository.InsertAsync(appraisement);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<Appraisement, AppraisementDto>(appraisement);

        }

        public async Task<string[]> GetRuleNamesAsync()
        {
            var workflow = await _rulesEngineProvider.GetWorkflow(BlobConsts.AppraisementRuleNames);

            var workflows = _jsonSerializer.Deserialize<List<Workflow>>(workflow);

            var rulesEngine = new RulesEngine.RulesEngine(workflows.ToArray());

            var results = await rulesEngine.ExecuteAllRulesAsync(BlobConsts.AppraisementRuleNames, new object[] { });

            var evaResult = Array.Empty<string>();

            results.OnSuccess(successEvent =>
            {
                var successResult = results.First(it => it.Rule.SuccessEvent == successEvent).ActionResult.Output;
                evaResult = successResult as string[];
            });

            return evaResult;
        }

        /// <summary>
        /// 获取所有目前可用的活动
        /// </summary>
        /// <returns></returns>
        public async Task<List<AppraisementDto>> GetAllAvailableAsync()
        {
            var list = (await _appraisementRepository.GetQueryableAsync()).Where(it => it.End >= Clock.Now);

            var result = await AsyncExecuter.ToListAsync(list);

            return ObjectMapper.Map<List<Appraisement>, List<AppraisementDto>>(result);
        }


        public async override Task<AppraisementDto> UpdateAsync(Guid id, AppraisementUpdateDto input)
        {
            var appraisement = await _appraisementRepository.GetAsync(id);
            appraisement.ConcurrencyStamp = input.ConcurrencyStamp;
            appraisement.SetName(input.Name);
            appraisement.SetDescription(input.Description);
            appraisement.SetStart(input.Start);
            appraisement.SetEnd(input.End);
            appraisement.SetCategory(input.Category);
            await _appraisementRepository.UpdateAsync(appraisement);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<Appraisement, AppraisementDto>(appraisement);
        }

        public async Task<IRemoteStreamContent> GetDownloadAppraisementQrcode(GetAppraisementQrcodeDto input)
        {
            var urlTemplate = string.Format(await _settingProvider.GetOrNullAsync(VoteSettings.AppraisementQrcodeUrl), input.AppraisementId, input.RuleName);

            using var bgStream = await _bgImgContainer.GetAsync(AppraisementConsts.QrcodeBgImgBlobName);
            using var qrcodeStream = GenerateQrcodeAsync(urlTemplate);
            SKBitmap backgroundBitmap = SKBitmap.Decode(bgStream);
            // 加载二维码图片
            SKBitmap qrCodeBitmap = SKBitmap.Decode(qrcodeStream);
            //用于装载合并后的图片
            var stream = new MemoryStream();
            //创建一个新的画布对象
            using (SKSurface surface = SKSurface.Create(new SKImageInfo(backgroundBitmap.Width, backgroundBitmap.Height)))
            {
                // 获取画布对象
                SKCanvas canvas = surface.Canvas;
                // 绘制背景图片
                canvas.DrawBitmap(backgroundBitmap, new SKPoint(0, 0));
                // 在背景图片上绘制二维码图片
                canvas.DrawBitmap(qrCodeBitmap, new SKPoint(198, 558));
                //书写标题
                await DrawSingleLineText(canvas, $"{input.RuleName}评价入口", 115, 245, 436, 52);

                // 保存绘制结果
                using (SKImage image = surface.Snapshot())
                {
                    // 将绘制结果保存到文件
                    using (SKData data = image.Encode())
                    {
                        data.SaveTo(stream);
                    }
                }
                stream.Seek(0, SeekOrigin.Begin);
                return new RemoteStreamContent(stream, "xxx.png", "image/png");
            }

        }

        protected override async Task<IQueryable<Appraisement>> CreateFilteredQueryAsync(GetAppraisementsInputDto input)
        {
            return (await base.CreateFilteredQueryAsync(input)).ApplyFilter(input);
        }

        public async Task UploadQrcodeBgImgAsync(UploadQrcodeBgImgDto input)
        {
            using (var stream = input.File.GetStream())
            {
                await _bgImgContainer.SaveAsync(AppraisementConsts.QrcodeBgImgBlobName, stream, overrideExisting: true);
            }
        }

        public async Task UploadQrcdoeBgImgFontAsync(UploadQrcodeBgImgFontDto input)
        {
            using (var stream = input.File.GetStream())
            {
                await _bgImgFontContainer.SaveAsync(AppraisementConsts.QrcodeBgImgFontBlobName, stream, overrideExisting: true);
            }
        }

        private async Task DrawSingleLineText(SKCanvas canvas, string text, float x, float y, float recWidth, float recHeight)
        {
            //定义画笔
            using (var paint = new SKPaint()
            {
                Color = SKColor.Parse("b43837"),
                TextSize = 32,
                IsAntialias = true,
                TextAlign = SKTextAlign.Center,
                Typeface = SKTypeface.FromStream(await _bgImgFontContainer.GetAsync(AppraisementConsts.QrcodeBgImgFontBlobName))
            })
            {
                //定义一个矩形，此矩形为计算文字区域的结果
                var tRect = new SKRect(x, y, x + recWidth, y + recHeight);

                //计算文字占用区域
                paint.MeasureText(text, ref tRect);

                float textX = x + recWidth / 2;

                float textY = y + recHeight / 2 + paint.TextSize / 2;

                canvas.DrawText(text, textX, textY, paint);
            }
        }

        private MemoryStream GenerateQrcodeAsync(string content)
        {
            using var qrCodeGenerator = new QRCodeGenerator();
            // Generate QrCode
            var qr = qrCodeGenerator.CreateQrCode(content, ECCLevel.L);
            // Render to canvas
            var qrImageInfo = new SKImageInfo(265, 265);
            using var qrSurface = SKSurface.Create(qrImageInfo);
            var qrCanvas = qrSurface.Canvas;
            qrCanvas.Render(qr, qrImageInfo.Width, qrImageInfo.Height);
            // Output to Stream -> File
            var stream = new MemoryStream();
            using (var image = qrSurface.Snapshot())
            using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
            {
                data.SaveTo(stream);
            }
            stream.Seek(0, SeekOrigin.Begin);
            return stream;
        }
    }
}
