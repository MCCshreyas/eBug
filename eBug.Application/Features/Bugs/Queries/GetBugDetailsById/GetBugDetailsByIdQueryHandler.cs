using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using eBug.Application.Abstractions.Persistence;
using eBug.Application.Contracts.Bugs;
using MediatR;

namespace eBug.Application.Features.Bugs.Queries.GetBugDetailsById
{
    public class GetBugDetailsByIdQueryHandler : IRequestHandler<GetBugDetailsByIdQuery, GetBugDetailsByIdResponse>
    {
        private readonly IBugRepository _bugRepository;
        private readonly IMapper _mapper;

        public GetBugDetailsByIdQueryHandler(IBugRepository bugRepository, IMapper mapper)
        {
            _bugRepository = bugRepository;
            _mapper = mapper;
        }

        public async Task<GetBugDetailsByIdResponse> Handle(GetBugDetailsByIdQuery request, CancellationToken cancellationToken)
        {
            var bug = await _bugRepository.GetByIdAsync(request.BugId, cancellationToken);
            return _mapper.Map<GetBugDetailsByIdResponse>(bug);
        }
    }
}