using CQRSMediator.Entities;
using CQRSMediator.Interfaces;
using FluentValidation;
using MediatR;

namespace CQRSMediator.Commands.Tags.CreateTag
{
    public class CreateTagHandler : IRequestHandler<CreateTagCommand, Tag>
    {
        private readonly ITagRepository _tagRepository;
        private readonly IValidator<CreateTagCommand> _validator;

        public CreateTagHandler(ITagRepository tagRepository, IValidator<CreateTagCommand> validator)
        {
            _tagRepository = tagRepository;
            _validator = validator;
        }

        public async Task<Tag> Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request);
            var tag = new Tag() { Name = request.Name };
            return await _tagRepository.Create(tag);

        }
    }
}
