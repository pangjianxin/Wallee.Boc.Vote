using AutoFilterer.Attributes;
using AutoFilterer.Enums;
using AutoFilterer.Types;
using Volo.Abp.Application.Dtos;

namespace Wallee.Boc.Vote.AppraisementResults
{
    public class GetAppraisementResultsInputDto : FilterBase, IPagedAndSortedResultRequest
    {
        [StringFilterOptions(StringFilterOption.Contains)]
        [CompareTo(nameof(AppraisementResultDto.RuleName))]
        public string? Filter { get; set; }
        public int SkipCount { get; set; }
        public int MaxResultCount { get; set; }
        public string? Sorting { get; set; }
    }
}
