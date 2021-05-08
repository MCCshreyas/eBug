using System.Threading;
using System.Threading.Tasks;
using eBug.Application.Features.Projects.Commands.CreateProject;
using eBug.Application.Features.Projects.Commands.DeleteProject;
using eBug.Application.Features.Projects.Queries.GetAllProjects;
using Microsoft.AspNetCore.Mvc;

namespace eBug.Api.Controllers
{
    public class ProjectController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken token)
        {
            var result = await Mediator.Send(new GetAllProjectQuery(), token);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateProjectCommand request, CancellationToken token)
        {
            var result = await Mediator.Send(request, token);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteProjectCommand request, CancellationToken token)
        {
            var result = await Mediator.Send(request, token);
            return Ok(result);
        }
    }
}