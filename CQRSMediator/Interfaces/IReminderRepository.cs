using CQRSMediator.Entities;

namespace CQRSMediator.Interfaces
{
    public interface IReminderRepository
    {
        Task<Reminder?> GetReminderById(int id);
        Task<IEnumerable<Reminder>> GetAll();
        Task<Reminder> Create(Reminder reminder);
        Task<Reminder?> Update(int id, string text, string title, DateTime? date);
        Task<int?> Delete(int id);
        Task<IEnumerable<ReminderTag>?> Bind(int reminderId, IEnumerable<int> tagsIds);
        Task<ReminderTag?> GetReminderTagById(int reminderId);
        Task<IEnumerable<ReminderTag>> GetAllReminderTags();
    }
}
