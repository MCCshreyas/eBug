using System.Threading.Tasks;

namespace eBug.Application.Abstractions.Persistence
{
    public interface IIdentityService
    {
        Task<string> RegisterUserAsync(string email, string password);
        Task<string> GetJwtTokenAsync(string email, string password);
    }
}