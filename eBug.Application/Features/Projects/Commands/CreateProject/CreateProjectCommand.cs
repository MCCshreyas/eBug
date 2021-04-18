using System.Threading;
using System.Threading.Tasks;
using eBug.Application.Abstractions.Persistence;
using eBug.Domain.Entities;
using MediatR;

namespace eBug.Application.Features.Projects.Commands.CreateProject
{
    public record CreateProjectCommand : IRequest<int>
    {
        public string ProjectName { get; init; }
    }

    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
    {
        private readonly IAsyncRepository<Project> _projectRepository;

        public CreateProjectCommandHandler(IAsyncRepository<Project> projectRepository)
        {
            _projectRepository = projectRepository;
        }
        
        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Project
            {
                Name = request.ProjectName
            };

            await _projectRepository.AddAsync(project);
            return project.Id;
        }
    }
}