using CQRSMediator.Entities;
using CQRSMediator.Interfaces;
using MediatR;

namespace CQRSMediator.Queries.Reminders.GetAllReminderTags
{
    public class GetAllReminderTagsHandler : IRequestHandler<GetAllReminderTagsQuery, IEnumerable<ReminderTag>>
    {
        private readonly IReminderRepository _reminderRepository;

        public GetAllReminderTagsHandler(IReminderRepository reminderRepository)
        {
            _reminderRepository = reminderRepository;
        }

        public async Task<IEnumerable<ReminderTag>> Handle(GetAllReminderTagsQuery request, CancellationToken cancellationToken)
        {
            return await _reminderRepository.GetAllReminderTags();
        }
    }
}
