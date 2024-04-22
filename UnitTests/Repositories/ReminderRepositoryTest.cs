using CQRSMediator;
using CQRSMediator.Entities;
using CQRSMediator.Repositories;
using Microsoft.EntityFrameworkCore;

namespace UnitTests.Repositories
{
    public class ReminderRepositoryTest
    {
        private readonly DbContextOptions<ApplicationDbContext> options;

        public ReminderRepositoryTest()
        {
            options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
        }

        [Fact]
        public async Task GetReminderById_ReturnsReminderFromInMemoryDatabase()
        {
            //Arrange
            using (var context = new ApplicationDbContext(options))
            {
                context.Reminders.Add(new Reminder
                {
                    Id = 1,
                    Text = "Test text",
                    Title = "test title",
                    DateToRemind = new(2021, 3, 4, 15, 0, 0)
                });
                context.SaveChanges();
            }

            //Act
            using (var context = new ApplicationDbContext(options))
            {
                var repository = new ReminderRepository(context);
                var result = await repository.GetReminderById(1);

                // Assert
                Assert.NotNull(result);
                Assert.Equal("Test text", result.Text);
                Assert.Equal("test title", result.Title);
                Assert.Equal(new DateTime(2021, 3, 4, 15, 0, 0), result.DateToRemind);
            }
        }

        [Fact]
        public async Task GetAllReminders_ReturnsRemindersFromInMemoryDatabase()
        {
            //Arrange
            using (var context = new ApplicationDbContext(options))
            {
                context.Reminders.Add(new Reminder
                {
                    Id = 1,
                    Text = "Test text",
                    Title = "test title",
                    DateToRemind = new(2021, 3, 4, 15, 0, 0)
                });
                context.SaveChanges();
            }

            //Act
            using (var context = new ApplicationDbContext(options))
            {
                var repository = new ReminderRepository(context);
                var result = await repository.GetAll();

                // Assert
                Assert.NotNull(result);
                Assert.Equal(1, result.Count());
            }
        }


        [Fact]
        public async Task CreateReminder_ReturnsReminderFromInMemoryDatabase()
        {
            //Arrange

            ////Act
            using (var context = new ApplicationDbContext(options))
            {
                var repository = new ReminderRepository(context);
                var result = await repository.Create(new Reminder
                {
                    Id = 3,
                    Text = "Test text",
                    Title = "test title",
                    DateToRemind = new(2021, 3, 4, 15, 0, 0)
                });

                // Assert
                Assert.NotNull(result);
                Assert.Equal(3, result.Id);
                Assert.Equal("Test text", result.Text);
                Assert.Equal("test title", result.Title);
                Assert.Equal(new DateTime(2021, 3, 4, 15, 0, 0), result.DateToRemind);
            }
        }

        [Fact]
        public async Task DeleteReminder_ReturnsIdFromInMemoryDatabase()
        {
            //Arrange
            using (var context = new ApplicationDbContext(options))
            {
                context.Reminders.Add(new Reminder
                {
                    Id = 1,
                    Text = "Test text",
                    Title = "test title",
                    DateToRemind = new(2021, 3, 4, 15, 0, 0)
                });
                context.SaveChanges();
            }

            ////Act
            using (var context = new ApplicationDbContext(options))
            {
                var repository = new ReminderRepository(context);
                var result = await repository.Delete(1);

                // Assert
                Assert.NotNull(result);
                Assert.Equal(1, result);
            }
        }

        [Fact]
        public async Task UpdateReminder_ReturnsReminderFromInMemoryDatabase()
        {
            //Arrange
            using (var context = new ApplicationDbContext(options))
            {
                context.Reminders.Add(new Reminder
                {
                    Id = 1,
                    Text = "Test text",
                    Title = "test title",
                    DateToRemind = new(2021, 3, 4, 15, 0, 0)
                });
                context.SaveChanges();
            }

            ////Act
            using (var context = new ApplicationDbContext(options))
            {
                var repository = new ReminderRepository(context);
                var result = await repository.Update(1, "new text", "new title", new DateTime(1999, 2, 2, 20, 20, 0));

                // Assert
                Assert.NotNull(result);
                Assert.Equal("new text", result.Text);
                Assert.Equal("new title", result.Title);
                Assert.Equal(new DateTime(1999, 2, 2, 20, 20, 0), result.DateToRemind);
            }
        }

        [Fact]
        public async Task BindReminder_ReturnsReminderTagsFromInMemoryDatabase()
        {
            //Arrange
            var reminder = new Reminder
            {
                Id = 1,
                Text = "Test text",
                Title = "test title",
                DateToRemind = new(2021, 3, 4, 15, 0, 0)
            };
            var tag1 = new Tag { Id = 1, Name = "Tag1" };
            var tag2 = new Tag { Id = 2, Name = "Tag2" };

            using (var context = new ApplicationDbContext(options))
            {
                context.Reminders.Add(reminder);
                context.Tags.AddRange(tag1, tag2);
                context.SaveChanges();
            }

            ////Act
            using (var context = new ApplicationDbContext(options))
            {
                var tagsIds = new List<int> { 1, 2 };
                var repository = new ReminderRepository(context);
                var result = await repository.Bind(1, tagsIds);

                // Assert
                Assert.NotNull(result);
                Assert.Equal(2, result.Count());
            }
        }

        [Fact]
        public async Task GetReminderTagById_ReturnsReminderTagFromInMemoryDatabase()
        {
            //Arrange
            using (var context = new ApplicationDbContext(options))
            {
                context.Reminders.Add(new Reminder
                {
                    Id = 1,
                    Text = "Test text",
                    Title = "test title",
                    DateToRemind = new(2021, 3, 4, 15, 0, 0)
                });
                context.Tags.Add(new Tag { Id = 4, Name = "name" });
                context.ReminderTags.Add(new ReminderTag { ReminderId = 1, TagId = 4 });
                context.SaveChanges();
            }

            //Act
            using (var context = new ApplicationDbContext(options))
            {
                var repository = new ReminderRepository(context);
                var result = await repository.GetReminderTagById(1);

                // Assert
                Assert.NotNull(result);
                Assert.Equal(1, result.ReminderId);
            }
        }

        [Fact]
        public async Task GetReminderTags_ReturnsReminderTagFromInMemoryDatabase()
        {
            //Arrange
            using (var context = new ApplicationDbContext(options))
            {
                context.Reminders.Add(new Reminder
                {
                    Id = 1,
                    Text = "Test text",
                    Title = "test title",
                    DateToRemind = new(2021, 3, 4, 15, 0, 0)
                });
                context.Tags.Add(new Tag { Id = 4, Name = "name" });
                context.ReminderTags.Add(new ReminderTag { ReminderId = 1, TagId = 4 });
                context.SaveChanges();
            }

            //Act
            using (var context = new ApplicationDbContext(options))
            {
                var repository = new ReminderRepository(context);
                var result = await repository.GetAll();

                // Assert
                Assert.NotNull(result);
                Assert.Equal(1, result.Count());
            }
        }
    }
}
