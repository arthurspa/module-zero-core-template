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
        public async Task CreateRole(CreateRoleInput input)
        {
            // Create role
            var role = input.MapTo<Role>();
            await _roleManager.CreateAsync(role);

            // Set Role permissions
            await SetGrantedPermissionsAsync(role, input.GrantedPermissionNames);
        }

        [AbpAuthorize(PermissionNames.Pages_Administration_Roles_Editing)]
        public async Task UpdateRole(UpdateRoleInput input)
        {
            // Update role properties
            var role = await _roleManager.GetRoleByIdAsync(input.Id);
            role = Mapper.Map(input, role);
            await _roleManager.UpdateAsync(role);

            // Update Role permissions
            await SetGrantedPermissionsAsync(role, input.GrantedPermissionNames);
        }

        [AbpAuthorize(PermissionNames.Pages_Administration_Roles_Deleting)]
        public async Task DeleteRole(int roleId)
        {
            var role = await _roleManager.GetRoleByIdAsync(roleId);
            await _roleManager.DeleteAsync(role);
        }

        public async Task<ListResultOutput<RoleListDto>> GetRoles()
        {
            var roles = await _roleRepository.GetAllListAsync();

            return new ListResultOutput<RoleListDto>(
                    roles.MapTo<List<RoleListDto>>()
                );
        }

        public async Task<RoleDto> GetRole(int roleId)
        {
            var role = (await _roleRepository.GetAsync(roleId)).MapTo<RoleDto>();
            
            var grantedPermissions = await _roleManager.GetGrantedPermissionsAsync(role.Id);

            role.GrantedPermissions = new List<string>();
            foreach (var grantedPermission in grantedPermissions)
            {
                role.GrantedPermissions.Add(grantedPermission.Name);
            }

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
    }
}