using System.Threading;
using System.Threading.Tasks;
using eBug.Application.Abstractions.Persistence;
using MediatR;

namespace eBug.Application.Features.Bugs.Commands.DeleteBug
{
    public class DeleteBugCommandHandler : IRequestHandler<DeleteBugCommand, bool>
    {
        private readonly IBugRepository _bugRepository;

        public DeleteBugCommandHandler(IBugRepository bugRepository)
        {
            _bugRepository = bugRepository;
        }
        
        public async Task<bool> Handle(DeleteBugCommand request, CancellationToken token)
        {
            var bug = await _bugRepository.GetByIdAsync(request.BugId, token);
            await _bugRepository.DeleteAsync(bug, token);
            return true;
        }
    }
}