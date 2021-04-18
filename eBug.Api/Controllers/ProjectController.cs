using System.Threading.Tasks;
using eBug.Application.Features.Projects.Commands.CreateProject;
using eBug.Application.Features.Projects.Queries.GetAllProjects;
using Microsoft.AspNetCore.Mvc;

namespace eBug.Api.Controllers
{
    public class ProjectController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await Mediator.Send(new GetAllProjectQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateProjectCommand request)
        {
            var result = await Mediator.Send(request);
            return Ok(result);
        }
    }
}