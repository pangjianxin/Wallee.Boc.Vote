using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;
using Wallee.Boc.Vote.Appraisements;
using Wallee.Boc.Vote.Permissions;

namespace Wallee.Boc.Vote.EvaluationContents
{
    [RemoteService(Name = VoteRemoteServiceConsts.RemoteServiceName)]
    [Route("api/vote/evaluation-content")]
    [Authorize(VotePermissions.OrganizationUnits.Default)]
    public class EvaluationContentController : VoteController, IEvaluationContentAppService, ITransientDependency
    {
        private readonly IEvaluationContentAppService _evaluationContentAppService;

        public EvaluationContentController(IEvaluationContentAppService evaluationContentAppService)
        {
            _evaluationContentAppService = evaluationContentAppService;
        }

        [HttpPost]
        public async Task<EvaluationContentDto> CreateAsync(EvaluationContentCreateDto input)
        {
            return await _evaluationContentAppService.CreateAsync(input);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteAsync(Guid id)
        {
            await _evaluationContentAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<EvaluationContentDto> GetAsync(Guid id)
        {
            return await _evaluationContentAppService.GetAsync(id);
        }

        [HttpGet]
        public async Task<PagedResultDto<EvaluationContentDto>> GetListAsync(GetEvaluationContentInputDto input)
        {
            return await _evaluationContentAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("category/{category}")]
        public async Task<List<EvaluationContentDto>> GetListByCategory(EvaluationCategory category)
        {
            return await _evaluationContentAppService.GetListByCategory(category);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<EvaluationContentDto> UpdateAsync(Guid id, EvaluationContentUpdateDto input)
        {
            return await _evaluationContentAppService.UpdateAsync(id, input);
        }
    }
}
