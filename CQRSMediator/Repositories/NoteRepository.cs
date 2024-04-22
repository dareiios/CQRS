using CQRSMediator.Entities;
using CQRSMediator.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediator.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly ApplicationDbContext _context;

        public NoteRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }


        public async Task<Note> Create(Note note)
        {
            await _context.Notes.AddAsync(note);
            await _context.SaveChangesAsync();
            return note;
        }

        public async Task<IEnumerable<NoteTag>> Bind(int noteId, IEnumerable<int> tagsIds)
        {
            var note = await _context.Notes.FirstOrDefaultAsync(x => x.Id == noteId);
            if (note == null)
                return null;

            List<NoteTag> noteTagsList = new();
            foreach (var id in tagsIds)
            {
                var tag = await _context.Tags.FirstOrDefaultAsync(x => x.Id == id);
                if (tag == null)
                    return null;

                var noteTag = new NoteTag()
                {
                    Note = note,
                    Tag = tag
                };
                noteTagsList.Add(noteTag);
            }

            await _context.NoteTags.AddRangeAsync(noteTagsList);
            await _context.SaveChangesAsync();
            return noteTagsList;
        }

        public async Task<int?> Delete(int id)
        {
            var note = await _context.Notes.FirstOrDefaultAsync(x => x.Id == id);

            if (note != null)
            {
                _context.Notes.Remove(note);
                _context.SaveChanges();
                return note.Id;
            }

            return null;
        }

        public async Task<IEnumerable<Note>> GetAll()
        {
            var notes = await _context.Notes.ToListAsync();
            return notes;
        }

        public async Task<Note?> GetNoteById(int id)
        {
            var note = await _context.Notes.FirstOrDefaultAsync(x => x.Id == id);
            return note;
        }

        public async Task<Note?> Update(int id, string text, string title)
        {
            var note = _context.Notes.FirstOrDefault(x => x.Id == id);
            if (note != null)
            {
                note.Text = text;
                note.Title = title;
                _context.Notes.Update(note);
                _context.SaveChanges();
            }
            return note;
        }

        public async Task<IEnumerable<NoteTag>> GetAllNoteTags()
        {
            var noteTags = await _context.NoteTags.Include(x => x.Note).Include(x => x.Tag).ToListAsync();
            return noteTags;
        }

        public async Task<NoteTag?> GetNoteTagById(int noteId)
        {
            var noteTag = await _context.NoteTags.Include(x => x.Note).Include(x => x.Tag).FirstOrDefaultAsync(x => x.NoteId == noteId);
            return noteTag;
        }
    }
}
