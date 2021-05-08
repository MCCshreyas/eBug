using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using eBug.Application.Abstractions.Persistence;
using eBug.Application.Contracts.Bugs;
using eBug.Domain.Entities;
using MediatR;

namespace eBug.Application.Features.Bugs.Queries.GetAllBugs
{
    public class GetAllBugsQueryHandler : IRequestHandler<GetAllBugsQuery, List<GetAllBugsResponse>>
    {
        private readonly IAsyncRepository<Bug> _bugsRepository;
        private readonly IMapper _mapper;

        public GetAllBugsQueryHandler(IAsyncRepository<Bug> bugsRepository, IMapper mapper)
        {
            _bugsRepository = bugsRepository;
            _mapper = mapper;
        }
        
        public async Task<List<GetAllBugsResponse>> Handle(GetAllBugsQuery request, CancellationToken token)
        {
            var bugs = await _bugsRepository.ListAllAsync(token);
            return _mapper.Map<List<Bug>, List<GetAllBugsResponse>>(bugs);
        }
    }
}