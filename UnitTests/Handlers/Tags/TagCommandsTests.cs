using CQRSMediator.Commands.Tags.CreateTag;
using CQRSMediator.Commands.Tags.DeleteTag;
using CQRSMediator.Commands.Tags.UpdateTag;
using CQRSMediator.Entities;
using CQRSMediator.Interfaces;
using FluentValidation;
using Moq;

namespace UnitTests.Handlers.Tags
{
    public class TagCommandsTests
    {
        private readonly Mock<ITagRepository> _mockRepository;

        public TagCommandsTests()
        {
            _mockRepository = new();
        }

        [Fact]
        public async Task CreateTagCommandHandlerAsync()
        {
            //Arrange
            var command = new CreateTagCommand() { Name = "Name1" };

            Mock<IValidator<CreateTagCommand>> _mockValidator = new();

            var handler = new CreateTagHandler(_mockRepository.Object, _mockValidator.Object);

            //Act
            var result = await handler.Handle(command, default);

            //Assert
            _mockRepository.Verify(
                x => x.Create(It.IsAny<Tag>()), Times.Once);
        }

        [Fact]
        public async Task DeleteTagCommandHandlerAsync()
        {
            //Arrange
            var command = new DeleteTagCommand() { Id = 3 };

            Mock<IValidator<DeleteTagCommand>> _mockValidator = new();
            var handler = new DeleteTagHandler(_mockRepository.Object, _mockValidator.Object);

            //Act
            var result = await handler.Handle(command, default);

            //Assert
            _mockRepository.Verify(
                x => x.Delete(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task UpdateTagCommandHandlerAsync()
        {
            //Arrange
            var command = new UpdateTagCommand() { Id = 3, Name = "kiki1" };

            Mock<IValidator<UpdateTagCommand>> _mockValidator = new();
            var handler = new UpdateTagHandler(_mockRepository.Object, _mockValidator.Object);

            //Act
            var result = await handler.Handle(command, default);

            //Assert
            _mockRepository.Verify(
                x => x.Update(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
        }


    }
}
