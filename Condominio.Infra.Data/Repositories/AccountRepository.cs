using Condominio.Domain.Entities.Account;
using Condominio.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Condominio.Infra.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public AccountRepository(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
        }

        public async Task AddUserRole(AppUser user, string role)
        {
            //var roles = new List<AppRole>()
            //{
            //    new AppRole() { Name = "Admin" },
            //    new AppRole() { Name = "Member" }
            //};

            //foreach (var item in roles)
            //{
            //    await _roleManager.CreateAsync(item);
            //}

            await this._userManager.AddToRoleAsync(user, role);
        }

        public async Task<string> GetRole(AppUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            return roles.FirstOrDefault();
        }

        public async Task<AppUser> Login(AppUser entity)
        {
            return await this._userManager.Users.FirstOrDefaultAsync(x => x.UserName == entity.UserName);
        }

        public async Task<IdentityResult> Register(AppUser entity, string password)
        {
            return await this._userManager.CreateAsync(entity, password);
        }
    }
}
