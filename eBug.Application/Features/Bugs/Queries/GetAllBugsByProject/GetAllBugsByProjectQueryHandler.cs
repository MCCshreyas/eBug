using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using eBug.Application.Abstractions.Persistence;
using eBug.Application.Contracts.Bugs;
using eBug.Domain.Entities;
using MediatR;

namespace eBug.Application.Features.Bugs.Queries.GetAllBugsByProject
{
    public class GetAllBugsByProjectQueryHandler : IRequestHandler<GetAllBugsByProjectQuery, List<GetAllBugsByProjectResponse>>
    {
        private readonly IBugRepository _bugRepository;
        private readonly IMapper _mapper;

        public GetAllBugsByProjectQueryHandler(IBugRepository bugRepository, IMapper mapper)
        {
            _bugRepository = bugRepository;
            _mapper = mapper;
        }
        
        public async Task<List<GetAllBugsByProjectResponse>> Handle(GetAllBugsByProjectQuery request, CancellationToken cancellationToken)
        {
            var bugsList = await _bugRepository.GetAllBugsByProjectIdAsync(request.ProjectId, cancellationToken);
            return _mapper.Map<List<Bug>, List<GetAllBugsByProjectResponse>>(bugsList);
        }
    }
}