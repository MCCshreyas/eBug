using eBug.Application.Abstractions.Persistence;
using FluentValidation;

namespace eBug.Application.Features.Projects.Commands.DeleteProject
{
    public class DeleteProjectCommandValidator : AbstractValidator<DeleteProjectCommand>
    {
        public DeleteProjectCommandValidator(IProjectRepository projectRepository)
        {
            RuleFor(x => x.ProjectId)
                .NotEmpty().NotNull()
                .MustAsync(projectRepository.IsProjectExists)
                .WithMessage("Project does not exists.");
        }
    }
}