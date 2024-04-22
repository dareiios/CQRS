using CQRSMediator.Entities;
using MediatR;

namespace CQRSMediator.Queries.Reminders.GetReminder
{
    public class GetReminderQuery:IRequest<Reminder>
    {
        public int Id { get; set; }
    }
}
