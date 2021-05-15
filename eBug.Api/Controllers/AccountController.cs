using System.Threading;
using System.Threading.Tasks;
using eBug.Application.Identity.Registration.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Expressions;

namespace eBug.Api.Controllers
{
    public class AccountController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserCommand request, CancellationToken token)
        {
            var result = await Mediator.Send(request, token);
            return Ok(result);
        }

        /*
        [HttpPost]
        public Task<IActionResult> GetJwtToken(GetJwtTokenQuery request, CancellationToken token)
        {
            var result = await Mediator.Send(request, token);
            return Ok(result);
        }
    */
    }
}