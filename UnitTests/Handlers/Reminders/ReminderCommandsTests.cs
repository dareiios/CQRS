using CQRSMediator.Commands.Reminders.BindTags;
using CQRSMediator.Commands.Reminders.CreateReminder;
using CQRSMediator.Commands.Reminders.DeleteReminder;
using CQRSMediator.Commands.Reminders.UpdateReminder;
using CQRSMediator.Entities;
using CQRSMediator.Interfaces;
using FluentValidation;
using Moq;

namespace UnitTests.Handlers.Reminders
{
    public class ReminderCommandsTests
    {
        private readonly Mock<IReminderRepository> _mockRepository;

        public ReminderCommandsTests()
        {
            _mockRepository = new();
        }


        [Fact]
        public async Task CreateReminderCommandHandlerAsync()
        {
            //Arrange
            var command = new CreateReminderCommand() 
            { 
                Text = "kiki1", Title = "kiki2", DateToRemind = new DateTime(2001, 7, 2, 14, 15, 0)
            };

            Mock<IValidator<CreateReminderCommand>> _mockValidator = new();
            var handler = new CreateReminderHandler(_mockRepository.Object, _mockValidator.Object);

            //Act
            var result = await handler.Handle(command, default);

            //Assert
            _mockRepository.Verify(
                x => x.Create(It.IsAny<Reminder>()), Times.Once);
        }

        [Fact]
        public async Task DeleteReminderCommandHandlerAsync()
        {
            //Arrange
            var command = new DeleteReminderCommand() { Id = 3 };

            Mock<IValidator<DeleteReminderCommand>> _mockValidator = new();
            var handler = new DeleteReminderHandler(_mockRepository.Object, _mockValidator.Object);

            //Act
            var result = await handler.Handle(command, default);

            //Assert
            _mockRepository.Verify(
                x => x.Delete(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task UpdateReminderCommandHandlerAsync()
        {
            //Arrange
            var command = new UpdateReminderCommand() { Id = 3, Text = "kiki1", Title = "kiki2", DateToRemind = new DateTime(2001, 7, 2, 14, 15, 0) };

            Mock<IValidator<UpdateReminderCommand>> _mockValidator = new();
            var handler = new UpdateReminderHandler(_mockRepository.Object, _mockValidator.Object);

            //Act
            var result = await handler.Handle(command, default);

            //Assert
            _mockRepository.Verify(
                x => x.Update(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>()), Times.Once);
        }

        [Fact]
        public async Task BindTagsToReminderCommandHandlerAsync()
        {
            //Arrange
            var tagsIds = new List<int> { 1, 2, 3 };
            var command = new BindTagsToReminderCommand() { ReminderId = 2, TagsIds = tagsIds };

         

            Mock<IValidator<BindTagsToReminderCommand>> _mockValidator = new();
            var handler = new BindTagsToReminderHandler(_mockRepository.Object, _mockValidator.Object);

            //Act
            var result = await handler.Handle(command, default);

            //Assert
            
            _mockRepository.Verify(
                x => x.Bind(It.IsAny<int>(), It.IsAny<IEnumerable<int>>()), Times.Once);
        }

    }
}
