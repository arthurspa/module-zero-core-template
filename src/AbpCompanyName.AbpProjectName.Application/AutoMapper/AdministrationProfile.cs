using Abp.Authorization;
using Abp.Localization;
using AbpCompanyName.AbpProjectName.Permissions.Dto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbpCompanyName.AbpProjectName.AutoMapper
{
    public class AdministrationProfile : Profile
    {
        public AdministrationProfile()
        {
            CreatePermissionsMaps();
        }

        private void CreatePermissionsMaps()
        {
            CreateMap<Permission, PermissionListDto>()
                .ForMember(dest => dest.Parent, opt => opt.MapFrom(src => src.Parent.Name))
                .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.DisplayName) // TODO: localize string
            );
        }
    }
}
