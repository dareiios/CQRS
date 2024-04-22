using CQRSMediator.Entities;
using CQRSMediator.Interfaces;
using FluentValidation;
using MediatR;

namespace CQRSMediator.Commands.Notes.CreateNote
{
    public class CreateNoteHandler : IRequestHandler<CreateNoteCommand, Note>
    {
        private readonly INoteRepository _noteRepository;
        private readonly IValidator<CreateNoteCommand> _validator;

        public CreateNoteHandler(INoteRepository noteRepository, IValidator<CreateNoteCommand> validator)
        {
            _noteRepository = noteRepository;
            _validator = validator;
        }

        public async Task<Note> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request);

            var note = new Note()
            {
                Title = request.Title,
                Text = request.Text
            };

            return await _noteRepository.Create(note);
        }

    }
}
