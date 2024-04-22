using CQRSMediator.Entities;
using CQRSMediator.Interfaces;
using FluentValidation;
using MediatR;

namespace CQRSMediator.Commands.Reminders.CreateReminder
{
    public class CreateReminderHandler : IRequestHandler<CreateReminderCommand, Reminder>
    {
        private readonly IReminderRepository _reminderRepository;
        private readonly IValidator<CreateReminderCommand> _validator;

        public CreateReminderHandler(IReminderRepository reminderRepository, IValidator<CreateReminderCommand> validator)
        {
            _reminderRepository = reminderRepository;
            _validator = validator;
        }

        public async Task<Reminder> Handle(CreateReminderCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request);

            var reminder = new Reminder()
            {
                Title = request.Title,
                Text = request.Text,
                DateToRemind = request.DateToRemind
            };

            return await _reminderRepository.Create(reminder);
        }
    }
}
