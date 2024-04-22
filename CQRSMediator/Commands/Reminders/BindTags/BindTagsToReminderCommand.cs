using CQRSMediator.Entities;
using MediatR;

namespace CQRSMediator.Commands.Reminders.BindTags
{
    public class BindTagsToReminderCommand : IRequest<IEnumerable<ReminderTag>>
    {
        public int ReminderId { get; set; }

        public IEnumerable<int> TagsIds { get; set; }
    }
}
