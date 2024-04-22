using CQRSMediator.Entities;
using MediatR;

namespace CQRSMediator.Commands.Reminders.CreateReminder
{
    public class CreateReminderCommand : IRequest<Reminder>
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime? DateToRemind { get; set; }
    }
}
