using System.Collections.Generic;
using MediatR;

namespace eBug.Application.Features.Projects.Queries.GetAllProjects
{
    public record GetAllProjectQuery : IRequest<List<GetAllProjectResponse>>;
}