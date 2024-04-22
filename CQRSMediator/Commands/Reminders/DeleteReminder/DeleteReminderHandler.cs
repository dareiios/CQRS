using CQRSMediator.Interfaces;
using FluentValidation;
using MediatR;

namespace CQRSMediator.Commands.Reminders.DeleteReminder
{
    public class DeleteReminderHandler : IRequestHandler<DeleteReminderCommand, int?>
    {
        private readonly IReminderRepository _reminderRepository;
        private readonly IValidator<DeleteReminderCommand> _validator;

        public DeleteReminderHandler(IReminderRepository reminderRepository, IValidator<DeleteReminderCommand> validator)
        {
            _reminderRepository = reminderRepository;
            _validator = validator;
        }

        public async Task<int?> Handle(DeleteReminderCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request);
            return await _reminderRepository.Delete(request.Id);
        }
    }
}
