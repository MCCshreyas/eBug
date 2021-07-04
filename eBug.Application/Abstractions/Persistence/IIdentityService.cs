using System;
using System.Threading.Tasks;

namespace eBug.Application.Abstractions.Persistence
{
    public interface IIdentityService
    {
        Task<Guid> RegisterUserAsync(string email, string password);
        Task<string> SignInAsync(string email, string password);
    }
}