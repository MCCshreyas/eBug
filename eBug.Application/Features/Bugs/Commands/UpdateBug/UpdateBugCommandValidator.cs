using eBug.Application.Abstractions.Persistence;
using FluentValidation;

namespace eBug.Application.Features.Bugs.Commands.UpdateBug
{
    public class UpdateBugCommandValidator : AbstractValidator<UpdateBugCommand>
    {
        public UpdateBugCommandValidator(IProjectRepository projectRepository)
        {
            CascadeMode = CascadeMode.Continue;
            
            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull()
                .MinimumLength(5);
            
            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull()
                .MinimumLength(10);

            RuleFor(x => x.ProjectId)
                .MustAsync(projectRepository.IsProjectExists)
                .WithMessage("Project does not exists");
        }
    }
}