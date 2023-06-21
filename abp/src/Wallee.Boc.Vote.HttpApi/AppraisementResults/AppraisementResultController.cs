using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;
using Wallee.Boc.Vote.Permissions;

namespace Wallee.Boc.Vote.AppraisementResults
{
    [RemoteService(Name = VoteRemoteServiceConsts.RemoteServiceName)]
    [Route("api/vote/appraisement-result")]
    [Authorize(VotePermissions.OrganizationUnits.Default)]
    public class AppraisementResultController : VoteController, IAppraisementResultAppService, ITransientDependency
    {
        private readonly IAppraisementResultAppService _appraisementResultAppService;

        public AppraisementResultController(IAppraisementResultAppService appraisementResultAppService)
        {
            _appraisementResultAppService = appraisementResultAppService;
        }

        [HttpPost]
        public async Task<AppraisementResultDto> CreateAsync(AppraisementResultCreateDto input)
        {
            return await _appraisementResultAppService.CreateAsync(input);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteAsync(Guid id)
        {
            await _appraisementResultAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<AppraisementResultDto> GetAsync(Guid id)
        {
            return await _appraisementResultAppService.GetAsync(id);
        }

        [HttpGet]
        public async Task<PagedResultDto<AppraisementResultDto>> GetListAsync(GetAppraisementResultsInputDto input)
        {
            return await _appraisementResultAppService.GetListAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<AppraisementResultDto> UpdateAsync(Guid id, AppraisementResultUpdateDto input)
        {
            return await _appraisementResultAppService.UpdateAsync(id, input);
        }
    }
}
