using AutoFilterer.Types;
using Volo.Abp.Application.Dtos;

namespace Wallee.Boc.Vote.CandidateOrgUnits
{
    public class GetCandidateOrgUnitsInputDto : FilterBase, IPagedAndSortedResultRequest
    {
        public string? Filter { get; set; }
        public int SkipCount { get; set; }
        public int MaxResultCount { get; set; }
        public string? Sorting { get; set; }
    }
}
