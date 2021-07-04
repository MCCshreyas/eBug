using FluentValidation;

namespace eBug.Application.Features.Bugs.Queries.GetBugDetailsById
{
    public class GetBugDetailsByIdQueryValidator : AbstractValidator<GetBugDetailsByIdQuery>
    {
        public GetBugDetailsByIdQueryValidator()
        {
            RuleFor(x => x.BugId)
                .NotEmpty()
                .NotNull();
        }
    }
}