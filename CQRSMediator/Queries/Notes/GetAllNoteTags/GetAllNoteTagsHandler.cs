using CQRSMediator.Entities;
using CQRSMediator.Interfaces;
using MediatR;

namespace CQRSMediator.Queries.Notes.GetAllNoteTags
{
    public class GetAllNoteTagsHandler : IRequestHandler<GetAllNoteTagsQuery, IEnumerable<NoteTag>>
    {
        private readonly INoteRepository _noteRepository;

        public GetAllNoteTagsHandler(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }
        public async Task<IEnumerable<NoteTag>> Handle(GetAllNoteTagsQuery request, CancellationToken cancellationToken)
        {
            return await _noteRepository.GetAllNoteTags();
        }
    }
}
