using AutoFilterer.Types;
using Volo.Abp.Application.Dtos;

namespace Wallee.Boc.Vote.AppraisementResults
{
    public class GetAppraisementResultsInputDto : FilterBase, IPagedAndSortedResultRequest
    {
        public string Filter { get; set; } = null!;
        public int SkipCount { get; set; }
        public int MaxResultCount { get; set; }
        public string Sorting { get; set; } = null!;
    }
}
