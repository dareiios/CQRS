using CQRSMediator.Entities;
using MediatR;

namespace CQRSMediator.Commands.Reminders.UpdateReminder
{
    public class UpdateReminderCommand : IRequest<Reminder?>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime? DateToRemind { get; set; }
    }
}
