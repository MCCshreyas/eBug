using System.Threading.Tasks;
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
    }
}