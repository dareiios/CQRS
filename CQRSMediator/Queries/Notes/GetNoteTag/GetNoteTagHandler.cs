using CQRSMediator.Entities;
using CQRSMediator.Interfaces;
using FluentValidation;
using MediatR;

namespace CQRSMediator.Queries.Notes.GetNoteTag
{
    public class GetNoteTagHandler : IRequestHandler<GetNoteTagQuery, NoteTag?>
    {
        private readonly INoteRepository _noteRepository;
        private readonly IValidator<GetNoteTagQuery> _validator;

        public GetNoteTagHandler(INoteRepository noteRepository, IValidator<GetNoteTagQuery> validator)
        {
            _noteRepository = noteRepository;
            _validator = validator;
        }

        public async Task<NoteTag?> Handle(GetNoteTagQuery request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request);
            return await _noteRepository.GetNoteTagById(request.NoteId);
        }
    }
}
