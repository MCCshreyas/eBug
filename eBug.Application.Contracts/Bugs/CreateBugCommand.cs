using System;
using MediatR;

namespace eBug.Application.Contracts.Bugs
{
    public class CreateBugCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid ProjectId { get; set; }
    }
}