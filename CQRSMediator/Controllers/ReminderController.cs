using CQRSMediator.Commands.Reminders.BindTags;
using CQRSMediator.Commands.Reminders.CreateReminder;
using CQRSMediator.Commands.Reminders.DeleteReminder;
using CQRSMediator.Commands.Reminders.UpdateReminder;
using CQRSMediator.Queries.Reminders.GetAllReminders;
using CQRSMediator.Queries.Reminders.GetAllReminderTags;
using CQRSMediator.Queries.Reminders.GetReminder;
using CQRSMediator.Queries.Reminders.GetReminderTag;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSMediator.Controllers
{
    [Route("api/v1/function/reminder/")]
    [ApiController]
    public class ReminderController : Controller
    {
        private readonly IMediator _mediator;

        public ReminderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<ActionResult> Create(CreateReminderCommand cmd)
        {
            var reminder = await _mediator.Send(cmd);
            return Ok(reminder);
        }

        [HttpPost("delete")]
        public async Task<ActionResult> DeleteREminder(DeleteReminderCommand cmd)
        {
            var reminderId = await _mediator.Send(cmd);
            if (reminderId == null)
                return BadRequest("This note does not exist.");
            return Ok($"Deleted note with id {reminderId}.");
        }

        [HttpPost("update")]
        public async Task<ActionResult> UpdateReminder(UpdateReminderCommand cmd)
        {
            var reminder = await _mediator.Send(cmd);
            if (reminder == null)
                return BadRequest("This note does not exist");
            return Ok(reminder);
        }

        [HttpPost("bind")]
        public async Task<ActionResult> Bind(BindTagsToReminderCommand cmd)
        {
            var binding = await _mediator.Send(cmd);
            if (binding == null)
                return BadRequest("Wrong data for binding.");
            return Ok(binding);
        }

        [HttpPost("get")]
        public async Task<ActionResult> GetReminder(GetReminderQuery query)
        {
            var reminder = await _mediator.Send(query);
            if (reminder == null)
                return BadRequest("This reminder does not exist");
            return Ok(reminder);
        }


        [HttpPost("get-all")]
        public async Task<ActionResult> GetAll()
        {
            var reminders = await _mediator.Send(new GetAllRemindersQuery());
            return Ok(reminders);
        }

        [HttpPost("get-all-reminderTags")]
        public async Task<ActionResult> GetAllReminderTags()
        {
            var reminders = await _mediator.Send(new GetAllReminderTagsQuery());
            return Ok(reminders);
        }

        [HttpPost("get-reminderTag")]
        public async Task<ActionResult> GetReminderTag(GetReminderTagQuery query)
        {
            var reminderTag = await _mediator.Send(query);
            if (reminderTag == null)
                return BadRequest("This reminderTag does not exist");
            return Ok(reminderTag);
        }
    }
}
