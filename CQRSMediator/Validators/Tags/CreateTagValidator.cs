using CQRSMediator.Commands.Tags.CreateTag;
using FluentValidation;

namespace CQRSMediator.Validators.Tags
{
    public class CreateTagValidator : AbstractValidator<CreateTagCommand>
    {
        public CreateTagValidator()
        {
            RuleFor(cmd => cmd.Name).NotEmpty().WithMessage("Name is required.");
        }
    }
}
