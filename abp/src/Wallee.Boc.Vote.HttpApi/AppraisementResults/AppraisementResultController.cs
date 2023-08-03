using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.WebClientInfo;
using Volo.Abp.DependencyInjection;
using Wallee.Boc.Vote.Permissions;

namespace Wallee.Boc.Vote.AppraisementResults
{
    [RemoteService(Name = VoteRemoteServiceConsts.RemoteServiceName)]
    [Route("api/vote/appraisement-result")]
    [Authorize(VotePermissions.OrganizationUnits.Default)]
    public class AppraisementResultController : VoteController, IAppraisementResultAppService, ITransientDependency
    {
        private readonly IAppraisementResultAppService _appraisementResultAppService;
        private readonly IWebClientInfoProvider _webClientInfoProvider;

        public AppraisementResultController(
            IAppraisementResultAppService appraisementResultAppService,
            IWebClientInfoProvider webClientInfoProvider)
        {
            _appraisementResultAppService = appraisementResultAppService;
            _webClientInfoProvider = webClientInfoProvider;
        }

        [HttpPost]
        public async Task<AppraisementResultDto> CreateAsync(AppraisementResultCreateDto input)
        {
            input.ClientIp = _webClientInfoProvider.ClientIpAddress;
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
