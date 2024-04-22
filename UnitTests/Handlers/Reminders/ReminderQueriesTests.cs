using CQRSMediator.Interfaces;
using CQRSMediator.Queries.Reminders.GetAllReminders;
using CQRSMediator.Queries.Reminders.GetReminder;
using FluentValidation;
using Moq;

namespace UnitTests.Handlers.Reminders
{
    public class ReminderQueriesTests
    {
        private readonly Mock<IReminderRepository> _mockRepository;

        public ReminderQueriesTests()
        {
            _mockRepository = new();
        }

        [Fact]
        public async Task GetReminderQuerieHandlerAsync()
        {
            //Arrange
            var query = new GetReminderQuery() { Id = 3 };

            Mock<IValidator<GetReminderQuery>> _mockValidator = new();

            var handler = new GetReminderHandler(_mockRepository.Object, _mockValidator.Object);

            //Act
            var result = await handler.Handle(query, default);

            //Assert
            _mockRepository.Verify(
                x => x.GetReminderById(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task GetAllRemindersQuerieHandlerAsync()
        {
            //Arrange
            var query = new GetAllRemindersQuery() { };

            var handler = new GetAllRemindersHandler(_mockRepository.Object);

            //Act
            var result = await handler.Handle(query, default);
            var resList = result.ToList();

            //Assert
            _mockRepository.Verify(
                x => x.GetAll(), Times.Once);
        }
    }
}
