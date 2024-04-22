using CQRSMediator.Entities;
using MediatR;

namespace CQRSMediator.Queries.Reminders.GetAllReminderTags
{
    public class GetAllReminderTagsQuery : IRequest<IEnumerable<ReminderTag>>
    {
    }
}
