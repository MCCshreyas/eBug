using System.Collections.Generic;
using MediatR;

namespace eBug.Application.Features.Bugs.Queries.GetAllBugs
{
    public class GetAllBugsQuery : IRequest<List<GetAllBugsResponse>>
    {
    }
}