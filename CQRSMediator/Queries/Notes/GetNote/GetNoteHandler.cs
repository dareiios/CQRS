using CQRSMediator.Entities;
using CQRSMediator.Interfaces;
using FluentValidation;
using MediatR;

namespace CQRSMediator.Queries.Notes.GetNote
{
    public class GetNoteHandler : IRequestHandler<GetNoteQuery, Note?>
    {
        private readonly INoteRepository _noteRepository;
        private readonly IValidator<GetNoteQuery> _validator;

        public GetNoteHandler(INoteRepository noteRepository, IValidator<GetNoteQuery> validator)
        {
            _noteRepository = noteRepository;
            _validator = validator;
        }

        public async Task<Note?> Handle(GetNoteQuery request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request);
            return await _noteRepository.GetNoteById(request.Id);
        }
    }
}
