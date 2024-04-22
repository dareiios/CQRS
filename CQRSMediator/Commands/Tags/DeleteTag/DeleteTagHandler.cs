using CQRSMediator.Interfaces;
using FluentValidation;
using MediatR;

namespace CQRSMediator.Commands.Tags.DeleteTag
{
    public class DeleteTagHandler : IRequestHandler<DeleteTagCommand, int?>
    {
        private readonly ITagRepository _tagRepository;
        private readonly IValidator<DeleteTagCommand> _validator;


        public DeleteTagHandler(ITagRepository tagRepository, IValidator<DeleteTagCommand> validator)
        {
            _tagRepository = tagRepository;
            _validator = validator;
        }

        public async Task<int?> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request);
            return await _tagRepository.Delete(request.Id);
        }
    }
}
