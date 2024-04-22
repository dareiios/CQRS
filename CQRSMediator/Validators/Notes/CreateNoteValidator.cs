using CQRSMediator.Commands.Notes.CreateNote;
using FluentValidation;

namespace CQRSMediator.Validators.Notes
{
    public class CreateNoteValidator : AbstractValidator<CreateNoteCommand>
    {
        public CreateNoteValidator()
        {
            RuleFor(cmd => cmd.Text).NotEmpty().WithMessage("Text is required.");

            RuleFor(cmd => cmd.Title).NotEmpty().WithMessage("Title is required.");                
        }
    }
}
