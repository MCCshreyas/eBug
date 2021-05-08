using MediatR;

namespace eBug.Application.Features.Bugs.Commands.DeleteBug
{
    public class DeleteBugCommand : IRequest<bool>
    {
        public int BugId { get; set; }
    }
}