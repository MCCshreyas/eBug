using MediatR;

namespace eBug.Application.Identity.Registration.Commands.SignIn
{
    public class SignInCommand : IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}