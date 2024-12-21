using Microsoft.EntityFrameworkCore;
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.CategoryDTOs;
using PrBeleBackend.Core.DTO.ProductDTOs;
using PrBeleBackend.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly BeleStoreContext _context;

        public ProductRepository(BeleStoreContext context)
        {
            _context = context;
        }

        public async Task<List<ProductResponse>> GetAllProduct()
        {
            return await _context.products
                .Where(product => product.Deleted == false)
                .Select(p => new ProductResponse
                {
                    Id = p.Id,
                    Name = p.Name,
                    Category = _context.categories
                        .Where(c => c.Id == p.CategoryId)
                        .FirstOrDefault(),
                    Thumbnail = p.Thumbnail,
                    Description = p.Description,
                    Discount = "0",
                    BasePrice = p.BasePrice,
                    Slug = p.Slug,
                    View = p.View,
                    Like = p.Like,
                    Status = p.Status,
                    UpdatedAt = p.UpdatedAt,
                    CreatedAt = p.CreatedAt,
                    AttributeTypes = _context.attributeTypes.Join(
                        _context.productAttributeTypes,
                        at => at.Id,
                        pat => pat.AttributeTypeId,
                        (at, pat) => new {at, pat}
                    ).Where(res => res.pat.ProductId == p.Id)
                    .Select(res => res.at).ToList()
                }).ToListAsync();
        }

        public async Task<ProductResponse> GetProductById(int id)
        {
            return await _context.products
                .Where(product => product.Deleted == false)
                .Where(product => product.Id == id)
                .Select(p => new ProductResponse
                {
                    Id = p.Id,
                    Name = p.Name,
                    Category = _context.categories
                        .Where(c => c.Id == p.CategoryId)
                        .FirstOrDefault(),
                    Thumbnail = p.Thumbnail,
                    Description = p.Description,
                    Discount = "0",
                    BasePrice = p.BasePrice,
                    Slug = p.Slug,
                    View = p.View,
                    Like = p.Like,
                    Status = p.Status,
                    UpdatedAt = p.UpdatedAt,
                    CreatedAt = p.CreatedAt,
                    AttributeTypes = _context.attributeTypes.Join(
                        _context.productAttributeTypes,
                        at => at.Id,
                        pat => pat.AttributeTypeId,
                        (at, pat) => new { at, pat }
                    ).Where(res => res.pat.ProductId == p.Id)
                    .Select(res => res.at).ToList()
                }).FirstOrDefaultAsync();
        }
    }
}
