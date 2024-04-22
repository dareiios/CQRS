using CQRSMediator.Entities;
using CQRSMediator.Interfaces;
using FluentValidation;
using MediatR;

namespace CQRSMediator.Commands.Notes.BindTags
{
    public class BindTagsToNoteHandler : IRequestHandler<BindTagsToNoteCommand, IEnumerable<NoteTag>>
    {
        private readonly INoteRepository _noteRepository;
        private readonly IValidator<BindTagsToNoteCommand> _validator;

        public BindTagsToNoteHandler(INoteRepository noteRepository, IValidator<BindTagsToNoteCommand> validator)
        {
            _noteRepository = noteRepository;
            _validator = validator;
        }

        public async Task<IEnumerable<NoteTag>> Handle(BindTagsToNoteCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request);
            return await _noteRepository.Bind(request.NoteId, request.TagsIds);
        }
    }
}
