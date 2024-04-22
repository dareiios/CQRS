using CQRSMediator.Entities;
using MediatR;

namespace CQRSMediator.Queries.Notes.GetAllNoteTags
{
    public class GetAllNoteTagsQuery : IRequest<IEnumerable<NoteTag>>
    {
    }
}
