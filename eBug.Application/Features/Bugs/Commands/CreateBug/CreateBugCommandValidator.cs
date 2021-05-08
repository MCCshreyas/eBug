using eBug.Application.Abstractions.Persistence;
using eBug.Application.Contracts.Bugs;
using FluentValidation;

namespace eBug.Application.Features.Bugs.Commands.CreateBug
{
    public class CreateBugCommandValidator : AbstractValidator<CreateBugCommand>
    {
        public CreateBugCommandValidator(IProjectRepository projectRepository)
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