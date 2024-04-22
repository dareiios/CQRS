using CQRSMediator.Interfaces;
using CQRSMediator.Queries.Notes.GetAllNotes;
using CQRSMediator.Queries.Notes.GetNote;
using FluentValidation;
using Moq;

namespace UnitTests.Handlers.Notes
{
    public class NoteQueriesTests
    {
        private readonly Mock<INoteRepository> _mockRepository;

        public NoteQueriesTests()
        {
            _mockRepository = new();
        }

        [Fact]
        public async Task GetNoteQuerieHandlerAsync()
        {
            //Arrange
            var query = new GetNoteQuery() { Id = 3 };

            Mock<IValidator<GetNoteQuery>> _mockValidator = new();
            var handler = new GetNoteHandler(_mockRepository.Object, _mockValidator.Object);

            //Act
            var result = await handler.Handle(query, default);

            //Assert
            _mockRepository.Verify(
                x => x.GetNoteById(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task GetAllNotesQuerieHandlerAsync()
        {
            //Arrange
            var query = new GetAllNotesQuery() { };


            var handler = new GetAllNotesHandler(_mockRepository.Object);

            //Act
            var result = await handler.Handle(query, default);
            var resList = result.ToList();

            //Assert
            _mockRepository.Verify(
                x => x.GetAll(), Times.Once);
        }
    }
}
