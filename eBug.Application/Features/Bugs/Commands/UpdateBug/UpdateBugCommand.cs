using System;
using eBug.Domain.Entities;
using MediatR;

namespace eBug.Application.Features.Bugs.Commands.UpdateBug
{
    public class UpdateBugCommand : IRequest
    {
        public Guid BugId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid ProjectId { get; set; }
        public BugStatus Status { get; set; }
    }
}