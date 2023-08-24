using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Content;
using Volo.Abp.DependencyInjection;
using Wallee.Boc.Vote.Permissions;

namespace Wallee.Boc.Vote.Appraisements
{
    /// <summary>
    /// 评价活动接口
    /// </summary>
    [RemoteService(Name = VoteRemoteServiceConsts.RemoteServiceName)]
    [Route(AppraisementConsts.Route)]
    [Authorize(VotePermissions.Appraisements.Default)]
    public class AppraisementController : VoteController, IAppraisementAppService, ITransientDependency
    {
        private readonly IAppraisementAppService _appraisementAppService;

        public AppraisementController(IAppraisementAppService appraisementAppService)
        {
            _appraisementAppService = appraisementAppService;
        }
        /// <summary>
        /// 创建评价活动
        /// </summary>
        /// <param name="input">参数</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<AppraisementDto> CreateAsync(AppraisementCreateDto input)
        {
            return await _appraisementAppService.CreateAsync(input);
        }
        /// <summary>
        /// 删除评价活动
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteAsync(Guid id)
        {
            await _appraisementAppService.DeleteAsync(id);
        }
        /// <summary>
        /// 获取未过期的评价活动列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("available")]
        public async Task<List<AppraisementDto>> GetAllAvailableAsync()
        {
            return await _appraisementAppService.GetAllAvailableAsync();
        }
        /// <summary>
        /// 通过ID查找评价活动
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [AllowAnonymous]
        public async Task<AppraisementDto> GetAsync(Guid id)
        {
            return await _appraisementAppService.GetAsync(id);
        }
        /// <summary>
        /// 根据评价活动和相关角色下载二维码
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("download/qr-code")]
        [AllowAnonymous]
        public async Task<IRemoteStreamContent> GetDownloadAppraisementQrcode(GetAppraisementQrcodeDto input)
        {
            return await _appraisementAppService.GetDownloadAppraisementQrcode(input);
        }

        /// <summary>
        /// 评价活动的分页数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PagedResultDto<AppraisementDto>> GetListAsync(GetAppraisementsInputDto input)
        {
            return await _appraisementAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("rule-names")]
        public async Task<string[]> GetRuleNamesAsync()
        {
            return await _appraisementAppService.GetRuleNamesAsync();
        }

        /// <summary>
        /// 更新评价活动
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        public async Task<AppraisementDto> UpdateAsync(Guid id, AppraisementUpdateDto input)
        {
            return await _appraisementAppService.UpdateAsync(id, input);
        }

        /// <summary>
        /// 上传二维码字体文件
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("upload/qrcode-font")]
        public async Task UploadQrcdoeBgImgFontAsync(UploadQrcodeBgImgFontDto input)
        {
            await _appraisementAppService.UploadQrcdoeBgImgFontAsync(input);
        }

        /// <summary>
        /// 上传二维码的背景图片
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("upload/qrcode-bg")]
        public async Task UploadQrcodeBgImgAsync(UploadQrcodeBgImgDto input)
        {
            await _appraisementAppService.UploadQrcodeBgImgAsync(input);
        }
    }
}
