using PrBeleBackend.Core.Domain.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace PrBeleBackend.Infrastructure.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BeleStoreContext _context;

        public BlogRepository(BeleStoreContext context)
        {
            this._context = context;
        }

        public async Task<List<Blog>> GetBlogs(string? searchName = "")
        {
            return this._context.blogs
                .Include(b => b.Contents.OrderBy(c => c.Order))
                .Where(b => b.Status == 1)
                .Where(b => b.Deleted == 0)
                .Where(b => b.Title.Contains(searchName))
                .ToList();
        }

        public async Task<Blog?> GetBlogById(int id)
        {
            return await this._context.blogs
                .Include(b => b.Contents.OrderBy(c => c.Order))
                .Where(b => b.Status == 1)
                .Where(b => b.Id == id)
                .Where(b => b.Deleted == 0)
                .FirstOrDefaultAsync();
        }
    }
}
