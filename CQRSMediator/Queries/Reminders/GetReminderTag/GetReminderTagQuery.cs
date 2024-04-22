using CQRSMediator.Entities;
using MediatR;

namespace CQRSMediator.Queries.Reminders.GetReminderTag
{
    public class GetReminderTagQuery : IRequest<ReminderTag?>
    {
        public int ReminderId { get; set; }
    }
}
