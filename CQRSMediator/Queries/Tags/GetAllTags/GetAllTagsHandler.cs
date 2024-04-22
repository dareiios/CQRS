using CQRSMediator.Entities;
using CQRSMediator.Interfaces;
using MediatR;

namespace CQRSMediator.Queries.Notes.GetAllTags
{
    public class GetAllTagsHandler : IRequestHandler<GetAllTagsQuery, IEnumerable<Tag>>
    {

        private readonly ITagRepository _tagRepository;

        public GetAllTagsHandler(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<IEnumerable<Tag>> Handle(GetAllTagsQuery request, CancellationToken cancellationToken)
        {
            return await _tagRepository.GetAll();
        }

    }
}
