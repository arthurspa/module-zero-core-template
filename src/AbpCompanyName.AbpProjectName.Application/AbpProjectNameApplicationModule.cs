using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using AbpCompanyName.AbpProjectName.Authorization;
using AbpCompanyName.AbpProjectName.AutoMapper;

namespace AbpCompanyName.AbpProjectName
{
    [DependsOn(
        typeof(AbpProjectNameCoreModule),
        typeof(AbpAutoMapperModule))]
    public class AbpProjectNameApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<AbpProjectNameAuthorizationProvider>();

            Configuration.Modules.AbpAutoMapper().Configurators.Add(cfg =>
            {
                cfg.CreateMissingTypeMaps = true;
                cfg.AddProfile<AdministrationProfile>();
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}