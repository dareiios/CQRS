using CQRSMediator;
using CQRSMediator.Entities;
using CQRSMediator.Repositories;
using Microsoft.EntityFrameworkCore;

namespace UnitTests.Repositories
{
    public class TagRepositoryTests
    {
        private readonly DbContextOptions<ApplicationDbContext> options;

        public TagRepositoryTests()
        {
            options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
        }

        [Fact]
        public async Task GetTagById_ReturnsTagFromInMemoryDatabase()
        {
            //Arrange
            using (var context = new ApplicationDbContext(options))
            {
                context.Tags.Add(new Tag
                {
                    Id = 1,
                    Name = "Test name"
                });
                context.SaveChanges();
            }

            //Act
            using (var context = new ApplicationDbContext(options))
            {
                var repository = new TagRepository(context);
                var result = await repository.GetTagById(1);

                // Assert
                Assert.NotNull(result);
                Assert.Equal("Test name", result.Name);
            }
        }

        [Fact]
        public async Task GetAllTags_ReturnsTagsFromInMemoryDatabase()
        {
            //Arrange
            using (var context = new ApplicationDbContext(options))
            {
                context.Tags.Add(new Tag
                {
                    Id = 1,
                    Name = "Test name"
                });
                context.SaveChanges();
            }

            //Act
            using (var context = new ApplicationDbContext(options))
            {
                var repository = new TagRepository(context);
                var result = await repository.GetAll();

                // Assert
                Assert.NotNull(result);
            }
        }

        [Fact]
        public async Task CreateTag_ReturnsTagFromInMemoryDatabase()
        {
            //Arrange

            ////Act
            using (var context = new ApplicationDbContext(options))
            {
                var repository = new TagRepository(context);
                var result = await repository.Create(new Tag { Id = 3, Name = "Test name" });

                // Assert
                Assert.NotNull(result);
                Assert.Equal(3, result.Id);
                Assert.Equal("Test name", result.Name);
            }
        }

        [Fact]
        public async Task DeleteTag_ReturnsIdFromInMemoryDatabase()
        {
            //Arrange
            using (var context = new ApplicationDbContext(options))
            {
                context.Tags.Add(new Tag { Id = 4, Name = "Test name" });
                context.SaveChanges();
            }

            ////Act
            using (var context = new ApplicationDbContext(options))
            {
                var repository = new TagRepository(context);
                var result = await repository.Delete(4);

                // Assert
                Assert.NotNull(result);
                Assert.Equal(4, result);
            }
        }

        [Fact]
        public async Task UpdateTag_ReturnsTagFromInMemoryDatabase()
        {
            //Arrange
            using (var context = new ApplicationDbContext(options))
            {
                context.Tags.Add(new Tag { Id = 4, Name = "Test name" });
                context.SaveChanges();
            }

            ////Act
            using (var context = new ApplicationDbContext(options))
            {
                var repository = new TagRepository(context);
                var result = await repository.Update(4, "new name");

                // Assert
                Assert.NotNull(result);
                Assert.Equal("new name", result.Name);
            }
        }
    }
}
