using CQRSMediator.Entities;
using CQRSMediator.Interfaces;
using MediatR;

namespace CQRSMediator.Queries.Reminders.GetAllReminders
{
    public class GetAllRemindersHandler : IRequestHandler<GetAllRemindersQuery, IEnumerable<Reminder>>
    {
        private readonly IReminderRepository _reminderRepository;

        public GetAllRemindersHandler(IReminderRepository reminderRepository)
        {
            _reminderRepository = reminderRepository;
        }

        public async Task<IEnumerable<Reminder>> Handle(GetAllRemindersQuery request, CancellationToken cancellationToken)
        {
            return await _reminderRepository.GetAll();
        }
    }
}
