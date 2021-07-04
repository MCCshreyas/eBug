using System;
using MediatR;

namespace eBug.Application.Features.Bugs.Commands.DeleteBug
{
    public class DeleteBugCommand : IRequest<bool>
    {
        public Guid BugId { get; set; }
    }
}