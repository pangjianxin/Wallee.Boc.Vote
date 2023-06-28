using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;
using Wallee.Boc.Vote.Permissions;

namespace Wallee.Boc.Vote.Appraisements
{
    /// <summary>
    /// 评价活动接口
    /// </summary>
    [RemoteService(Name = VoteRemoteServiceConsts.RemoteServiceName)]
    [Route("api/vote/appraisement")]
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
        public async Task<AppraisementDto> GetAsync(Guid id)
        {
            return await _appraisementAppService.GetAsync(id);
        }
        /// <summary>
        /// 评价活动的分页数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [EnableRateLimiting("UserBasedRateLimiting")]
        public async Task<PagedResultDto<AppraisementDto>> GetListAsync(GetAppraisementsInputDto input)
        {
            return await _appraisementAppService.GetListAsync(input);
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
    }
}
