using CQRSMediator.Queries.Notes.GetNoteTag;
using FluentValidation;

namespace CQRSMediator.Validators.Notes
{
    public class GetNoteTagByIdValidator : AbstractValidator<GetNoteTagQuery>
    {
        public GetNoteTagByIdValidator()
        {
            RuleFor(x => x.NoteId).NotEmpty().WithMessage("NoteId is required.")
                .GreaterThan(0).WithMessage("NoteId must be greater than 0.");
        }
    }
}
