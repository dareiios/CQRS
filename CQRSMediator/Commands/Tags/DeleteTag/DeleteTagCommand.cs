using MediatR;

namespace CQRSMediator.Commands.Tags.DeleteTag
{
    public class DeleteTagCommand:IRequest<int?>
    {
        public int Id { get; set; }
    }
}
