using System.Security.Claims;
using eBug.Application.Abstractions.Identity;
using Microsoft.AspNetCore.Http;

namespace eBug.Api.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string UserId => _httpContextAccessor.HttpContext?.User?.FindFirstValue("UserId");
    }
}
