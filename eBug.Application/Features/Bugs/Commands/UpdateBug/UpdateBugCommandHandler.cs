using System;
using System.Threading;
using System.Threading.Tasks;
using eBug.Application.Abstractions.Persistence;
using eBug.Domain.Entities;
using MediatR;

namespace eBug.Application.Features.Bugs.Commands.UpdateBug
{
    public class UpdateBugCommandHandler : IRequestHandler<UpdateBugCommand>
    {
        private readonly IAsyncRepository<Bug> _bugRepository;

        public UpdateBugCommandHandler(IAsyncRepository<Bug> bugRepository)
        {
            _bugRepository = bugRepository;
        }
        
        public async Task<Unit> Handle(UpdateBugCommand request, CancellationToken token)
        {
            var oldBug = await _bugRepository.GetByIdAsync(request.BugId, token);

            if (oldBug is null)
                throw new Exception("Bug does not exists");

            oldBug.SetDescription(request.Description);
            oldBug.MoveToAnotherProject(request.ProjectId);
            oldBug.ChangeStatus(request.Status);
            
            await _bugRepository.UpdateAsync(oldBug, token);
            return Unit.Value;
        }
    }
}