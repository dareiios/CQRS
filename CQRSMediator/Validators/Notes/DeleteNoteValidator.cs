using CQRSMediator.Commands.Notes.DeleteNote;
using FluentValidation;

namespace CQRSMediator.Validators.Notes
{
    public class DeleteNoteValidator : AbstractValidator<DeleteNoteCommand>
    {
        public DeleteNoteValidator()
        {
            RuleFor(cmd => cmd.Id).NotEmpty().WithMessage("Id is required.")
                .GreaterThan(0).WithMessage("Id must be greater tehat 0.");
        }
    }
}
