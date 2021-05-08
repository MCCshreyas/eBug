using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using eBug.Application.Abstractions.Persistence;
using eBug.Application.Contracts.Bugs;
using eBug.Domain.Entities;
using FluentValidation;
using MediatR;

namespace eBug.Application.Features.Bugs.Commands.CreateBug
{
    public class CreateBugCommandHandler : IRequestHandler<CreateBugCommand, int>
    {
        private readonly IAsyncRepository<Bug> _bugRepository;

        public CreateBugCommandHandler(IMapper mapper, IBugRepository bugRepository, IValidator<CreateBugCommand> commandValidator)
        {
            _bugRepository = bugRepository;
        }
        
        public async Task<int> Handle(CreateBugCommand request, CancellationToken token)
        {
            var bug = new Bug
            {
                Title = request.Title,
                Description = request.Description,
                RaisedDate = DateTime.Now,
                CurrentStatus = BugStatus.Active,
                ProjectId = request.ProjectId,
                UserId = 1
            };
            
            await _bugRepository.AddAsync(bug, token);
            return bug.Id;
        }
    }
}