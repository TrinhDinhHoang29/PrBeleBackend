using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.DTO.AttributeDTOs;
using PrBeleBackend.Core.DTO.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Domain.RepositoryContracts
{
    public interface IAttributeRepository
    {
        public Task<int> GetAttributeValueCount();

        public Task<List<AttributeValueResponse>> GetFilteredAttributeValue(Expression<Func<AttributeValue, bool>> predicate, int? status);

        public Task<AttributeValue> AddAttributeValue(AttributeValue attrVal);

        public Task<AttributeValue> UpdateAttributeValue(AttributeValue attrVal, int id);

        public Task<AttributeValue> ModifyAttributeValueStatus(int status, int id);

        public Task<AttributeValue> DeleteAttributeValue(int id);
    }
}
