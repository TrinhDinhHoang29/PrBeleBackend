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

        public async Task<List<AttributeTypeResponse>> GetAttributeType()
        {
            return await this._context.attributeTypes
                .Select(attTyp => new AttributeTypeResponse
                {
                    Id = attTyp.Id,
                    Name = attTyp.Name,
                }).ToListAsync();
        }

        public async Task<int> GetAttributeValueCount()
        {
            return await this._context.attributeValues.CountAsync();
        }

        public async Task<List<AttributeValueResponse>> GetFilteredAttributeValue(Expression<Func<AttributeValue, bool>> predicate)
        {
            return await this._context.attributeValues
                .Where(predicate)
                .Where(attributeValue => attributeValue.Deleted == false)
                .Select(attVal => new AttributeValueResponse
                {
                    Id = attVal.Id,
                    Name = attVal.Name,
                    Value = attVal.Value,
                    //Deleted = attVal.Deleted,
                    Status = attVal.Status,
                    CreatedAt = attVal.CreatedAt,
                    UpdatedAt = attVal.UpdatedAt,
                    AttributeType = this._context.attributeTypes
                        .Where(attTyp => attTyp.Id == attVal.AttributeTypeId)
                        .FirstOrDefault()
                })
                .ToListAsync();
        }

        public async Task<AttributeValueResponse> GetDetailAttributeValue(int id)
        {
            return await this._context.attributeValues
                .Where(attributeValue => attributeValue.Deleted == false)
                .Where(attributeValue => attributeValue.Id == id)
                .Select(attVal => new AttributeValueResponse
                {
                    Id = attVal.Id,
                    Name = attVal.Name,
                    Value = attVal.Value,
                    //Deleted = attVal.Deleted,
                    Status = attVal.Status,
                    CreatedAt = attVal.CreatedAt,
                    UpdatedAt = attVal.UpdatedAt,
                    AttributeType = this._context.attributeTypes
                        .Where(attTyp => attTyp.Id == attVal.AttributeTypeId)
                        .FirstOrDefault()
                })
                .FirstOrDefaultAsync();
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
            attrValMatching.AttributeTypeId = attrVal.AttributeTypeId;
            attrValMatching.Status = attrVal.Status;

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

            attrValMatching.Status = status;

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
