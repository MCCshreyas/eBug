using System;
using System.Collections.Generic;
using eBug.Application.Contracts.Bugs;
using MediatR;

namespace eBug.Application.Features.Bugs.Queries.GetAllBugsByProject
{
    public class GetAllBugsByProjectQuery : IRequest<List<GetAllBugsByProjectResponse>>
    {
        public Guid ProjectId { get; set; }
    }
}