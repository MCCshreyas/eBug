using eBug.Application.Abstractions.Persistence;
using FluentValidation;

namespace eBug.Application.Features.Bugs.Commands.DeleteBug
{
    public class DeleteBugCommandValidator : AbstractValidator<DeleteBugCommand>
    {
        public DeleteBugCommandValidator(IBugRepository bugRepository)
        {
            RuleFor(x => x.BugId)
                .NotEmpty()
                .NotNull()
                .MustAsync(bugRepository.IsBugExists)
                .WithMessage("Bug does not exists");
        }
    }
}