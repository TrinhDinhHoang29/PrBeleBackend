using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.ServiceContracts.BlogContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrBeleBackend.Core.Domain.Entities;

namespace PrBeleBackend.Core.Services.BlogServices
{
    public class BlogGetterService : IBlogGetterService
    {
        private readonly IBlogRepository _blogRepository;

        public BlogGetterService(IBlogRepository blogRepository)
        {
            this._blogRepository = blogRepository;
        }

        public async Task<List<Blog>> GetBlogs(string? searchName = "")
        {
            return await this._blogRepository.GetBlogs(searchName); 
        }

        public async Task<Blog> GetBlogById(int id)
        {
            return await this._blogRepository.GetBlogById(id);
        }
    }
}
