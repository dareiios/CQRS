using CQRSMediator.Interfaces;
using CQRSMediator.Queries.Notes.GetAllTags;
using CQRSMediator.Queries.Tags.GetTag;
using FluentValidation;
using Moq;

namespace UnitTests.Handlers.Tags
{
    public class TagQueriesTests
    {
        private readonly Mock<ITagRepository> _mockRepository;

        public TagQueriesTests()
        {
            _mockRepository = new();
        }

        [Fact]
        public async Task GetTagQuerieHandlerAsync()
        {
            //Arrange
            var query = new GetTagQuery() { Id = 3 };

            Mock<IValidator<GetTagQuery>> _mockValidator = new();

            var handler = new GetTagHandler(_mockRepository.Object, _mockValidator.Object);

            //Act
            var result = await handler.Handle(query, default);

            //Assert
            _mockRepository.Verify(
                x => x.GetTagById(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task GetAllTagsQuerieHandlerAsync()
        {
            //Arrange
            var query = new GetAllTagsQuery() { };

            var handler = new GetAllTagsHandler(_mockRepository.Object);

            //Act
            var result = await handler.Handle(query, default);

            //Assert
            _mockRepository.Verify(
                x => x.GetAll(), Times.Once);
        }
    }
}
