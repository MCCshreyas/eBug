using eBug.Application.Abstractions.Persistence;
using FluentValidation;

namespace eBug.Application.Features.Projects.Commands.CreateProject
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator(IProjectRepository projectRepository)
        {
            RuleFor(x => x.ProjectName)
                .NotEmpty()
                .NotNull()
                .MinimumLength(5)
                .MustAsync(projectRepository.UniqueProjectName)
                .WithMessage("Project with same name already exists.");
        }
    }
}