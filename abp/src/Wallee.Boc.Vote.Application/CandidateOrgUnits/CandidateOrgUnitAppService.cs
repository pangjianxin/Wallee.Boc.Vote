using AutoFilterer.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace Wallee.Boc.Vote.CandidateOrgUnits
{
    public class CandidateOrgUnitAppService :
        CrudAppService<CandidateOrgUnit, CandidateOrgUnitDto, Guid, GetCandidateOrgUnitsInputDto, CandidateOrgUnitCreateDto, CandidateOrgUnitUpdateDto>,
        ICandidateOrgUnitAppService
    {
        private readonly IOrganizationUnitRepository _organizationUnitRepository;
        public readonly ICandidateOrgUnitRepository _candidateOrgUnitRepository;
        public IIdentityUserAppService _userAppService;

        public CandidateOrgUnitAppService(
            ICandidateOrgUnitRepository candidateOrgUnitRepository,
            IIdentityUserAppService userAppService,
            IOrganizationUnitRepository organizationUnitRepository) : base(candidateOrgUnitRepository)
        {
            _candidateOrgUnitRepository = candidateOrgUnitRepository;
            _userAppService = userAppService;
            _organizationUnitRepository = organizationUnitRepository;
        }

        public async override Task<CandidateOrgUnitDto> CreateAsync(CandidateOrgUnitCreateDto input)
        {
            var superior = await _userAppService.GetAsync(input.SuperiorId) ?? throw new UserFriendlyException("未找到相关用户，请核对");

            if (await _candidateOrgUnitRepository.AnyAsync(it => it.OrganizationUnitId == input.OrganizationUnitId))
            {
                throw new UserFriendlyException("已存在该机构,不能重复添加");
            }

            var orgUnit = await _organizationUnitRepository.GetAsync(input.OrganizationUnitId) ?? throw new UserFriendlyException("未找到相关机构信息,请核对");

            var candidateOrgUnit = new CandidateOrgUnit(GuidGenerator.Create(), orgUnit.Id, orgUnit.Code, orgUnit.DisplayName, input.Description, superior.Id, superior.Name, input.Category);

            await _candidateOrgUnitRepository.InsertAsync(candidateOrgUnit);

            return ObjectMapper.Map<CandidateOrgUnit, CandidateOrgUnitDto>(candidateOrgUnit);
        }

        public async override Task<CandidateOrgUnitDto> UpdateAsync(Guid id, CandidateOrgUnitUpdateDto input)
        {
            CandidateOrgUnit candidateOrgUnit = await _candidateOrgUnitRepository.GetAsync(id);
            candidateOrgUnit.ConcurrencyStamp = input.ConcurrencyStamp;

            if (candidateOrgUnit.OrganizationUnitId != input.OrganizationUnitId)
            {
                if (await _candidateOrgUnitRepository.AnyAsync(it => it.OrganizationUnitId == input.OrganizationUnitId))
                {
                    throw new UserFriendlyException($"组织机构已存在");
                }
            }
            var organizationUnit = await _organizationUnitRepository.GetAsync(input.OrganizationUnitId);
            candidateOrgUnit.SetOrgUnitInfo(organizationUnit.Id, organizationUnit.Code, organizationUnit.DisplayName, input.Description);

            var user = await _userAppService.GetAsync(input.SuperiorId);
            candidateOrgUnit.SetSuperior(user.Id, user.Name);

            candidateOrgUnit.SetCategory(input.Category);

            candidateOrgUnit.SetActive(input.IsActive);

            await _candidateOrgUnitRepository.UpdateAsync(candidateOrgUnit);

            return ObjectMapper.Map<CandidateOrgUnit, CandidateOrgUnitDto>(candidateOrgUnit);
        }

        public async Task<CandidateOrgUnitDto> UpdateSuperiorAsync(Guid id, CandidateOrgUnitUpdateSuperiorDto input)
        {
            var department = await _candidateOrgUnitRepository.GetAsync(id);

            department.ConcurrencyStamp = input.ConcurrencyStamp;

            var superior = await _userAppService.GetAsync(input.SuperiorId) ?? throw new UserFriendlyException("未找到相关用户，请查证");

            department.SetSuperior(superior.Id, superior.Name);

            await _candidateOrgUnitRepository.UpdateAsync(department);

            return ObjectMapper.Map<CandidateOrgUnit, CandidateOrgUnitDto>(department);
        }


        public async Task<List<CandidateOrgUnitDto>> GetCandidateOrgUnitEvaList()
        {
            return await MapToGetListOutputDtosAsync(await _candidateOrgUnitRepository.GetListAsync());
        }

        protected override async Task<IQueryable<CandidateOrgUnit>> CreateFilteredQueryAsync(GetCandidateOrgUnitsInputDto input)
        {
            return (await base.CreateFilteredQueryAsync(input)).ApplyFilter(input);
        }
    }
}
