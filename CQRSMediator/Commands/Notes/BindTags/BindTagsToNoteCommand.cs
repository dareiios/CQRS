using CQRSMediator.Entities;
using MediatR;

namespace CQRSMediator.Commands.Notes.BindTags
{
    public class BindTagsToNoteCommand :IRequest<IEnumerable<NoteTag>?>
    {
        public int NoteId { get; set; }

        public IEnumerable<int> TagsIds { get; set; }
    }
}
