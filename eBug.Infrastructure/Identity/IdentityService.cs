using System.Threading.Tasks;
using eBug.Application.Abstractions.Persistence;
using Microsoft.AspNetCore.Identity;

namespace eBug.Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IdentityService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        
        public async Task<string> RegisterUserAsync(string email, string password)
        {
            var user = new ApplicationUser
            {
                UserName = email,
                Email = email,
            };
            
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Customer");
            }

            return user.Id;
        }

        public async Task<string> GetJwtTokenAsync(string username, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}