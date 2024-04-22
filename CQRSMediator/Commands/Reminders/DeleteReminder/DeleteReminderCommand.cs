using MediatR;

namespace CQRSMediator.Commands.Reminders.DeleteReminder
{
    public class DeleteReminderCommand : IRequest<int?>
    {
        public int Id { get; set; }
    }
}
