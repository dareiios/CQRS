using CQRSMediator.Queries.Reminders.GetReminder;
using FluentValidation;

namespace CQRSMediator.Validators.Reminders
{
    public class GetReminderByIdValidator : AbstractValidator<GetReminderQuery>
    {
        public GetReminderByIdValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.")
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
            

        }
    }
}
