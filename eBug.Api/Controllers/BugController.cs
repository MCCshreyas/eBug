using System.Threading;
using System.Threading.Tasks;
using eBug.Application.Contracts.Bugs;
using eBug.Application.Features.Bugs.Commands.ChangeBugStatus;
using eBug.Application.Features.Bugs.Commands.DeleteBug;
using eBug.Application.Features.Bugs.Queries.GetAllBugs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eBug.Api.Controllers
{
    [Authorize]
    public class BugController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken token)
        {
            var bugs = await Mediator.Send(new GetAllBugsQuery(), token);
            return Ok(bugs);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateBugCommand command, CancellationToken token)
        {
            var result = await Mediator.Send(command, token);
            return Ok(result);
        }

        [HttpPost("ChangeStatus")]
        public async Task<IActionResult> ChangeStatus(ChangeBugStatusCommand command, CancellationToken token)
        {
            var result = await Mediator.Send(command, token);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteBugCommand command, CancellationToken token)
        {
            var result = await Mediator.Send(command, token);
            return Ok(result);
        }
    }
}