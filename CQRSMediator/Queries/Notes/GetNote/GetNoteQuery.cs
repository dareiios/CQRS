using CQRSMediator.Entities;
using MediatR;

namespace CQRSMediator.Queries.Notes.GetNote
{
    public class GetNoteQuery : IRequest<Note>
    {
        public int Id { get; set; }
    }
}
