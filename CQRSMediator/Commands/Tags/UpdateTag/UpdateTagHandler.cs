using CQRSMediator.Entities;
using CQRSMediator.Interfaces;
using FluentValidation;
using MediatR;

namespace CQRSMediator.Commands.Tags.UpdateTag
{
    public class UpdateTagHandler : IRequestHandler<UpdateTagCommand, Tag>
    {
        private readonly ITagRepository _tagRepository;
        private readonly IValidator<UpdateTagCommand> _validator;

        public UpdateTagHandler(ITagRepository tagRepository, IValidator<UpdateTagCommand> validator)
        {
            _tagRepository = tagRepository;
            _validator = validator;
        }

        public async Task<Tag?> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request);
            return await _tagRepository.Update(request.Id, request.Name);
        }
    }
}
