using CQRSMediator.Queries.Notes.GetNote;
using FluentValidation;

namespace CQRSMediator.Validators.Notes
{
    public class GetNoteByIdValidator : AbstractValidator<GetNoteQuery>
    {
        public GetNoteByIdValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.")
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}
