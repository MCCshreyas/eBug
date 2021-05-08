using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using eBug.Application.Abstractions.Persistence;
using eBug.Domain.Entities;
using MediatR;

namespace eBug.Application.Features.Projects.Commands.DeleteProject
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, bool>
    {
        private readonly IAsyncRepository<Project> _projectRepository;

        public DeleteProjectCommandHandler(IAsyncRepository<Project> projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<bool> Handle(DeleteProjectCommand request, CancellationToken token)
        {
            var project = await _projectRepository.GetByIdAsync(request.ProjectId, token);

            if (project.Bugs.Any(x => x.CurrentStatus != BugStatus.Closed))
            {
                return false;
            }

            await _projectRepository.DeleteAsync(project, token);
            return true;
        }
    }
}