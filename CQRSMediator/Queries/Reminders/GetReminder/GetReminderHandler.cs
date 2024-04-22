using CQRSMediator.Entities;
using CQRSMediator.Interfaces;
using FluentValidation;
using MediatR;

namespace CQRSMediator.Queries.Reminders.GetReminder
{
    public class GetReminderHandler : IRequestHandler<GetReminderQuery, Reminder?>
    {
        private readonly IReminderRepository _reminderRepository;
        private readonly IValidator<GetReminderQuery> _validator;

        public GetReminderHandler(IReminderRepository reminderRepository, IValidator<GetReminderQuery> validator)
        {
            _reminderRepository = reminderRepository;
            _validator = validator;
        }

        public async Task<Reminder?> Handle(GetReminderQuery request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request);
            return await _reminderRepository.GetReminderById(request.Id);
        }
    }
}
