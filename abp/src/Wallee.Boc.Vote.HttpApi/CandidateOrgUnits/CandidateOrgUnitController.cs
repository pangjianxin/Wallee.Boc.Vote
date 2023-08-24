using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;
using Wallee.Boc.Vote.Permissions;

namespace Wallee.Boc.Vote.CandidateOrgUnits
{
    [RemoteService(Name = VoteRemoteServiceConsts.RemoteServiceName)]
    [Route("api/vote/candidate-org-unit")]
    [Authorize(VotePermissions.OrganizationUnits.Default)]
    public class CandidateOrgUnitController : VoteController, ICandidateOrgUnitAppService, ITransientDependency
    {
        private readonly ICandidateOrgUnitAppService _candidateOrgUnitAppService;

        public CandidateOrgUnitController(ICandidateOrgUnitAppService candidateOrgUnitAppService)
        {
            _candidateOrgUnitAppService = candidateOrgUnitAppService;
        }

        [HttpPost]
        public async Task<CandidateOrgUnitDto> CreateAsync(CandidateOrgUnitCreateDto input)
        {
            return await _candidateOrgUnitAppService.CreateAsync(input);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteAsync(Guid id)
        {
            await _candidateOrgUnitAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<CandidateOrgUnitDto> GetAsync(Guid id)
        {
            return await _candidateOrgUnitAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("candidate-org-units")]
        [AllowAnonymous]
        public async Task<List<CandidateOrgUnitDto>> GetCandidateOrgUnitEvaList()
        {
            return await _candidateOrgUnitAppService.GetCandidateOrgUnitEvaList();
        }

        [HttpGet]
        public async Task<PagedResultDto<CandidateOrgUnitDto>> GetListAsync(GetCandidateOrgUnitsInputDto input)
        {
            return await _candidateOrgUnitAppService.GetListAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<CandidateOrgUnitDto> UpdateAsync(Guid id, CandidateOrgUnitUpdateDto input)
        {
            return await _candidateOrgUnitAppService.UpdateAsync(id, input);
        }

        [HttpPut]
        [Route("supervior/{id}")]
        public async Task<CandidateOrgUnitDto> UpdateSuperiorAsync(Guid id, CandidateOrgUnitUpdateSuperiorDto input)
        {
            return await _candidateOrgUnitAppService.UpdateSuperiorAsync(id, input);
        }
    }
}
