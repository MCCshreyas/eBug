using System;
using System.Threading;
using System.Threading.Tasks;
using eBug.Application.Contracts.Bugs;
using eBug.Application.Features.Bugs.Commands.ChangeBugStatus;
using eBug.Application.Features.Bugs.Commands.DeleteBug;
using eBug.Application.Features.Bugs.Queries.GetAllBugs;
using eBug.Application.Features.Bugs.Queries.GetAllBugsByProject;
using eBug.Application.Features.Bugs.Queries.GetBugDetailsById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eBug.Api.Controllers
{
    public class BugController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken token)
        {
            var bugs = await Mediator.Send(new GetAllBugsQuery(), token);
            return Ok(bugs);
        }

        [HttpGet("{bugId}")]
        public async Task<IActionResult> Get(Guid bugId,CancellationToken token)
        {
            var bug = await Mediator.Send(new GetBugDetailsByIdQuery { BugId = bugId }, token);
            return Ok(bug);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateBugCommand command, CancellationToken token)
        {
            var result = await Mediator.Send(command, token);
            return Ok(result);
        }

        [HttpDelete("{bugId}")]
        public async Task<IActionResult> Delete(Guid bugId, CancellationToken token)
        {
            var result = await Mediator.Send(new DeleteBugCommand { BugId = bugId}, token);
            return Ok(result);
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> ChangeStatus(ChangeBugStatusCommand command, CancellationToken token)
        {
            var result = await Mediator.Send(command, token);
            return Ok(result);
        }
        
        [HttpGet("[action]/{projectId}")]
        public async Task<IActionResult> GetAllBugsByProject(Guid projectId, CancellationToken token)
        {
            var result = await Mediator.Send(new GetAllBugsByProjectQuery { ProjectId = projectId}, token);
            return Ok(result);
        }
    }
}