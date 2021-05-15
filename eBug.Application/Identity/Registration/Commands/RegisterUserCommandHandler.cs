using System.Threading;
using System.Threading.Tasks;
using eBug.Application.Abstractions.Persistence;
using MediatR;

namespace eBug.Application.Identity.Registration.Commands
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, string>
    {
        private readonly IIdentityService _identityService;

        public RegisterUserCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        
        public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _identityService.RegisterUserAsync(request.Email, request.Password);
            return result;
        }
    }
}