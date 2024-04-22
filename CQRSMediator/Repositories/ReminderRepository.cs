using CQRSMediator.Entities;
using CQRSMediator.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediator.Repositories
{
    public class ReminderRepository : IReminderRepository
    {
        private readonly ApplicationDbContext _context;

        public ReminderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ReminderTag>?> Bind(int reminderId, IEnumerable<int> tagsIds)
        {
            var reminder = await _context.Reminders.FirstOrDefaultAsync(x => x.Id == reminderId);
            if (reminder == null)
                return null;

            List<ReminderTag> reminderTagsList = new();
            foreach (var id in tagsIds)
            {
                var tag = await _context.Tags.FirstOrDefaultAsync(x => x.Id == id);
                if (tag == null)
                    return null;

                var reminderTag = new ReminderTag()
                {
                    Reminder = reminder,
                    Tag = tag
                };

                reminderTagsList.Add(reminderTag);
            }

            await _context.ReminderTags.AddRangeAsync(reminderTagsList);
            await _context.SaveChangesAsync();
            return reminderTagsList;
        }

        public async Task<Reminder> Create(Reminder reminder)
        {
            await _context.Reminders.AddAsync(reminder);
            await _context.SaveChangesAsync();
            return reminder;
        }

        public async Task<int?> Delete(int id)
        {
            var reminder = await _context.Reminders.FirstOrDefaultAsync(x => x.Id == id);

            if (reminder != null)
            {
                _context.Reminders.Remove(reminder);
                await _context.SaveChangesAsync();
                return reminder.Id;
            }

            return null;
        }

        public async Task<IEnumerable<Reminder>> GetAll()
        {
            var reminders = await _context.Reminders.ToListAsync();
            return reminders;
        }

        public async Task<Reminder?> GetReminderById(int id)
        {
            var reminder = await _context.Reminders.FirstOrDefaultAsync(x => x.Id == id);
            return reminder;
        }

        public async Task<Reminder?> Update(int id, string text, string title, DateTime? date)
        {
            var reminder = _context.Reminders.FirstOrDefault(x => x.Id == id);
            if (reminder != null)
            {
                reminder.Text = text;
                reminder.Title = title;
                reminder.DateToRemind = date;
                _context.Reminders.Update(reminder);
                _context.SaveChanges();
            }
            return reminder;
        }

        public async Task<IEnumerable<ReminderTag>> GetAllReminderTags()
        {
            return await _context.ReminderTags.Include(x => x.Reminder).Include(x => x.Tag).ToListAsync();
        }

        public async Task<ReminderTag?> GetReminderTagById(int reminderId)
        {
            return await _context.ReminderTags.Include(x => x.Reminder).Include(x => x.Tag).FirstOrDefaultAsync(x => x.ReminderId == reminderId);
        }
    }
}
