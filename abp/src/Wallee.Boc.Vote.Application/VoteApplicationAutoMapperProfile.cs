using AutoMapper;
using Volo.Abp.Identity;
using Wallee.Boc.Vote.AppraisementResults;
using Wallee.Boc.Vote.Appraisements;
using Wallee.Boc.Vote.CandidateOrgUnits;
using Wallee.Boc.Vote.EvaluationContents;
using Wallee.Boc.Vote.OrganizationUnits.Dtos;

namespace Wallee.Boc.Vote;

public class VoteApplicationAutoMapperProfile : Profile
{
    public VoteApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<OrganizationUnit, OrganizationUnitDto>();
        CreateMap<EvaluationContent, EvaluationContentDto>();
        CreateMap<Appraisement, AppraisementDto>();
        CreateMap<AppraisementResult, AppraisementResultDto>();
        CreateMap<AppraisementResultScoreDetail, AppraisementResultScoreDetailDto>();
        CreateMap<CandidateOrgUnit, CandidateOrgUnitDto>();
    }
}
