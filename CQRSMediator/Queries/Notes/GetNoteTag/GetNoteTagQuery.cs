using CQRSMediator.Entities;
using MediatR;

namespace CQRSMediator.Queries.Notes.GetNoteTag
{
    public class GetNoteTagQuery : IRequest<NoteTag?>
    {
        public int NoteId { get; set; }
    }
}

