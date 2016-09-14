using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AbpCompanyName.AbpProjectName.Roles.Dto
{
    public class RoleDto : EntityDto
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public bool IsDefault { get; set; }

        public List<string> GrantedPermissions { get; set; }

    }
}
