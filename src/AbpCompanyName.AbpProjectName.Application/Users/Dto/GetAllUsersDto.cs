using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.Collections.Generic;

namespace AbpCompanyName.AbpProjectName.Users.Dto
{
    [AutoMapFrom(typeof(User))]
    public class GetAllUsersDto : EntityDto<long>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string UserName { get; set; }

        public List<string> RoleNames { get; set; }

        public string FullName { get; set; }

        public string EmailAddress { get; set; }

        public bool IsEmailConfirmed { get; set; }

        public DateTime? LastLoginTime { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreationTime { get; set; }
    }
}