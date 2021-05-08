using System.Collections.Generic;
using eBug.Application.Contracts.Bugs;
using MediatR;

namespace eBug.Application.Features.Bugs.Queries.GetAllBugs
{
    public record GetAllBugsQuery : IRequest<List<GetAllBugsResponse>>
    {
    }
}