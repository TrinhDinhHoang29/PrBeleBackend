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

        public async Task<List<VariantSizeResponse>> GetVariantByProductIdAndColor(int productId, int colorId)
        {
            return await this._context.variantAttributeValues
                 .Include(vav => vav.Variant)
                 .Include(vav => vav.AttributeValue)
                 .Where(vav => vav.Variant.ProductId == productId && vav.AttributeValue.Id == colorId)
                 .Select(vav => this._context.variants
                    .Include(v => v.VariantAttributeValues)
                        .ThenInclude(vav => vav.AttributeValue)
                            .ThenInclude(av => av.AttributeType)
                    .Where(v => v.Id == vav.VariantId)
                    .Select(v => new VariantSizeResponse { 
                        VariantId = v.Id,
                        Size = v.VariantAttributeValues
                            .Where(vav => vav.AttributeValue.AttributeType.Name == "Size")
                            .Select(vav => vav.AttributeValue.Value).FirstOrDefault()
                    }).FirstOrDefault()
                 )
                 .ToListAsync();
        }

        public async Task<List<VariantResponse>> GetFilteredVariant(Expression<Func<Variant, bool>> predicate, int productId)
        {
            return await this._context.variants
                .Where(predicate)
                .Where(var => var.Deleted == false)
                .Where(var => var.ProductId == productId)
                .Select(var => new VariantResponse
                {
                    Id = var.Id,
                    Price = var.Price,
                    Stock = var.Stock,
                    Thumbnail = var.Thumbnail,
                    Status = var.Status,
                    //Deleted = var.Deleted,
                    CreatedAt = var.CreatedAt,
                    UpdatedAt = var.UpdatedAt,
                    ProductName = this._context.products
                        .Where(p => !p.Deleted)
                        .Where(p => p.Id == productId)
                        .Select(p => p.Name).FirstOrDefault().ToString(),
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
                   //Deleted = var.Deleted,
                   CreatedAt = var.CreatedAt,
                   UpdatedAt = var.UpdatedAt,
                   ProductName = this._context.products
                       .Where(p => !p.Deleted)
                       .Where(p => p.Id == var.ProductId)
                       .Select(p => p.Name)
                       .FirstOrDefault()
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

        public async Task<Variant> CreateVariant(Variant variant)
        {
            if(variant == null)
            {
                throw new ArgumentNullException(nameof(variant));
            }

            await this._context.variants.AddAsync(variant);

            await this._context.SaveChangesAsync();

            return variant;
        }

        public async Task<Variant> UpdateVariant(Variant variant, int id)
        {
            if (variant == null)
            {
                throw new ArgumentNullException(nameof(variant));
            }

            Variant? variantMatching = await this._context.variants
                .Include(var => var.VariantAttributeValues)
                .Where(var => var.Deleted == false)
                .Where(var => var.Id == id)
                .FirstOrDefaultAsync();

            if(variantMatching == null)
            {
                throw new ArgumentNullException(nameof(variantMatching));
            }

            variantMatching.Price = variant.Price;
            variantMatching.Stock = variant.Stock;
            variantMatching.UpdatedAt = variant.UpdatedAt;
            
            if(variant.Thumbnail != null)
            {
                variantMatching.Thumbnail = variant.Thumbnail;
            }

            variantMatching.VariantAttributeValues.Clear();
            variantMatching.VariantAttributeValues.AddRange(variant.VariantAttributeValues);

            await this._context.SaveChangesAsync();

            return variantMatching;
        }

        public async Task<Variant> ModifyVariant(VariantModifierRequest req, int id)
        {
            Variant? variantMatching = await this._context.variants
                .Where(var => !var.Deleted)
                .Where(var => var.Id == id)
                .FirstOrDefaultAsync();

            if(variantMatching == null)
            {
                throw new ArgumentNullException(nameof(variantMatching));
            }

            switch (req.ModifyField)
            {
                case nameof(Variant.Status):
                    {
                        variantMatching.Status = Convert.ToInt32(req.ModifyValue);

                        break;
                    }
                default:
                    {
                        throw new ArgumentException(nameof(req.ModifyField));
                    }
            }

            await this._context.SaveChangesAsync();

            return variantMatching;
        }

        public async Task<Variant> DeleteVariant(int id)
        {
            Variant? variantMatching = await this._context.variants
                .Where(var => !var.Deleted)
                .Where(var => var.Id == id)
                .FirstOrDefaultAsync();

            if (variantMatching == null)
            {
                throw new ArgumentNullException(nameof(variantMatching));
            }

            variantMatching.Deleted = true;

            await this._context.SaveChangesAsync();

            return variantMatching;
        }
    }
}
