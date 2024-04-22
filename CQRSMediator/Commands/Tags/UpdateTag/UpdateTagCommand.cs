using CQRSMediator.Entities;
using MediatR;

namespace CQRSMediator.Commands.Tags.UpdateTag
{
    public class UpdateTagCommand:IRequest<Tag>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
