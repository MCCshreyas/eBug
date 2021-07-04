using System.Threading;
using System.Threading.Tasks;
using eBug.Application.Abstractions.Persistence;
using MediatR;

namespace eBug.Application.Identity.Registration.Commands.SignIn
{
    public class SignInCommandHandler : IRequestHandler<SignInCommand, string>
    {
        private readonly IIdentityService _identityService;

        public SignInCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        
        public async Task<string> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var result = await _identityService.SignInAsync(request.Email, request.Password);
            return result;
        }
    }
}