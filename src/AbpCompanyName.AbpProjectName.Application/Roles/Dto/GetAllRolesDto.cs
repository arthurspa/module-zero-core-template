using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using AbpCompanyName.AbpProjectName.Authorization.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbpCompanyName.AbpProjectName.Roles.Dto
{
    [AutoMap(typeof(Role))]
    public class GetAllRolesDto : EntityDto, IHasCreationTime
    {
        public string DisplayName { get; set; }

        public DateTime CreationTime { get; set; }

    }
}
