using CQRSMediator.Entities;
using MediatR;

namespace CQRSMediator.Commands.Notes.UpdateNote
{
    public class UpdateNoteCommand :IRequest<Note>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
