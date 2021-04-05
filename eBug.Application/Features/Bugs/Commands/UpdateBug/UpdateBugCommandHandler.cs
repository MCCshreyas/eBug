using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace eBug.Application.Features.Bugs.Commands.UpdateBug
{
    public class UpdateBugCommandHandler : IRequestHandler<UpdateBugCommand>
    {
        public Task<Unit> Handle(UpdateBugCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}