using CQRSMediator.Entities;
using MediatR;

namespace CQRSMediator.Queries.Tags.GetTag
{
    public class GetTagQuery:IRequest<Tag?>
    {
        public int Id { get; set; }
    }
}
