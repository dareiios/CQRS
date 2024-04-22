using CQRSMediator.Commands.Reminders.UpdateReminder;
using FluentValidation;

namespace CQRSMediator.Validators.Reminders
{
    public class UpdateReminderValidator : AbstractValidator<UpdateReminderCommand>
    {
        public UpdateReminderValidator()
        {
            RuleFor(cmd => cmd.Id).NotEmpty().WithMessage("Id is required.");
            RuleFor(cmd => cmd.Text).NotEmpty().WithMessage("Text is required.");

            RuleFor(cmd => cmd.Title).NotEmpty().WithMessage("Title is required.");

            RuleFor(cmd => cmd.DateToRemind).NotEmpty().WithMessage("DateToRemind is required.");
        }
    }
}
