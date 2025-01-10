using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.DTO.TagDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Domain.RepositoryContracts
{
    public interface ITagRepository
    {
        public Task<List<TagResponse>> GetAllTag();

        public Task<List<Tag>> GetFilteredTag(Expression<Func<Tag, bool>> predicate);

        public Task<Tag?> GetTagById(int? Id);
        //public Task<Customer?> GetAccountByEmail(string? Email);

        public Task<Tag> AddTag(Tag tag);

        public Task<Tag> UpdateTag(Tag tag);
        public Task<bool> DeleteTagById(int Id);
    }
}
