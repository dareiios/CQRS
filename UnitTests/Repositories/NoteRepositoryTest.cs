using CQRSMediator;
using CQRSMediator.Entities;
using CQRSMediator.Repositories;
using Microsoft.EntityFrameworkCore;

namespace UnitTests.Repositories
{
    public class NoteRepositoryTest
    {
        private readonly DbContextOptions<ApplicationDbContext> options;

        public NoteRepositoryTest()
        {
            options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
        }

        [Fact]
        public void GetNoteById_ReturnsNoteFromInMemoryDatabase()
        {
            //Arrange
            using (var context = new ApplicationDbContext(options))
            {
                context.Notes.Add(new Note { Id = 1, Text = "Test text", Title = "test title" });
                context.SaveChanges();
            }

            //Act
            using (var context = new ApplicationDbContext(options))
            {
                var repository = new NoteRepository(context);
                var result = repository.GetNoteById(1);

                // Assert
                Assert.NotNull(result);
                Assert.Equal("Test text", result.Result?.Text);
                Assert.Equal("test title", result.Result?.Title);
            }
        }

        [Fact]
        public async Task GetAllNotes_ReturnsNotesFromInMemoryDatabase()
        {
            //Arrange
            using (var context = new ApplicationDbContext(options))
            {
                context.Notes.Add(new Note { Id = 2, Text = "Test text", Title = "test title" });
                context.SaveChanges();
            }

            //Act
            using (var context = new ApplicationDbContext(options))
            {
                var repository = new NoteRepository(context);
                var result = await repository.GetAll();

                // Assert
                Assert.NotNull(result);
                Assert.Equal(1, result.Count());
            }
        }

        [Fact]
        public async Task CreateNote_ReturnsNoteFromInMemoryDatabase()
        {
            //Arrange
            
            ////Act
            using (var context = new ApplicationDbContext(options))
            {
                var repository = new NoteRepository(context);
                var result = await repository.Create(new Note { Id = 3, Text = "Test text", Title = "test title" });

                // Assert
                Assert.NotNull(result);
                Assert.Equal(3, result.Id);
                Assert.Equal("Test text", result.Text);
                Assert.Equal("test title", result.Title);
            }
        }

        [Fact]
        public async Task DeleteNote_ReturnsIdFromInMemoryDatabase()
        {
            //Arrange
            using (var context = new ApplicationDbContext(options))
            {
                context.Notes.Add(new Note { Id = 4, Text = "Test text", Title = "test title" });
                context.SaveChanges();
            }

            ////Act
            using (var context = new ApplicationDbContext(options))
            {
                var repository = new NoteRepository(context);
                var result = await repository.Delete(4);

                // Assert
                Assert.NotNull(result);
                Assert.Equal(4, result);
            }
        }

        [Fact]
        public async Task UpdateNote_ReturnsNoteFromInMemoryDatabase()
        {
            //Arrange
            using (var context = new ApplicationDbContext(options))
            {
                context.Notes.Add(new Note { Id = 4, Text = "Test text", Title = "test title" });
                context.SaveChanges();
            }

            ////Act
            using (var context = new ApplicationDbContext(options))
            {
                var repository = new NoteRepository(context);
                var result = await repository.Update(4, "new text", "new title");

                // Assert
                Assert.NotNull(result);
                Assert.Equal("new text", result.Text);
                Assert.Equal("new title", result.Title);
            }
        }

        [Fact]
        public async Task BindNote_ReturnsNoteTagsFromInMemoryDatabase()
        {
            //Arrange
            var note = new Note { Id = 4, Text = "Test text", Title = "test title" };
            var tag1 = new Tag { Id = 1, Name = "Tag1" };
            var tag2 = new Tag { Id = 2, Name = "Tag2" };

            using (var context = new ApplicationDbContext(options))
            {
                context.Notes.Add(note);
                context.Tags.AddRange(tag1, tag2);
                context.SaveChanges();
            }

            ////Act
            using (var context = new ApplicationDbContext(options))
            {
                var tagsIds = new List<int> { 1, 2 };
                var repository = new NoteRepository(context);
                var result = await repository.Bind(4, tagsIds);

                // Assert
                Assert.NotNull(result);
                Assert.Equal(2, result.Count());
            }
        }

        [Fact]
        public async Task GetNoteTagById_ReturnsNoteTagFromInMemoryDatabase()
        {
            //Arrange
            using (var context = new ApplicationDbContext(options))
            {
                context.Notes.Add(new Note { Id=3, Text="text", Title="title"});
                context.Tags.Add(new Tag { Id = 4, Name = "name" });
                context.NoteTags.Add(new NoteTag { NoteId=3, TagId=4 });
                context.SaveChanges();
            }

            //Act
            using (var context = new ApplicationDbContext(options))
            {
                var repository = new NoteRepository(context);
                var result =await repository.GetNoteTagById(3);

                // Assert
                Assert.NotNull(result);
                Assert.Equal(3, result.NoteId);
            }
        }

        [Fact]
        public async Task GetNoteTags_ReturnsNoteTagFromInMemoryDatabase()
        {
            //Arrange
            using (var context = new ApplicationDbContext(options))
            {

                context.Notes.Add(new Note { Id = 3, Text = "text", Title = "title" });
                context.Tags.Add(new Tag { Id = 4, Name = "name" });
                context.NoteTags.Add(new NoteTag { NoteId = 3, TagId = 4 });
                context.SaveChanges();
            }

            //Act
            using (var context = new ApplicationDbContext(options))
            {
                var repository = new NoteRepository(context);
                var result = await repository.GetAll();

                // Assert
                Assert.NotNull(result);
                Assert.Equal(1, result.Count());
            }
        }
    }
}
