using System.Threading;
using System.Threading.Tasks;
using eBug.Application.Abstractions.Persistence;
using MediatR;

namespace eBug.Application.Features.Bugs.Commands.ChangeBugStatus
{
    public class ChangeBugStatusCommandHandler : IRequestHandler<ChangeBugStatusCommand, bool>
    {
        private readonly IBugRepository _bugRepository;

        public ChangeBugStatusCommandHandler(IBugRepository bugRepository)
        {
            _bugRepository = bugRepository;
        }
        
        public async Task<bool> Handle(ChangeBugStatusCommand request, CancellationToken cancellationToken)
        {
            var bug = await _bugRepository.GetByIdAsync(request.BugId, cancellationToken);
            bug.ChangeStatus(request.NewStatus);
            await _bugRepository.UpdateAsync(bug, cancellationToken);
            return true;
        }
    }
}