using Microsoft.EntityFrameworkCore;
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.AttributeDTOs;
using PrBeleBackend.Core.DTO.Pagination;
using PrBeleBackend.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Infrastructure.Repositories
{
    public class AttributeRepository : IAttributeRepository
    {
        private readonly BeleStoreContext _context;

        public AttributeRepository(BeleStoreContext context)
        {
            _context = context;
        }

        public async Task<int> GetAttributeValueCount()
        {
            return await this._context.attributeValues.CountAsync();
        }

        public async Task<List<AttributeValueResponse>> GetFilteredAttributeValue(Expression<Func<AttributeValue, bool>> predicate, int? status = 1)
        {
            return await this._context.attributeValues
                .Where(predicate)
                .Where(attributeValue => attributeValue.Deleted == false)
                .Where(attributeValue => attributeValue.Status == status)
                .Select(attVal => new AttributeValueResponse
                {
                    Id = attVal.Id,
                    Name = attVal.Name,
                    Value = attVal.Value,
                    Deleted = attVal.Deleted,
                    CreatedAt = attVal.CreatedAt,
                    UpdatedAt = attVal.UpdatedAt,
                    AttributeTypeName = this._context.attributeTypes
                        .Where(attTyp => attTyp.Id == attVal.AttributeTypeId)
                        .Select(attTyp => attTyp.Name)
                        .FirstOrDefault()
                })
                .ToListAsync();
        }

        public async Task<AttributeValue> AddAttributeValue(AttributeValue attrVal)
        {
            await this._context.attributeValues.AddAsync(attrVal);

            await this._context.SaveChangesAsync();

            return attrVal;
        }

        public async Task<AttributeValue> UpdateAttributeValue(AttributeValue attrVal, int id)
        {
            AttributeValue? attrValMatching = await this._context.attributeValues
                .Where(attrVal => !attrVal.Deleted)
                .Where(attrVal => attrVal.Id == id)
                .FirstOrDefaultAsync();

            if (attrValMatching == null)
            {
                throw new ArgumentNullException(nameof(attrValMatching));
            }

            attrValMatching.Name = attrVal.Name;
            attrValMatching.Value = attrVal.Value;

            await this._context.SaveChangesAsync();

            return attrValMatching;
        }

        public async Task<AttributeValue> ModifyAttributeValueStatus(int status, int id)
        {
            AttributeValue? attrValMatching = await this._context.attributeValues
               .Where(attrVal => !attrVal.Deleted)
               .Where(attrVal => attrVal.Id == id)
               .FirstOrDefaultAsync();

            if (attrValMatching == null)
            {
                throw new ArgumentNullException(nameof(attrValMatching));
            }

            //attrValMatching.Status = status;

            await this._context.SaveChangesAsync();

            return attrValMatching;
        }

        public async Task<AttributeValue> DeleteAttributeValue(int id)
        {
            AttributeValue? attrValMatching = await this._context.attributeValues
              .Where(attrVal => !attrVal.Deleted)
              .Where(attrVal => attrVal.Id == id)
              .FirstOrDefaultAsync();

            if (attrValMatching == null)
            {
                throw new ArgumentNullException(nameof(attrValMatching));
            }

            attrValMatching.Deleted = true;

            await this._context.SaveChangesAsync();

            return attrValMatching;
        }
    }
}
