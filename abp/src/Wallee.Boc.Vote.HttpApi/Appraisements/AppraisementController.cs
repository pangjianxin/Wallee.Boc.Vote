using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;
using Wallee.Boc.Vote.Permissions;

namespace Wallee.Boc.Vote.Appraisements
{
    [RemoteService(Name = VoteRemoteServiceConsts.RemoteServiceName)]
    [Route("api/vote/appraisement")]
    [Authorize(VotePermissions.OrganizationUnits.Default)]
    public class AppraisementController : VoteController, IAppraisementAppService, ITransientDependency
    {
        private readonly IAppraisementAppService _appraisementAppService;

        public AppraisementController(IAppraisementAppService appraisementAppService)
        {
            _appraisementAppService = appraisementAppService;
        }

        [HttpPost]
        public async Task<AppraisementDto> CreateAsync(AppraisementCreateDto input)
        {
            return await _appraisementAppService.CreateAsync(input);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteAsync(Guid id)
        {
            await _appraisementAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("available")]
        public async Task<List<AppraisementDto>> GetAllAvailableAsync()
        {
            return await _appraisementAppService.GetAllAvailableAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<AppraisementDto> GetAsync(Guid id)
        {
            return await _appraisementAppService.GetAsync(id);
        }

        [HttpGet]
        public async Task<PagedResultDto<AppraisementDto>> GetListAsync(GetAppraisementsInputDto input)
        {
            return await _appraisementAppService.GetListAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<AppraisementDto> UpdateAsync(Guid id, AppraisementUpdateDto input)
        {
            return await _appraisementAppService.UpdateAsync(id, input);
        }
    }
}
