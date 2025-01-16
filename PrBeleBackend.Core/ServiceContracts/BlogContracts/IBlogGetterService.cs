using PrBeleBackend.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.BlogContracts
{
    public interface IBlogGetterService
    {
        public Task<List<Blog>> GetBlogs(string? searchName = "");

        public Task<Blog> GetBlogById(int id);
    }
}
