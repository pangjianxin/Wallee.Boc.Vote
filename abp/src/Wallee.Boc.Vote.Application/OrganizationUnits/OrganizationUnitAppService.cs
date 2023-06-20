﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;
using Volo.Abp.ObjectExtending;
using Wallee.Boc.Vote.OrganizationUnits.Dtos;

namespace Wallee.Boc.Vote.OrganizationUnits
{
    public class OrganizationUnitAppService : IdentityAppServiceBase, IOrganizationUnitAppService
    {
        protected OrganizationUnitManager OrganizationUnitManager { get; }
        protected IOrganizationUnitRepository OrganizationUnitRepository { get; }

        protected IdentityUserManager UserManager { get; }
        protected IIdentityRoleRepository RoleRepository { get; }
        protected IIdentityUserRepository UserRepository { get; }

        public OrganizationUnitAppService(
            IdentityUserManager userManager,
            IIdentityRoleRepository roleRepository,
            IIdentityUserRepository userRepository,
            OrganizationUnitManager organizationUnitManager,
            IOrganizationUnitRepository organizationUnitRepository)
        {
            UserManager = userManager;
            RoleRepository = roleRepository;
            UserRepository = userRepository;
            OrganizationUnitManager = organizationUnitManager;
            OrganizationUnitRepository = organizationUnitRepository;
            ObjectMapperContext = typeof(AbpIdentityApplicationModule);
        }

        public async virtual Task<OrganizationUnitDto> CreateAsync(OrganizationUnitCreateDto input)
        {
            var origanizationUnit = new OrganizationUnit(
                GuidGenerator.Create(), input.DisplayName, input.ParentId, CurrentTenant.Id)
            {
                CreationTime = Clock.Now
            };
            input.MapExtraPropertiesTo(origanizationUnit);

            await OrganizationUnitManager.CreateAsync(origanizationUnit);
            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<OrganizationUnit, OrganizationUnitDto>(origanizationUnit);
        }

        public async virtual Task DeleteAsync(Guid id)
        {
            var origanizationUnit = await OrganizationUnitRepository.FindAsync(id);
            if (origanizationUnit == null)
            {
                return;
            }
            await OrganizationUnitManager.DeleteAsync(id);
        }

        public async virtual Task<ListResultDto<OrganizationUnitDto>> GetRootAsync()
        {
            var rootOriganizationUnits = await OrganizationUnitManager.FindChildrenAsync(null, recursive: false);

            return new ListResultDto<OrganizationUnitDto>(
                ObjectMapper.Map<List<OrganizationUnit>, List<OrganizationUnitDto>>(rootOriganizationUnits));
        }

        public async virtual Task<ListResultDto<OrganizationUnitDto>> FindChildrenAsync(OrganizationUnitGetChildrenDto input)
        {
            var origanizationUnitChildren = await OrganizationUnitManager.FindChildrenAsync(input.Id, input.Recursive);

            return new ListResultDto<OrganizationUnitDto>(
                ObjectMapper.Map<List<OrganizationUnit>, List<OrganizationUnitDto>>(origanizationUnitChildren));
        }

        public async virtual Task<OrganizationUnitDto> GetAsync(Guid id)
        {
            var origanizationUnit = await OrganizationUnitRepository.FindAsync(id);

            return ObjectMapper.Map<OrganizationUnit, OrganizationUnitDto>(origanizationUnit);
        }

        public async virtual Task<OrganizationUnitDto> GetLastChildOrNullAsync(Guid? parentId)
        {
            var origanizationUnitLastChildren = await OrganizationUnitManager.GetLastChildOrNullAsync(parentId);

            return ObjectMapper.Map<OrganizationUnit, OrganizationUnitDto>(origanizationUnitLastChildren);
        }

        public async virtual Task<ListResultDto<OrganizationUnitDto>> GetAllListAsync()
        {
            var origanizationUnits = await OrganizationUnitRepository.GetListAsync(false);

            return new ListResultDto<OrganizationUnitDto>(
                ObjectMapper.Map<List<OrganizationUnit>, List<OrganizationUnitDto>>(origanizationUnits));
        }

        public async virtual Task<PagedResultDto<OrganizationUnitDto>> GetListAsync(OrganizationUnitGetListInput input)
        {
            var origanizationUnitCount = await OrganizationUnitRepository.GetCountAsync();
            var origanizationUnits = await OrganizationUnitRepository
                .GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount, false);

            return new PagedResultDto<OrganizationUnitDto>(origanizationUnitCount,
                ObjectMapper.Map<List<OrganizationUnit>, List<OrganizationUnitDto>>(origanizationUnits));
        }

        public async virtual Task<ListResultDto<string>> GetRoleNamesAsync(Guid id)
        {
            var inOrignizationUnitRoleNames = await UserRepository.GetRoleNamesInOrganizationUnitAsync(id);
            return new ListResultDto<string>(inOrignizationUnitRoleNames);
        }

