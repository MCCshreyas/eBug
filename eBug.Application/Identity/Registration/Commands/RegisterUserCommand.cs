using MediatR;

namespace eBug.Application.Identity.Registration.Commands
{
    public class RegisterUserCommand : IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}