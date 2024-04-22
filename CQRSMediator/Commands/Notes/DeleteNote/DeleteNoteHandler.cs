using CQRSMediator.Interfaces;
using FluentValidation;
using MediatR;

namespace CQRSMediator.Commands.Notes.DeleteNote
{
    public class DeleteNoteHandler : IRequestHandler<DeleteNoteCommand, int?>
    {
        private readonly INoteRepository _noteRepository;
        private readonly IValidator<DeleteNoteCommand> _validator;

        public DeleteNoteHandler(INoteRepository noteRepository, IValidator<DeleteNoteCommand> validator)
        {
            _noteRepository = noteRepository;
            _validator = validator;
        }

        public async Task<int?> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request);

            return await _noteRepository.Delete(request.Id);
        }
    }
}
