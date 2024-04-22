using CQRSMediator.Entities;
using MediatR;

namespace CQRSMediator.Commands.Tags.CreateTag
{
    public class CreateTagCommand:IRequest<Tag>
    {
        public string Name { get; set; }
    }
}
