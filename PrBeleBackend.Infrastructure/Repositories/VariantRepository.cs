using Microsoft.EntityFrameworkCore;
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.Pagination;
using PrBeleBackend.Core.DTO.ProductDTOs;
using PrBeleBackend.Core.DTO.VariantDTOs;
using PrBeleBackend.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Infrastructure.Repositories
{
    public class VariantRepository : IVariantRepository
    {
        private readonly BeleStoreContext _context;

        public VariantRepository(BeleStoreContext context)
        {
            this._context = context;
        }

        public async Task<int> GetVariantCountByProductId(int productId)
        {
            return await this._context.variants
                .Where(var => var.ProductId == productId)
                .Where(var => !var.Deleted)
                .CountAsync();
        }

        public async Task<List<VariantResponse>> GetFilteredVariant(PaginationResponse paginationResponse, Expression<Func<Variant, bool>> predicate, int productId)
        {
            return await this._context.variants
                .Where(predicate)
                .Where(var => !var.Deleted)
                .Where(var => var.ProductId == productId)
                .Select(var => new VariantResponse
                {
                    Id = var.Id,
                    Price = var.Price,
                    Stock = var.Stock,
                    Thumbnail = var.Thumbnail,
                    Status = var.Status,
                    Deleted = var.Deleted,
                    CreatedAt = var.CreatedAt,
                    UpdatedAt = var.UpdatedAt,
                    ProductName = this._context.products
                        .Where(p => !p.Deleted)
                        .Where(p => p.Id == productId)
                        .Select(p => p.Name)
                        .ToString(),
                    AttributeValues = this._context.attributeValues
                        .Join(
                            this._context.variantAttributeValues,
                            attVal => attVal.Id,
                            varAttVal => varAttVal.AttributeValueId,
                            (attVal, varAttVal) => new { attVal, varAttVal }
                        )
                        .Where(res => res.varAttVal.VariantId == var.Id)
                        .Select(res => res.attVal)
                        .ToList()
                })
                .OrderBy(var => var.Id)
                .Skip(paginationResponse.PageIndex * paginationResponse.PageSize)
                .Take(paginationResponse.PageSize)
                .ToListAsync();
        }

        public async Task<VariantResponse> GetVariantDetail(int id)
        {
            return await this._context.variants
               .Where(var => !var.Deleted)
               .Where(var => var.Id == id)
               .Select(var => new VariantResponse
               {
                   Id = var.Id,
                   Price = var.Price,
                   Stock = var.Stock,
                   Thumbnail = var.Thumbnail,
                   Status = var.Status,
                   Deleted = var.Deleted,
                   CreatedAt = var.CreatedAt,
                   UpdatedAt = var.UpdatedAt,
                   ProductName = this._context.products
                       .Where(p => !p.Deleted)
                       .Where(p => p.Id == var.ProductId)
                       .Select(p => p.Name)
                       .ToString(),
                   AttributeValues = this._context.attributeValues
                       .Join(
                           this._context.variantAttributeValues,
                           attVal => attVal.Id,
                           varAttVal => varAttVal.AttributeValueId,
                           (attVal, varAttVal) => new { attVal, varAttVal }
                       )
                       .Where(res => res.varAttVal.VariantId == var.Id)
                       .Select(res => res.attVal)
                       .ToList()
               })
               .FirstOrDefaultAsync();
        }
    }
}
