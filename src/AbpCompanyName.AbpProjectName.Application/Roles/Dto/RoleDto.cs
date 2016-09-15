using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using AbpCompanyName.AbpProjectName.Authorization.Roles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AbpCompanyName.AbpProjectName.Roles.Dto
{
    [AutoMap(typeof(Role))]
    public class RoleDto : EntityDto, IHasCreationTime
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public bool IsDefault { get; set; }

        public List<string> GrantedPermissions { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
