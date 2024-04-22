using CQRSMediator.Commands.Reminders.BindTags;
using FluentValidation;

namespace CQRSMediator.Validators.Reminders
{
    public class BindReminderValidator : AbstractValidator<BindTagsToReminderCommand>
    {
        public BindReminderValidator()
        {
            RuleFor(x => x.ReminderId).NotEmpty().WithMessage("ReminderId is required.");
            RuleFor(x => x.TagsIds)
                .NotEmpty().WithMessage("TagIds is required")
                .Must(x => x.All(tagId => tagId > 0)).WithMessage("TagIds must be greate than 0.");
        }
    }
}
