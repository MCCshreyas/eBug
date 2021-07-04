using System;
using eBug.Domain.Entities;
using MediatR;

namespace eBug.Application.Features.Bugs.Commands.ChangeBugStatus
{
    public record ChangeBugStatusCommand : IRequest<bool>
    {
        public Guid BugId { get; set; }
        public BugStatus NewStatus { get; set; }
    }
}