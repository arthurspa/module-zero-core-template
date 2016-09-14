using Abp.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using AbpCompanyName.AbpProjectName.Permissions.Dto;
using Abp.AutoMapper;

namespace AbpCompanyName.AbpProjectName.Permissions
{
    public class PermissionAppService : AbpProjectNameAppServiceBase, IPermissionAppService
    {
        private readonly IPermissionManager _permissionManager;

        public PermissionAppService(IPermissionManager permissionManager)
        {
            _permissionManager = permissionManager;
        }

        public ListResultOutput<PermissionListDto> GetAllPermissions()
        {
            return new ListResultOutput<PermissionListDto>(
                _permissionManager
                    .GetAllPermissions()
                    .ToList()
                    .MapTo<List<PermissionListDto>>()
                );
        }
    }
}
