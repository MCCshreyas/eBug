using System.Threading;
using System.Threading.Tasks;
using eBug.Application.Identity.Registration.Commands.RegisterUser;
using eBug.Application.Identity.Registration.Commands.SignIn;
using Microsoft.AspNetCore.Mvc;

namespace eBug.Api.Controllers
{
    public class AccountController : BaseController
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterUserCommand request, CancellationToken token)
        {
            var result = await Mediator.Send(request, token);
            return Ok(result);
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignInUser(SignInCommand request, CancellationToken token)
        {
            var result = await Mediator.Send(request, token);
            return Ok(result);
        }
    }
}