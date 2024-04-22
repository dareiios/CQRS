using CQRSMediator.Commands.Notes.BindTags;
using CQRSMediator.Commands.Notes.CreateNote;
using CQRSMediator.Commands.Notes.DeleteNote;
using CQRSMediator.Commands.Notes.UpdateNote;
using CQRSMediator.Entities;
using CQRSMediator.Interfaces;
using FluentValidation;
using Moq;

namespace UnitTests.Handlers.Notes
{
    public class NoteCommandsTests
    {
        private readonly Mock<INoteRepository> _mockRepository;

        public NoteCommandsTests()
        {
            _mockRepository = new();
        }

        [Fact]
        public async Task CreateNoteCommandHandlerAsync()
        {
            //Arrange
            var command = new CreateNoteCommand() { Text = "kiki1", Title = "kiki2" };

            Mock<IValidator<CreateNoteCommand>> _mockValidator = new();

            var handler = new CreateNoteHandler(_mockRepository.Object, _mockValidator.Object);

            //Act
            var result = await handler.Handle(command, default);

            //Assert
           
            _mockRepository.Verify(
                x => x.Create(It.IsAny<Note>()), Times.Once);
        }

        [Fact]
        public async Task DeleteNoteCommandHandlerAsync()
        {
            //Arrange
            var command = new DeleteNoteCommand() { Id = 3 };


            Mock<IValidator<DeleteNoteCommand>> _mockValidator = new();
            var handler = new DeleteNoteHandler(_mockRepository.Object, _mockValidator.Object);

            //Act
            var result = await handler.Handle(command, default);

            //Assert
            _mockRepository.Verify(
                x => x.Delete(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task UpdateNoteCommandHandlerAsync()
        {
            //Arrange
            var command = new UpdateNoteCommand() { Id = 3, Text = "kiki1", Title = "kiki2" };

            Mock<IValidator<UpdateNoteCommand>> _mockValidator = new();
            var handler = new UpdateNoteHandler(_mockRepository.Object, _mockValidator.Object);

            //Act
            var result = await handler.Handle(command, default);

            //Assert
            _mockRepository.Verify(
                x => x.Update(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task BindTagsToNoteCommandHandlerAsync()
        {
            //Arrange
            var tagsIds = new List<int> { 1, 2, 3 };
            var command = new BindTagsToNoteCommand() { NoteId = 2, TagsIds = tagsIds };

            Mock<IValidator<BindTagsToNoteCommand>> validatorMock = new();
            var handler = new BindTagsToNoteHandler(_mockRepository.Object, validatorMock.Object);

            //Act
            await handler.Handle(command, default);

            _mockRepository.Verify(x
                => x.Bind(2, It.Is<IEnumerable<int>>(x => x.SequenceEqual(tagsIds))),
                    Times.Once);

        }
    }
}