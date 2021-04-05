using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using eBug.Application.Abstractions.Persistence;
using eBug.Domain.Entities;
using MediatR;

namespace eBug.Application.Features.Bugs.Commands.CreateBug
{
    public class CreateBugCommandHandler : IRequestHandler<CreateBugCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IBugRepository _bugRepository;

        public CreateBugCommandHandler(IMapper mapper, IBugRepository bugRepository)
        {
            _mapper = mapper;
            _bugRepository = bugRepository;
        }
        
        public Task<int> Handle(CreateBugCommand request, CancellationToken cancellationToken)
        {
            var bug = _mapper.Map<Bug>(request);
            _bugRepository.AddAsync(bug);
            return Task.FromResult(bug.Id);
        }
    }
}