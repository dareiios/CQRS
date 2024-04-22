using MediatR;

namespace CQRSMediator.Commands.Notes.DeleteNote
{
    public class DeleteNoteCommand : IRequest<int?>
    {
        public int Id { get; set; }

    }
}
