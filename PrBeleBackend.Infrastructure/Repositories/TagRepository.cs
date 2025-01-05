using Microsoft.EntityFrameworkCore;
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Infrastructure.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly BeleStoreContext _context;

        public TagRepository(BeleStoreContext context)
        {
            _context = context;
        }

        public async Task<Tag> AddTag(Tag tag)
        {
            await _context.tags.AddAsync(tag);
            await _context.SaveChangesAsync();
            return tag;
        }

        public async Task<bool> DeleteTagById(int Id)
        {
            Tag tag = await _context.tags.FirstAsync(a => a.Id == Id);
            _context.tags.Remove(tag);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Tag>> GetAllTag()
        {
            List<Tag> tags = await _context.tags.ToListAsync();
            return tags;
        }

        public async Task<List<Tag>> GetFilteredTag(Expression<Func<Tag, bool>> predicate)
        {
            List<Tag> tags = await _context.tags.Where(predicate).ToListAsync();
            return tags;
        }

        public async Task<Tag?> GetTagById(int? Id)
        {
            Tag? tag = await _context.tags.FirstOrDefaultAsync(a => a.Id == Id);
            return tag;
        }

        public async Task<Tag> UpdateTag(Tag tag)
        {
            Tag? matchingTag = await _context.tags.FirstAsync(a => a.Id == tag.Id);
            matchingTag.Name = tag.Name;
            await _context.SaveChangesAsync();

            return matchingTag;
        }
    }

}
