using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using AbpCompanyName.AbpProjectName.Authorization.Roles;

namespace AbpCompanyName.AbpProjectName.Roles.Dto
{
    [AutoMap(typeof(Role))]
    public class UpdateRoleInput: CreateRoleInput, IEntityDto
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
    }
}