using AutoFilterer.Attributes;
using AutoFilterer.Types;
using Volo.Abp.Application.Dtos;

namespace Wallee.Boc.Vote.EvaluationContents
{
    public class GetEvaluationContentInputDto : FilterBase, IPagedAndSortedResultRequest
    {
        [CompareTo(nameof(EvaluationContentDto.Name))]
        [StringFilterOptions(AutoFilterer.Enums.StringFilterOption.Contains)]
        public string? Filter { get; set; }
        public int SkipCount { get; set; }
        public int MaxResultCount { get; set; }
        public string? Sorting { get; set; }
    }
}
