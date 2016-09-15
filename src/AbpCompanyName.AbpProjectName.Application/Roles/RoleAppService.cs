using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Authorization;
using AbpCompanyName.AbpProjectName.Authorization.Roles;
using AbpCompanyName.AbpProjectName.Roles.Dto;
using Abp.AutoMapper;
using System.Collections.Generic;
using Abp.Domain.Repositories;
using Abp.Application.Services.Dto;
using AutoMapper;
using AbpCompanyName.AbpProjectName.Authorization;
using Abp.UI;

namespace AbpCompanyName.AbpProjectName.Roles
{
    [AbpAuthorize(PermissionNames.Pages_Administration_Roles)]
    public class RoleAppService : AbpProjectNameAppServiceBase, IRoleAppService
    {
        private readonly IRepository<Role> _roleRepository;
        private readonly RoleManager _roleManager;
        private readonly IPermissionManager _permissionManager;

        public RoleAppService(RoleManager roleManager,
                                IPermissionManager permissionManager,
                                IRepository<Role> roleRepository)
        {
            _roleManager = roleManager;
            _permissionManager = permissionManager;
            _roleRepository = roleRepository;
        }

        [AbpAuthorize(PermissionNames.Pages_Administration_Roles_Creating)]
        public async Task Create(CreateRoleInput input)
        {
            // Create
            var role = input.MapTo<Role>();
            await _roleManager.CreateAsync(role);

            // Set permissions
            await SetGrantedPermissionsAsync(role, input.GrantedPermissionNames);
        }

        [AbpAuthorize(PermissionNames.Pages_Administration_Roles_Editing)]
        public async Task Update(UpdateRoleInput input)
        {
            // Find      
            var role = await FindAsync(input.Id);

            // Update
            role = input.MapTo(role);
            await _roleManager.UpdateAsync(role);

            // Update permissions
            await SetGrantedPermissionsAsync(role, input.GrantedPermissionNames);
        }

        [AbpAuthorize(PermissionNames.Pages_Administration_Roles_Deleting)]
        public async Task Delete(int roleId)
        {
            // Find      
            var role = await FindAsync(roleId);

            if (role.IsStatic)
            {
                throw new UserFriendlyException("This role is static and cannot be deleted.");
            }

            // Delete
            await _roleManager.DeleteAsync(role);
        }

        public async Task<ListResultOutput<GetAllRolesDto>> GetAll()
        {
            var roles = await _roleRepository.GetAllListAsync();

            return new ListResultOutput<GetAllRolesDto>(
                    roles.MapTo<List<GetAllRolesDto>>()
                );
        }

        public async Task<RoleDto> Get(int roleId)
        {
            // Find      
            var roleEntity = await FindAsync(roleId);
            var role = roleEntity.MapTo<RoleDto>();

            // Get permissions
            var grantedPermissions = await _roleManager.GetGrantedPermissionsAsync(role.Id);
            role.GrantedPermissions = grantedPermissions.Select(x => x.Name).ToList();

            return role;
        }

        private async Task SetGrantedPermissionsAsync(Role role, List<string> grantedPermissionNames)
        {
            var grantedPermissions = _permissionManager
                .GetAllPermissions()
                .Where(p => grantedPermissionNames.Contains(p.Name))
                .ToList();
            await _roleManager.SetGrantedPermissionsAsync(role, grantedPermissions);
        }

        private async Task<Role> FindAsync(int id)
        {
            var entity = await _roleManager.FindByIdAsync(id);
            if (entity == null)
            {
                throw new UserFriendlyException("Role not found.");
            }

            return entity;
        }
    }
}