using System.Collections.Generic;
using MediatR;

namespace eBug.Application.Features.Bugs.Queries.GetAllBugs
{
    public record GetAllBugsQuery : IRequest<List<GetAllBugsResponse>>
    {
    }
}