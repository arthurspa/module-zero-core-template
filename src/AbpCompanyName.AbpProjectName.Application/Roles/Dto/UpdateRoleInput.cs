using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace AbpCompanyName.AbpProjectName.Roles.Dto
{
    public class UpdateRoleInput
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public bool IsDefault { get; set; }

        [Required]
        public string DisplayName { get; set; }

        [Required]
        public List<string> GrantedPermissionNames { get; set; }
    }
}