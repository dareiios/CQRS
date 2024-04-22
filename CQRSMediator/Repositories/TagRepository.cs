using CQRSMediator.Entities;
using CQRSMediator.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediator.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly ApplicationDbContext _context;

        public TagRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Tag> Create(Tag tag)
        {
            await _context.Tags.AddAsync(tag);
            await _context.SaveChangesAsync();
            return tag;
        }

        public async Task<int?> Delete(int id)
        {
            var tag = _context.Tags.Find(id);
            if (tag != null)
            {
                _context.Tags.Remove(tag);
                await _context.SaveChangesAsync();
                return tag.Id;
            }
            return null;

        }

        public async Task<IEnumerable<Tag>> GetAll()
        {
            var tags = await _context.Tags.ToListAsync();
            return tags;
        }

        public async Task<Tag?> GetTagById(int id)
        {
            var tag = await _context.Tags.FirstOrDefaultAsync(x => x.Id == id);
            return tag;
        }

        public async Task<Tag?> Update(int id, string name)
        {
            var tag = await _context.Tags.FirstOrDefaultAsync(x=>x.Id==id);
            if (tag != null)
            {
                tag.Name = name;
               _context.Tags.Update(tag);
                await _context.SaveChangesAsync();
            }
            return tag;
        }
    }
}
