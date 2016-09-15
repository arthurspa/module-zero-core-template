using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AbpCompanyName.AbpProjectName.Users.Dto;

namespace AbpCompanyName.AbpProjectName.Users
{
    public interface IUserAppService : IApplicationService
    {
        Task<ListResultOutput<GetAllUsersDto>> GetAll();

        Task Create(CreateUserInput input);

        Task Update(UpdateUserInput input);

        Task Delete(long userId);

        Task SetGrantedPermissions(SetGrantedPermissionsInput input);
    }
}