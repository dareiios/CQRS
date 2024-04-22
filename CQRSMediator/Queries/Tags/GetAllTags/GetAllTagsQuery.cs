using CQRSMediator.Entities;
using MediatR;

namespace CQRSMediator.Queries.Notes.GetAllTags
{
    public class GetAllTagsQuery:IRequest<IEnumerable<Tag>>
    {
    }
}
