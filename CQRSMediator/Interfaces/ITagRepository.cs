using CQRSMediator.Entities;

namespace CQRSMediator.Interfaces
{
    public interface ITagRepository
    {
        Task<Tag?> GetTagById(int id);
        Task<IEnumerable<Tag>> GetAll();
        Task<Tag> Create(Tag tag);
        Task<Tag?> Update(int id, string name);
        Task<int?> Delete(int id);

    }
}
