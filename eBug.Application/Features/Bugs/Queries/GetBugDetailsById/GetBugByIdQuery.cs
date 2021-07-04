using System;
using eBug.Application.Contracts.Bugs;
using MediatR;

namespace eBug.Application.Features.Bugs.Queries.GetBugDetailsById
{
    public class GetBugDetailsByIdQuery : IRequest<GetBugDetailsByIdResponse>
    {
        public Guid BugId { get; set; }
    }
}
