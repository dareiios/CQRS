using CQRSMediator.Commands.Notes.UpdateNote;
using FluentValidation;

namespace CQRSMediator.Validators.Notes
{
    public class UpdateNoteValidator : AbstractValidator<UpdateNoteCommand>
    {
        public UpdateNoteValidator()
        {
            RuleFor(cmd => cmd.Id)
                .NotEmpty().WithMessage("Id is required.");

            RuleFor(cmd => cmd.Text)
                .NotEmpty().WithMessage("Text is required.");

            RuleFor(cmd => cmd.Title)
                .NotEmpty().WithMessage("Title is required.");            
        }
    }
}
