using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace Wallee.Boc.Vote.CandidateOrgUnits
{
    public interface ICandidateOrgUnitAppService :
        ICrudAppService<CandidateOrgUnitDto, Guid, GetCandidateOrgUnitInputDto, CandidateOrgUnitCreateDto, CandidateOrgUnitUpdateDto>,
        ITransientDependency
    {
        Task<List<CandidateOrgUnitDto>> GetCandidateOrgUnitEvaList();
        Task<CandidateOrgUnitDto> UpdateSuperiorAsync(Guid id, CandidateOrgUnitUpdateSuperiorDto input);
    }
}
