using System;
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
        private readonly IAsyncRepository<Bug> _bugRepository;

        public CreateBugCommandHandler(IMapper mapper, IAsyncRepository<Bug> bugRepository)
        {
            _mapper = mapper;
            _bugRepository = bugRepository;
        }
        
        public async Task<int> Handle(CreateBugCommand request, CancellationToken cancellationToken)
        {
            var bug = new Bug
            {
                Title = request.Title,
                Description = request.Description,
                RaisedDate = DateTime.Now,
                CurrentStatus = BugStatus.Active,
                ProjectId = 1,
                UserId = 1
            };
            
            await _bugRepository.AddAsync(bug);
            return bug.Id;
        }
    }
}