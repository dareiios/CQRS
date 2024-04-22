using CQRSMediator.Entities;
using CQRSMediator.Interfaces;
using FluentValidation;
using MediatR;

namespace CQRSMediator.Commands.Reminders.UpdateReminder
{
    public class UpdateReminderHandler : IRequestHandler<UpdateReminderCommand, Reminder?>
    {
        private readonly IReminderRepository _reminderRepository;
        private readonly IValidator<UpdateReminderCommand> _validator;

        public UpdateReminderHandler(IReminderRepository reminderRepository, IValidator<UpdateReminderCommand> validator)
        {
            _reminderRepository = reminderRepository;
            _validator = validator;
        }

        public async Task<Reminder?> Handle(UpdateReminderCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request);
            return await _reminderRepository.Update(request.Id, request.Text, request.Title, request.DateToRemind);

        }
    }
}
