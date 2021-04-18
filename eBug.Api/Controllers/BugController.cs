using System.Threading.Tasks;
using eBug.Application.Features.Bugs.Commands.CreateBug;
using eBug.Application.Features.Bugs.Queries.GetAllBugs;
using Microsoft.AspNetCore.Mvc;

namespace eBug.Api.Controllers
{
    public class BugController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var bugs = await Mediator.Send(new GetAllBugsQuery());
            return Ok(bugs);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateBugCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}