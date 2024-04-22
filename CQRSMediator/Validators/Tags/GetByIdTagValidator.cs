using CQRSMediator.Queries.Tags.GetTag;
using FluentValidation;

namespace CQRSMediator.Validators.Tags
{
    public class GetByIdTagValidator : AbstractValidator<GetTagQuery>
    {
        public GetByIdTagValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.")
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
            

        }
    }
}
