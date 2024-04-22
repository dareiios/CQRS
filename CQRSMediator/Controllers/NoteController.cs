using CQRSMediator.Commands.Notes.BindTags;
using CQRSMediator.Commands.Notes.CreateNote;
using CQRSMediator.Commands.Notes.DeleteNote;
using CQRSMediator.Commands.Notes.UpdateNote;
using CQRSMediator.Queries.Notes.GetAllNotes;
using CQRSMediator.Queries.Notes.GetAllNoteTags;
using CQRSMediator.Queries.Notes.GetNote;
using CQRSMediator.Queries.Notes.GetNoteTag;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSMediator.Controllers
{
    [Route("api/v1/function/note/")]
    [ApiController]
    public class NoteController : Controller
    {
        private readonly IMediator _mediator;

        public NoteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreateNote(CreateNoteCommand cmd)
        {
            var note = await _mediator.Send(cmd);
            return Ok(note);
        }

        [HttpPost("delete")]
        public async Task<ActionResult> DeleteNote(DeleteNoteCommand cmd)
        {
            var noteId = await _mediator.Send(cmd);
            if (noteId == null)
                return BadRequest("This note does not exist.");
            return Ok($"Deleted note with id {noteId}.");
        }

        [HttpPost("update")]
        public async Task<ActionResult> UpdateNote(UpdateNoteCommand cmd)
        {
            var note = await _mediator.Send(cmd);
            if (note == null)
                return BadRequest("This note does not exist");
            return Ok(note);
        }

        [HttpPost("bind")]
        public async Task<ActionResult> Bind(BindTagsToNoteCommand cmd)
        {
            var binding = await _mediator.Send(cmd);
            if (binding == null)
                return BadRequest("Wrong data for binding.");
            return Ok(binding);
        }

        [HttpPost("get")]
        public async Task<ActionResult> GetNote(GetNoteQuery query)
        {
            var note = await _mediator.Send(query);
            if (note == null)
                return BadRequest("This note does not exist");
            return Ok(note);
        }

        [HttpPost("get-all")]
        public async Task<ActionResult> GetAll()
        {
            var notes = await _mediator.Send(new GetAllNotesQuery());
            return Ok(notes);
        }


        [HttpPost("get-all-NoteTags")]
        public async Task<ActionResult> GetAllNoteTags()
        {
            var noteTag = await _mediator.Send(new GetAllNoteTagsQuery());
            return Ok(noteTag);
        }

        [HttpPost("get-noteTag")]
        public async Task<ActionResult> GetNoteTag(GetNoteTagQuery query)
        {
            var noteTag = await _mediator.Send(query);
            if (noteTag == null)
                return BadRequest("This NoteTag does not exist");
            return Ok(noteTag);
        }
    }
}
