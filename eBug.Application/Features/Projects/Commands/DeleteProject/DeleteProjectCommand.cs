using MediatR;

namespace eBug.Application.Features.Projects.Commands.DeleteProject
{
    public class DeleteProjectCommand : IRequest<bool>
    {
        public int ProjectId { get; init; }
    }
}