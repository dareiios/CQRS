using CQRSMediator.Entities;
using MediatR;

namespace CQRSMediator.Queries.Reminders.GetAllReminders
{
    public class GetAllRemindersQuery : IRequest<IEnumerable<Reminder>>
    {
    }
}
