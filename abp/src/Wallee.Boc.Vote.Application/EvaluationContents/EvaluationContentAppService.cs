using AutoFilterer.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Wallee.Boc.Vote.Appraisements;

namespace Wallee.Boc.Vote.EvaluationContents
{
    public class EvaluationContentAppService :
        CrudAppService<EvaluationContent, EvaluationContentDto, Guid, GetEvaluationContentInputDto, EvaluationContentCreateDto, EvaluationContentUpdateDto>,
        IEvaluationContentAppService,
        ITransientDependency
    {
        private readonly EvaluationContentManager _evaluationContentManager;
        public IEvaluationContentRepository EvaluationContentRepository { get; }

        public EvaluationContentAppService(
            IEvaluationContentRepository evaluationContentRepository,
            EvaluationContentManager evaluationContentManager) : base(evaluationContentRepository)
        {
            EvaluationContentRepository = evaluationContentRepository;
            _evaluationContentManager = evaluationContentManager;
        }

        public async override Task<EvaluationContentDto> CreateAsync(EvaluationContentCreateDto input)
        {
            var content = await _evaluationContentManager.CreateAsync(input.Name, input.Description, input.Category);

            await EvaluationContentRepository.InsertAsync(content);

            return ObjectMapper.Map<EvaluationContent, EvaluationContentDto>(content);
        }

        public override async Task<PagedResultDto<EvaluationContentDto>> GetListAsync(GetEvaluationContentInputDto input)
        {
            await Task.Delay(1000);
            return await base.GetListAsync(input);
        }

        public async override Task<EvaluationContentDto> UpdateAsync(Guid id, EvaluationContentUpdateDto input)
        {
            var content = await EvaluationContentRepository.GetAsync(id);

            content.SetName(input.Name);
            content.SetDescription(input.Description);
            content.SetCategory(input.Category);

            await EvaluationContentRepository.UpdateAsync(content);

            return ObjectMapper.Map<EvaluationContent, EvaluationContentDto>(content);
        }

        public async Task<List<EvaluationContentDto>> GetListByCategory(EvaluationCategory category)
        {
            var list = (await EvaluationContentRepository.GetQueryableAsync()).Where(it => it.Category == category);

            var result = await AsyncExecuter.ToListAsync(list);
            return ObjectMapper.Map<List<EvaluationContent>, List<EvaluationContentDto>>(result);
        }

        protected override async Task<IQueryable<EvaluationContent>> CreateFilteredQueryAsync(GetEvaluationContentInputDto input)
        {
            return (await base.CreateFilteredQueryAsync(input)).ApplyFilter(input);
        }
    }
}
