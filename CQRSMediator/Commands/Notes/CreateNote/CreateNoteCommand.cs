using CQRSMediator.Entities;
using MediatR;

namespace CQRSMediator.Commands.Notes.CreateNote
{
    public class CreateNoteCommand : IRequest<Note>
    {
        public string Title { get; set; }
        public string Text { get; set; }

    }
}
