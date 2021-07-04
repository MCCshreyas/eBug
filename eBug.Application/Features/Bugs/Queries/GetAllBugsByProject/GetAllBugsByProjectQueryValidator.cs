using eBug.Application.Abstractions.Persistence;
using FluentValidation;

namespace eBug.Application.Features.Bugs.Queries.GetAllBugsByProject
{
    public class GetAllBugsByProjectQueryValidator : AbstractValidator<GetAllBugsByProjectQuery>
    {
        public GetAllBugsByProjectQueryValidator(IProjectRepository projectRepository)
        {
            RuleFor(x => x.ProjectId)
                .NotNull()
                .NotEmpty()
                .MustAsync(projectRepository.IsProjectExists)
                .WithMessage("Project does not exists.");
        }
    }
}