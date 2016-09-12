using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace AbpCompanyName.AbpProjectName.Authorization
{
    public class AbpProjectNameAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //Common permissions
            var pages = context.GetPermissionOrNull(PermissionNames.Pages);
            if (pages == null)
            {
                pages = context.CreatePermission(PermissionNames.Pages, L("Pages"));
            }

            var administration = pages.CreateChildPermission(PermissionNames.Pages_Administration, L("Administration"));

            var roles = administration.CreateChildPermission(PermissionNames.Pages_Administration_Roles, L("Roles"));
            var rolesCreating = roles.CreateChildPermission(PermissionNames.Pages_Administration_Roles_Creating, L("RolesCreating"));
            var rolesDeleting = roles.CreateChildPermission(PermissionNames.Pages_Administration_Roles_Deleting, L("RolesDeleting"));
            var rolesEditing = roles.CreateChildPermission(PermissionNames.Pages_Administration_Roles_Editing, L("RolesEditing"));

            var users = administration.CreateChildPermission(PermissionNames.Pages_Administration_Users, L("Users"));

            //Host permissions
            var tenants = administration.CreateChildPermission(PermissionNames.Pages_Administration_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AbpProjectNameConsts.LocalizationSourceName);
        }
    }
}
