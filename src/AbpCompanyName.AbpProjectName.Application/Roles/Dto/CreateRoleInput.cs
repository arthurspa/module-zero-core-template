using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AbpCompanyName.AbpProjectName.Roles.Dto
{
    public class CreateRoleInput
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string DisplayName { get; set; }

        [Required]
        public bool IsDefault { get; set; }

        [Required]
        public List<string> GrantedPermissionNames { get; set; }
    }
}
