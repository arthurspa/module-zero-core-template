using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AbpCompanyName.AbpProjectName.Users.Dto
{
    public class SetGrantedPermissionsInput
    {
        [Required]
        public long UserId { get; set; }

        [Required]
        public List<string> GrantedPermissionNames { get; set; }
    }
}
