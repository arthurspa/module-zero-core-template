using System.Threading.Tasks;
using Abp.Application.Services;
using AbpCompanyName.AbpProjectName.Roles.Dto;
using Abp.Application.Services.Dto;

namespace AbpCompanyName.AbpProjectName.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task Create(CreateRoleInput input);

        Task Update(UpdateRoleInput input);

        Task Delete(int roleId);

        Task<ListResultOutput<GetAllRolesDto>> GetAll();

        Task<RoleDto> Get(int roleId);
    }
}
