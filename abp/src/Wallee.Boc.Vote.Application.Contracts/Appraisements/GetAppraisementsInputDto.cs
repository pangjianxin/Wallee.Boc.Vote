using AutoFilterer.Attributes;
using AutoFilterer.Types;
using Volo.Abp.Application.Dtos;

namespace Wallee.Boc.Vote.Appraisements
{
    public class GetAppraisementsInputDto : FilterBase, IPagedAndSortedResultRequest
    {
        [StringFilterOptions(AutoFilterer.Enums.StringFilterOption.Contains)]
        [CompareTo(nameof(AppraisementDto.Name), nameof(AppraisementDto.Description))]
        public string? Filter { get; set; }
        public int SkipCount { get; set; }
        public int MaxResultCount { get; set; }
        public string? Sorting { get; set; }
    }
}
