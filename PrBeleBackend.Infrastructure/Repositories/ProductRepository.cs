using Microsoft.EntityFrameworkCore;
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.CategoryDTOs;
using PrBeleBackend.Core.DTO.Pagination;
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

        public async Task<int> GetProductCount()
        {
            return await _context.products.CountAsync();
        }

        public async Task<List<ProductResponse>> GetFilteredProduct(PaginationResponse paginationResponse, Expression<Func<Product, bool>> predicate)
        {
            return await _context.products
                .Where(product => product.Deleted == false)
                .Where(predicate)
                .Select(p => new ProductResponse
                {
                    Id = p.Id,
                    Name = p.Name,
                    Category = _context.categories
                        .Where(c => c.Id == p.CategoryId)
                        .FirstOrDefault(),
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
                })
                .OrderBy(p => p.Id)
                .Skip(paginationResponse.PageIndex * paginationResponse.PageSize)
                .Take(paginationResponse.PageSize)
                .ToListAsync();
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

        public async Task<Product> AddProduct(Product product)
        {
            await this._context.products.AddAsync(product);
            await this._context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> UpdateProduct(Product productUpdate)
        {
            Product? product = await this._context.products
                .Where(product => !product.Deleted)
                .Where(product => product.Id == productUpdate.Id)
                .FirstOrDefaultAsync();

            if (product != null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            product.Name = productUpdate.Name;
            product.Description = productUpdate.Description;
            product.CategoryId = productUpdate.Category.Id;
            product.BasePrice = productUpdate.BasePrice;
            //product.DiscountId = productUpdate.DiscountId;
            //product.ProductAttributeTypes = productUpdate.ProductAttributeTypes;

            if (productUpdate.Thumbnail != "")
            {
                product.Thumbnail = product.Thumbnail;
            }

            product.Slug = productUpdate.Slug;
            product.UpdatedAt = productUpdate.UpdatedAt;

            await this._context.SaveChangesAsync();

            await this._context.productAttributeTypes.Where(product => product.ProductId == productUpdate.Id).ExecuteDeleteAsync();

            await this._context.productAttributeTypes.AddRangeAsync(productUpdate.ProductAttributeTypes);

            await this._context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> ModifyProduct(ProductModifyRequest req, int id)
        {
            Product? productMatching = await this._context.products
                .Where(product => !product.Deleted)
                .Where(product => product.Id == id)
                .FirstOrDefaultAsync();

            if (productMatching == null)
            {
                throw new ArgumentNullException(nameof(productMatching));
            }

            switch (req.ModifyField)
            {
                case nameof(Product.Status):
                    {
                        if(req.ModifyValue != "1" && req.ModifyValue != "0")
                        {
                            throw new ArgumentNullException("Wrong value!");
                        }

                        productMatching.Status = Convert.ToInt32(req.ModifyValue);

                        break;
                    }
                case nameof(Product.Like):
                    {
                        if (req.ModifyAction != "Reduce" || req.ModifyAction != "Increase")
                        {
                            throw new ArgumentNullException("Wrong action!");
                        }

                        if(req.ModifyAction == "Reduce")
                        {
                            productMatching.Like++;
                        }
                        else
                        {
                            productMatching.Like--;
                        }

                        break;
                    }
                case nameof(Product.View):
                    {
                        if (req.ModifyAction != "Reduce" || req.ModifyAction != "Increase")
                        {
                            throw new ArgumentNullException("Wrong action!");
                        }

                        if (req.ModifyAction == "Reduce")
                        {
                            productMatching.View++;
                        }
                        else
                        {
                            productMatching.View--;
                        }

                        break;
                    }
            }

            await this._context.SaveChangesAsync();

            return productMatching;
        }

        public async Task<Product> DeleteProduct(int id)
        {
            Product? product = await this._context.products
                .Where(product => !product.Deleted)
                .Where(product => product.Id == id)
                .FirstOrDefaultAsync();

            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            product.Deleted = false;

            await this._context.SaveChangesAsync();

            return product;
        }
    }
}
