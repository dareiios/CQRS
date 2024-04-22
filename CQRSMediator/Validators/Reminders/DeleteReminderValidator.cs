using CQRSMediator.Commands.Reminders.DeleteReminder;
using FluentValidation;

namespace CQRSMediator.Validators.Reminders
{
    public class DeleteReminderValidator : AbstractValidator<DeleteReminderCommand>
    {
        public DeleteReminderValidator()
        {
            RuleFor(cmd => cmd.Id).NotEmpty().WithMessage("Id is required.")
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}