        public async virtual Task<PagedResultDto<IdentityRoleDto>> GetUnaddedRolesAsync(Guid id, OrganizationUnitGetUnaddedRoleListInput input)
        {
            var origanizationUnit = await OrganizationUnitRepository.GetAsync(id);

            var origanizationUnitRoleCount = await OrganizationUnitRepository
                .GetUnaddedRolesCountAsync(origanizationUnit, input.Filter);

            var origanizationUnitRoles = await OrganizationUnitRepository
                .GetUnaddedRolesAsync(origanizationUnit,
                input.Sorting, input.MaxResultCount,
                input.SkipCount, input.Filter);

            return new PagedResultDto<IdentityRoleDto>(origanizationUnitRoleCount,
                ObjectMapper.Map<List<IdentityRole>, List<IdentityRoleDto>>(origanizationUnitRoles));
        }

        public async virtual Task<PagedResultDto<IdentityRoleDto>> GetRolesAsync(Guid id, PagedAndSortedResultRequestDto input)
        {
            var origanizationUnit = await OrganizationUnitRepository.GetAsync(id);

            var origanizationUnitRoleCount = await OrganizationUnitRepository
                .GetRolesCountAsync(origanizationUnit);

            var origanizationUnitRoles = await OrganizationUnitRepository
                .GetRolesAsync(origanizationUnit,
                input.Sorting, input.MaxResultCount,
                input.SkipCount);

            return new PagedResultDto<IdentityRoleDto>(origanizationUnitRoleCount,
                ObjectMapper.Map<List<IdentityRole>, List<IdentityRoleDto>>(origanizationUnitRoles));
        }


        public async virtual Task<PagedResultDto<IdentityUserDto>> GetUnaddedUsersAsync(Guid id, OrganizationUnitGetUnaddedUserListInput input)
        {
            var origanizationUnit = await OrganizationUnitRepository.GetAsync(id);

            var origanizationUnitUserCount = await OrganizationUnitRepository
                .GetUnaddedUsersCountAsync(origanizationUnit, input.Filter);
            var origanizationUnitUsers = await OrganizationUnitRepository
                .GetUnaddedUsersAsync(origanizationUnit,
                input.Sorting, input.MaxResultCount,
                input.SkipCount, input.Filter);

            return new PagedResultDto<IdentityUserDto>(origanizationUnitUserCount,
                ObjectMapper.Map<List<IdentityUser>, List<IdentityUserDto>>(origanizationUnitUsers));
        }

        public async virtual Task<PagedResultDto<IdentityUserDto>> GetUsersAsync(Guid id, GetIdentityUsersInput input)
        {
            var origanizationUnit = await OrganizationUnitRepository.GetAsync(id);

            var origanizationUnitUserCount = await OrganizationUnitRepository
                .GetMembersCountAsync(origanizationUnit, input.Filter);
            var origanizationUnitUsers = await OrganizationUnitRepository
                .GetMembersAsync(origanizationUnit,
                input.Sorting, input.MaxResultCount,
                input.SkipCount, input.Filter);

            return new PagedResultDto<IdentityUserDto>(origanizationUnitUserCount,
                ObjectMapper.Map<List<IdentityUser>, List<IdentityUserDto>>(origanizationUnitUsers));
        }

        public async virtual Task MoveAsync(Guid id, OrganizationUnitMoveDto input)
        {
            await OrganizationUnitManager.MoveAsync(id, input.ParentId);
        }

        public async virtual Task<OrganizationUnitDto> UpdateAsync(Guid id, OrganizationUnitUpdateDto input)
        {
            var origanizationUnit = await OrganizationUnitRepository.GetAsync(id);
            origanizationUnit.DisplayName = input.DisplayName;
            input.MapExtraPropertiesTo(origanizationUnit);

            await OrganizationUnitManager.UpdateAsync(origanizationUnit);
            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<OrganizationUnit, OrganizationUnitDto>(origanizationUnit);
        }

        public async virtual Task AddUsersAsync(Guid id, OrganizationUnitAddUserDto input)
        {
            var origanizationUnit = await OrganizationUnitRepository.GetAsync(id);

            foreach (var item in input.UserIds)
            {
                var user = await UserRepository.GetAsync(item);
                await UserManager.AddToOrganizationUnitAsync(user, origanizationUnit);
            }

            await CurrentUnitOfWork.SaveChangesAsync();
        }

        public async virtual Task AddRolesAsync(Guid id, OrganizationUnitAddRoleDto input)
        {
            var origanizationUnit = await OrganizationUnitRepository.GetAsync(id);

            foreach (var item in input.RoleIds)
            {
                var role = await RoleRepository.GetAsync(item);
                await OrganizationUnitManager.AddRoleToOrganizationUnitAsync(role, origanizationUnit);
            }

            await CurrentUnitOfWork.SaveChangesAsync();
        }

        public async virtual Task DeleteRoleAsync(Guid organizationUnitId, Guid roleId)
        {
            var origanizationUnit = await OrganizationUnitRepository.GetAsync(organizationUnitId);
            var role = await RoleRepository.GetAsync(roleId);
            await OrganizationUnitManager.RemoveRoleFromOrganizationUnitAsync(role, origanizationUnit);
        }

        public async virtual Task DeleteUserAsync(Guid organizationUnitId, Guid userId)
        {
            await UserManager.RemoveFromOrganizationUnitAsync(userId, organizationUnitId);
        }
    }
}
