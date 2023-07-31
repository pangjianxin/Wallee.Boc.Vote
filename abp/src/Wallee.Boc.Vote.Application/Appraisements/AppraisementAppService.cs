using AutoFilterer.Extensions;
using SkiaSharp.QrCode;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.BlobStoring;
using Volo.Abp.Content;
using Volo.Abp.DependencyInjection;
using Wallee.Boc.Vote.Blobs;

namespace Wallee.Boc.Vote.Appraisements
{
    public class AppraisementAppService :
        CrudAppService<Appraisement, AppraisementDto, Guid, GetAppraisementsInputDto, AppraisementCreateDto, AppraisementUpdateDto>,
        IAppraisementAppService, ITransientDependency
    {
        private readonly IBlobContainer<QrcodeBackgroundImageContainer> _blobContainer;
        public readonly IAppraisementRepository _appraisementRepository;
        public AppraisementAppService(
            IAppraisementRepository appraisementRepository,
            IBlobContainer<QrcodeBackgroundImageContainer> blobContainer) : base(appraisementRepository)
        {
            _appraisementRepository = appraisementRepository;
            _blobContainer = blobContainer;
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
            // 加载二维码图片
            SKBitmap backgroundBitmap = SKBitmap.Decode(await _blobContainer.GetAsync(AppraisementQrcodeConsts.QrcodeBackgroundImageBlobName));
            SKBitmap qrCodeBitmap = SKBitmap.Decode(GenerateQrcodeAsync("http://baidu.com"));
            // 创建一个新的画布对象
            using (SKSurface surface = SKSurface.Create(new SKImageInfo(backgroundBitmap.Width, backgroundBitmap.Height)))
            {
                // 获取画布对象
                SKCanvas canvas = surface.Canvas;

                // 绘制背景图片
                canvas.DrawBitmap(backgroundBitmap, new SKPoint(0, 0));

                // 在背景图片上绘制二维码图片
                canvas.DrawBitmap(qrCodeBitmap, new SKPoint(1, 1));
                var stream = new MemoryStream();
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

        public async Task UploadQrcodeBackgroundImageAsync(UploadQrcodeBackgroundDto input)
        {
            using (var stream = input.File.GetStream())
            {
                await _blobContainer.SaveAsync(AppraisementQrcodeConsts.QrcodeBackgroundImageBlobName, stream, overrideExisting: true);
            }
        }

        private MemoryStream GenerateQrcodeAsync(string content)
        {
            using var qrCodeGenerator = new QRCodeGenerator();
            // Generate QrCode
            var qr = qrCodeGenerator.CreateQrCode(content, ECCLevel.L);
            // Render to canvas
            var qrImageInfo = new SKImageInfo(50, 50);
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
