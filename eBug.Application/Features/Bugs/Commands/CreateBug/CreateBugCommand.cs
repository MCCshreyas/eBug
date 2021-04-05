using MediatR;

namespace eBug.Application.Features.Bugs.Commands.CreateBug
{
    public class CreateBugCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }
    }
}