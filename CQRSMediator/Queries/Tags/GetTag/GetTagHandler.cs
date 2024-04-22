using CQRSMediator.Entities;
using CQRSMediator.Interfaces;
using FluentValidation;
using MediatR;

namespace CQRSMediator.Queries.Tags.GetTag
{
    public class GetTagHandler : IRequestHandler<GetTagQuery, Tag?>
    {
        private readonly ITagRepository _tagRepository;
        private readonly IValidator<GetTagQuery> _validator;

        public GetTagHandler(ITagRepository tagRepository, IValidator<GetTagQuery> validator)
        {
            _tagRepository = tagRepository;
            _validator = validator;
        }

        public async Task<Tag?> Handle(GetTagQuery request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request);
            return await _tagRepository.GetTagById(request.Id);
        }
    }
}
