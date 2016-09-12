using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AbpCompanyName.AbpProjectName.Permissions.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbpCompanyName.AbpProjectName.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        ListResultOutput<PermissionListDto> GetAllPermissions();
    }
}
