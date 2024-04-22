using CQRSMediator.Queries.Reminders.GetReminderTag;
using FluentValidation;

namespace CQRSMediator.Validators.Reminders
{
    public class GetReminderTagByIdValidator : AbstractValidator<GetReminderTagQuery>
    {
        public GetReminderTagByIdValidator()
        {
            RuleFor(x => x.ReminderId).NotEmpty().WithMessage("ReminderId is required.")
                .GreaterThan(0).WithMessage("ReminderId must be greater than 0.");
            

        }
    }
}
