using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using AbpCompanyName.AbpProjectName.Authorization;
using AbpCompanyName.AbpProjectName.Users.Dto;
using Microsoft.AspNet.Identity;
using AbpCompanyName.AbpProjectName.Authorization.Roles;
using System;
using Abp.UI;
using System.Linq;

namespace AbpCompanyName.AbpProjectName.Users
{

    [AbpAuthorize(PermissionNames.Pages_Administration_Users)]
    public class UserAppService : AbpProjectNameAppServiceBase, IUserAppService
    {
        private readonly IRepository<User, long> _userRepository;
        private readonly IPermissionManager _permissionManager;
        private readonly UserManager _userManager;

        public UserAppService(IRepository<User, long> userRepository, IPermissionManager permissionManager, UserManager userManager)
        {
            _userRepository = userRepository;
            _permissionManager = permissionManager;
            _userManager = userManager;
        }

        public async Task<ListResultOutput<GetAllUsersDto>> GetAll()
        {
            var users = await _userRepository.GetAllListAsync();

            return new ListResultOutput<GetAllUsersDto>(
                users.MapTo<List<GetAllUsersDto>>()
                );
        }

        public async Task Create(CreateUserInput input)
        {
            var user = input.MapTo<User>();

            user.TenantId = AbpSession.TenantId;
            user.Password = new PasswordHasher().HashPassword(input.Password);
            user.IsEmailConfirmed = true;

            // Save changes to get user.Id from database
            CurrentUnitOfWork.SaveChanges();

            // Set roles
            await _userManager.SetRoles(user, input.RoleNames.ToArray());

            CheckErrors(await UserManager.CreateAsync(user));
        }

        public async Task Update(UpdateUserInput input)
        {
            var user = await FindAsync(input.Id);

            user = input.MapTo(user);
            user.Password = new PasswordHasher().HashPassword(input.Password);

            // Set roles
            await _userManager.SetRoles(user, input.RoleNames.ToArray());

            CheckErrors(await UserManager.UpdateAsync(user));
        }

        public async Task Delete(long userId)
        {
            var user = await FindAsync(userId);

            CheckErrors(await UserManager.DeleteAsync(user));
        }

        public async Task SetGrantedPermissions(SetGrantedPermissionsInput input)
        {
            var user = await FindAsync(input.UserId);

            var grantedPermissions = _permissionManager
                .GetAllPermissions()
                .Where(p => input.GrantedPermissionNames.Contains(p.Name))
                .ToList();

            await UserManager.SetGrantedPermissionsAsync(user, grantedPermissions);
        }

        private async Task<User> FindAsync(long id)
        {
            var entity = await _userManager.FindByIdAsync(id);
            if (entity == null)
            {
                throw new UserFriendlyException("User not found.");
            }

            return entity;
        }
    }
}