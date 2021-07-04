using System;
using System.Data;
using MediatR;

namespace eBug.Application.Features.Projects.Commands.CreateProject
{
    public record CreateProjectCommand : IRequest<Guid>
    {
        public string ProjectName { get; init; }
    }
}