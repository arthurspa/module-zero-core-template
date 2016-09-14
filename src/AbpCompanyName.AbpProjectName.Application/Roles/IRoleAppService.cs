using System.Threading.Tasks;
using Abp.Application.Services;
using AbpCompanyName.AbpProjectName.Roles.Dto;
using Abp.Application.Services.Dto;

namespace AbpCompanyName.AbpProjectName.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task CreateRole(CreateRoleInput input);

        Task UpdateRole(UpdateRoleInput input);

        Task DeleteRole(int roleId);

        Task<ListResultOutput<RoleListDto>> GetRoles();

        Task<RoleDto> GetRole(int roleId);
    }
}
