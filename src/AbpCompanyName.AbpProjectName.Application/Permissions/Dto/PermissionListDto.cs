using Abp.Authorization;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbpCompanyName.AbpProjectName.Permissions.Dto
{
    [AutoMapFrom(typeof(Permission))]
    public class PermissionListDto
    {
        public string Name { get; set; }

        public PermissionListDto Parent { get; set; }
    }
}
