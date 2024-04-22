using CQRSMediator.Commands.Tags.CreateTag;
using CQRSMediator.Commands.Tags.DeleteTag;
using CQRSMediator.Commands.Tags.UpdateTag;
using CQRSMediator.Queries.Notes.GetAllTags;
using CQRSMediator.Queries.Tags.GetTag;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRSMediator.Controllers
{
    [Route("api/v1/tag/reminder/")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<ActionResult> CeateTag(CreateTagCommand cmd)
        {
            var tag = await _mediator.Send(cmd);
            return Ok(tag);
        }

        [HttpPost("delete")]
        public async Task<ActionResult> DeleteTag(DeleteTagCommand cmd)
        {
            var tagId = await _mediator.Send(cmd);
            if (tagId == null)
                return Ok("This tag does not exist.");
            return BadRequest($"deleted tag with id {tagId}");
        }

        [HttpPost("update")]
        public async Task<ActionResult> UpdateTag(UpdateTagCommand cmd)
        {
            var tag = await _mediator.Send(cmd);
            if (tag == null)
                return BadRequest("This tag does not exist.");
            return Ok(tag);
        }

        [HttpPost("get")]
        public async Task<ActionResult> GetTag(GetTagQuery query)
        {
            var tag = await _mediator.Send(query);
            if (tag == null)
                return BadRequest("This tag does not exist.");
            return Ok(tag);
        }

        [HttpPost("get-all")]
        public async Task<ActionResult> GetAll()
        {
            var tags = await _mediator.Send(new GetAllTagsQuery());
            return Ok(tags);
        }
    }
}
