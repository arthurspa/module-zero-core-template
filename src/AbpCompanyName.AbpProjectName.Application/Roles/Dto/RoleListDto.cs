using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbpCompanyName.AbpProjectName.Roles.Dto
{
    public class RoleListDto : EntityDto
    {
        public string DisplayName { get; set; }

        public DateTime CreationTime { get; set; }

    }
}
