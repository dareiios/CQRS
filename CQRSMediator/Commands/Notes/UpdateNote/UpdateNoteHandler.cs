using CQRSMediator.Entities;
using CQRSMediator.Interfaces;
using FluentValidation;
using MediatR;

namespace CQRSMediator.Commands.Notes.UpdateNote
{
    public class UpdateNoteHandler : IRequestHandler<UpdateNoteCommand, Note>
    {
        private readonly INoteRepository _noteRepository;
        private readonly IValidator<UpdateNoteCommand> _validator;

        public UpdateNoteHandler(INoteRepository noteRepository, IValidator<UpdateNoteCommand> validator)
        {
            _noteRepository = noteRepository;
            _validator = validator;
        }

        public async Task<Note> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request);
            return await _noteRepository.Update(request.Id, request.Text, request.Title);

        }
    }
}
