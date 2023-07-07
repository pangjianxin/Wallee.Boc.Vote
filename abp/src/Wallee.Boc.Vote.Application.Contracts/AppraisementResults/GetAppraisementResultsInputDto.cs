using AutoFilterer.Attributes;
using AutoFilterer.Enums;
using AutoFilterer.Types;
using System;
using Volo.Abp.Application.Dtos;

namespace Wallee.Boc.Vote.AppraisementResults
{
    public class GetAppraisementResultsInputDto : FilterBase, IPagedAndSortedResultRequest
    {
        [StringFilterOptions(StringFilterOption.Contains)]
        [CompareTo(nameof(AppraisementResultDto.Content))]
        public string Filter { get; set; } = null!;
        public int SkipCount { get; set; }
        public int MaxResultCount { get; set; }
        public string Sorting { get; set; } = null!;

        [CompareTo(nameof(AppraisementResultDto.CreatorId))]
        [OperatorComparison(OperatorType.Equal)]
        public Guid? CreatorId { get; set; }
    }
}
