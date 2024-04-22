using CQRSMediator.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediator
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Reminder> Reminders { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<NoteTag> NoteTags { get; set; }
        public DbSet<ReminderTag> ReminderTags { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NoteTag>().HasKey(u => new { u.NoteId, u.TagId });
            modelBuilder.Entity<ReminderTag>().HasKey(u => new { u.ReminderId, u.TagId });

        }
    }
}
