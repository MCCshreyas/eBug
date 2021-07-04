using System;
using System.Threading;
using System.Threading.Tasks;
using eBug.Application.Abstractions.Persistence;
using eBug.Domain.Entities;
using MediatR;

namespace eBug.Application.Features.Projects.Commands.CreateProject
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Guid>
    {
        private readonly IAsyncRepository<Project> _projectRepository;

        public CreateProjectCommandHandler(IAsyncRepository<Project> projectRepository)
        {
            _projectRepository = projectRepository;
        }
        
        public async Task<Guid> Handle(CreateProjectCommand request, CancellationToken token)
        {
            var project = new Project(request.ProjectName);
            await _projectRepository.AddAsync(project, token);
            return project.Id;
        }
    }
}