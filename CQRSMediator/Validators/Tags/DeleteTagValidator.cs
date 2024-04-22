using CQRSMediator.Commands.Tags.DeleteTag;
using FluentValidation;

namespace CQRSMediator.Validators.Tags
{
    public class DeleteTagValidator : AbstractValidator<DeleteTagCommand>
    {
        public DeleteTagValidator()
        {
            RuleFor(cmd => cmd.Id).NotEmpty().WithMessage("Id is required.")
                 .GreaterThan(0).WithMessage("Id must be greater than 0.");
           
        }
    }
}
