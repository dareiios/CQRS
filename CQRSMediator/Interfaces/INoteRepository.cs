using CQRSMediator.Entities;

namespace CQRSMediator.Interfaces
{
    public interface INoteRepository
    {
        Task<Note?> GetNoteById(int id);
        Task<IEnumerable<Note>> GetAll();
        Task<Note> Create(Note note);
        Task<Note?> Update(int id, string text, string title);
        Task<int?> Delete(int id);
        Task<IEnumerable<NoteTag>> Bind(int noteId, IEnumerable<int> tagsIds);

        Task<IEnumerable<NoteTag>> GetAllNoteTags();
        Task<NoteTag?> GetNoteTagById(int noteId);
    }
}
