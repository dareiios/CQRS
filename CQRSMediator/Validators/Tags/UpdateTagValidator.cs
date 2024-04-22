using CQRSMediator.Commands.Tags.UpdateTag;
using FluentValidation;

namespace CQRSMediator.Validators.Tags
{
    public class UpdateTagValidator : AbstractValidator<UpdateTagCommand>
    {
        public UpdateTagValidator()
        {
            RuleFor(cmd => cmd.Id).NotEmpty().WithMessage("Id is required.");
            RuleFor(cmd => cmd.Name).NotEmpty().WithMessage("Name is required.");
        }
    }
}
