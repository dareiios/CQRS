using CQRSMediator.Commands.Reminders.CreateReminder;
using FluentValidation;

namespace CQRSMediator.Validators.Reminders
{
    public class CreateReminderValidator : AbstractValidator<CreateReminderCommand>
    {
        public CreateReminderValidator()
        {
            RuleFor(cmd => cmd.Text).NotEmpty().WithMessage("Text is required.");

            RuleFor(cmd => cmd.Title).NotEmpty().WithMessage("Title is required.");

            RuleFor(cmd => cmd.DateToRemind).NotEmpty().WithMessage("DateToRemind is required.");
        }
               
    }
}
