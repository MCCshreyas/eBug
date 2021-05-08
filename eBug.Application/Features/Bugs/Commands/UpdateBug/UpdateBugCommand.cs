using eBug.Domain.Entities;
using MediatR;

namespace eBug.Application.Features.Bugs.Commands.UpdateBug
{
    public class UpdateBugCommand : IRequest
    {
        public int BugId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }
        public BugStatus Status { get; set; }
    }
}