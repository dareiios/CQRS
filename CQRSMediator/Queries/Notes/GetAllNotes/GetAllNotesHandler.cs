using CQRSMediator.Entities;
using CQRSMediator.Interfaces;
using MediatR;

namespace CQRSMediator.Queries.Notes.GetAllNotes
{
    public class GetAllNotesHandler : IRequestHandler<GetAllNotesQuery, IEnumerable<Note>>
    {

        private readonly INoteRepository _noteRepository;

        public GetAllNotesHandler(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<IEnumerable<Note>> Handle(GetAllNotesQuery request, CancellationToken cancellationToken)
        {
            return await _noteRepository.GetAll();
        }

    }
}
