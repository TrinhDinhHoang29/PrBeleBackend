using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.CategoryDTOs;
using PrBeleBackend.Core.DTO.Pagination;
using PrBeleBackend.Core.DTO.ProductDTOs;
using PrBeleBackend.Core.DTO.VariantDTOs;
using PrBeleBackend.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
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

        public async Task<List<ProductResponse>> GetWishList(int customerId)
        {
            return await this._context.wishList
                .Where(wl => wl.CustomerId == customerId)
                .Include(wl => wl.Product)
                .Select(wl => new ProductResponse
                {
                    Id = wl.Product.Id,
                    Name = wl.Product.Name,
                    //Category = _context.categories
                    //.Where(c => c.Id == wl.Product.CategoryId)
                    //.FirstOrDefault(),
                    Description = wl.Product.Description,
                    Discount = wl.Product.Discount,
                    BasePrice = wl.Product.BasePrice,
                    Slug = wl.Product.Slug,
                    View = wl.Product.View,
                    Like = wl.Product.Like,
                    Thumbnail = wl.Product.Thumbnail,
                    Status = wl.Product.Status,
                    UpdatedAt = wl.Product.UpdatedAt,
                    CreatedAt = wl.Product.CreatedAt,
                    RateAVG = _context.rates
                    .Where(r => r.ProductId == wl.Product.Id)
                    .Select(r => r.Star).ToList(),
                    VariantColors = _context.variantAttributeValues
                    .Include(varAttVal => varAttVal.Variant)
                    .Include(varAttVal => varAttVal.AttributeValue)
                    .ThenInclude(attVal => attVal.AttributeType)
                    .Where(varAttVal => varAttVal.Variant.ProductId == wl.Product.Id && varAttVal.AttributeValue.AttributeType.Name == "Color")
                    .Select(varAttVal => new VariantColorReponse
                    {
                        VariantId = varAttVal.VariantId,
                        Color = varAttVal.AttributeValue.Value,
                        ColorId = varAttVal.AttributeValueId,
                        Thumbnail = varAttVal.Variant.Thumbnail,
                        Price = varAttVal.Variant.Price
                    }).ToList(),
                    Tags = _context.tags.Join(
                    _context.productTags,
                    t => t.Id,
                    pt => pt.TagId,
                    (t, pt) => new { t, pt }
                ).Where(res => res.pt.ProductId == wl.Product.Id)
                .Select(res => res.t).ToList(),
                //    AttributeTypes = _context.attributeTypes.Join(
                //    _context.productAttributeTypes,
                //    at => at.Id,
                //    pat => pat.AttributeTypeId,
                //    (at, pat) => new { at, pat }
                //).Where(res => res.pat.ProductId == wl.Product.Id)
                //.Select(res => res.at).ToList()
                })
                .ToListAsync();
        }

        public async Task<List<ProductResponse>> SearchProduct(List<string> keywords, int page = 1, int limit = 10)
        {
            List<ProductKeyword> result = new List<ProductKeyword>();

            foreach (string keyword in keywords)
            {
                Keyword? item = this._context.keywords
                        .Include(k => k.ProductKeywords)
                        .ThenInclude(k => k.Product)
                        .Where(k => k.Key.Contains(keyword))
                        .FirstOrDefault();

                if (item != null)
                {
                    result.AddRange(item.ProductKeywords);
                }
            }

            List<ProductResponse?> products = result
                .GroupBy(k => k.ProductId)
                .OrderBy(k => k.Count())
                .Skip(limit * (page - 1))
                .Take(limit)
                .Select(pk => pk.Select(p => new ProductResponse
                {
                    Id = p.Product.Id,
                    Name = p.Product.Name,
                    //Category = _context.categories
                    //.Where(c => c.Id == p.Product.CategoryId)
                    //.FirstOrDefault(),
                    Description = p.Product.Description,
                    Discount = p.Product.Discount,
                    BasePrice = p.Product.BasePrice,
                    Slug = p.Product.Slug,
                    //View = p.Product.View,
                    //Like = p.Product.Like,
                    Thumbnail = p.Product.Thumbnail,
                    Status = p.Product.Status,
                    UpdatedAt = p.Product.UpdatedAt,
                    CreatedAt = p.Product.CreatedAt,
                    RateAVG = _context.rates
                    .Where(r => r.ProductId == p.Product.Id)
                    .Select(r => r.Star).ToList(),
                    VariantColors = _context.variantAttributeValues
                    .Include(varAttVal => varAttVal.Variant)
                    .Include(varAttVal => varAttVal.AttributeValue)
                    .ThenInclude(attVal => attVal.AttributeType)
                    .Where(varAttVal => varAttVal.Variant.ProductId == p.Product.Id && varAttVal.AttributeValue.AttributeType.Name == "Color")
                    .Select(varAttVal => new VariantColorReponse
                    {
                        VariantId = varAttVal.VariantId,
                        Color = varAttVal.AttributeValue.Value,
                        ColorId = varAttVal.AttributeValueId,
                        Thumbnail = varAttVal.Variant.Thumbnail,
                        Price = varAttVal.Variant.Price
                    }).ToList(),
                    Tags = _context.tags.Join(
                    _context.productTags,
                    t => t.Id,
                    pt => pt.TagId,
                    (t, pt) => new { t, pt }
                ).Where(res => res.pt.ProductId == p.Product.Id)
                .Select(res => res.t).ToList(),
                //    AttributeTypes = _context.attributeTypes.Join(
                //    _context.productAttributeTypes,
                //    at => at.Id,
                //    pat => pat.AttributeTypeId,
                //    (at, pat) => new { at, pat }
                //).Where(res => res.pat.ProductId == p.Product.Id)
                //.Select(res => res.at).ToList()
                }).FirstOrDefault())
                .ToList();

            return products;
        }

        public bool IsHaveTag(int productId, int tagId)
        {
            return this._context.productTags.Any(pt => pt.ProductId == productId && pt.TagId == tagId);
        }

        public bool IsHaveAttributeType(int productId, int attTypId)
        {
            return this._context.productAttributeTypes.Any(pat => pat.ProductId == productId && pat.AttributeTypeId == attTypId);
        }

        public bool IsHaveAttributeValue(int productId, string value)
        {
            return this._context.variantAttributeValues
                .Include(vav => vav.Variant)
                .Include(vav => vav.AttributeValue)
                .Any(vav => vav.Variant.ProductId == productId && vav.AttributeValue.Value == value);
        }

        public bool IsHaveCategory(int productId, int categoryId)
        {
            return this._context.products.Any(p => p.Id == productId && p.CategoryId == categoryId);
        }

        public bool IsHaveCategoryRef(int productId, int categoryRefId)
        {
            return this._context.products
                .Include(p => p.Category)
                .Any(p => p.Id == productId && p.Category.ReferenceCategoryId == categoryRefId);
        }

        public async Task<ProductResponse?> ProductDetailAdmin(int id)
        {
            return await _context.products
           .Include(p => p.Discount)
           .Include(p => p.Category)
           .Where(product => product.Deleted == false)
            .Where(p => p.Id == id)
           .Select(p => new ProductResponse
           {
               Id = p.Id,
               Name = p.Name,
               Category = _context.categories
                    .Where(c => c.Id == p.CategoryId)
                    .FirstOrDefault(),
               Description = p.Description,
               Discount = p.Discount,
               BasePrice = p.BasePrice,
               Slug = p.Slug,
               View = p.View,
               Like = p.Like,
               Thumbnail = p.Thumbnail,
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
           })
            .FirstOrDefaultAsync();
        }

        public async Task<ProductResponse?> ProductDetailClient(int? id, string? slug)
        {
            return await _context.products
           .Include(p => p.Discount)
           .Include(p => p.Category)
           .Where(product => product.Deleted == false)
           .Where(p => id == null ? true : (p.Id == id))
           .Where(p => slug == null ? true : (p.Slug.Contains(slug)))
           .Select(p => new ProductResponse
            {
                Id = p.Id,
                Name = p.Name,
                //Category = _context.categories
                //    .Where(c => c.Id == p.CategoryId)
                //    .FirstOrDefault(),
                Description = p.Description,
                Discount = p.Discount,
                BasePrice = p.BasePrice,
                Slug = p.Slug,
                //View = p.View,
                //Like = p.Like,
                Thumbnail = p.Thumbnail,
                Status = p.Status,
                UpdatedAt = p.UpdatedAt,
                CreatedAt = p.CreatedAt,
                RateAVG = _context.rates
                    .Where(r => r.ProductId == p.Id)
                    .Select(r => r.Star).ToList(),
                VariantColors = _context.variantAttributeValues
                    .Include(varAttVal => varAttVal.Variant)
                    .Include(varAttVal => varAttVal.AttributeValue)
                    .ThenInclude(attVal => attVal.AttributeType)
                    .Where(varAttVal => varAttVal.Variant.ProductId == p.Id && varAttVal.AttributeValue.AttributeType.Name == "Color")
                    .Select(varAttVal => new VariantColorReponse
                    {
                        VariantId = varAttVal.VariantId,
                        Color = varAttVal.AttributeValue.Value,
                        ColorId = varAttVal.AttributeValueId,
                        Thumbnail = varAttVal.Variant.Thumbnail,
                        Price = varAttVal.Variant.Price
                    }).ToList(),
                Tags = _context.tags.Join(
                    _context.productTags,
                    t => t.Id,
                    pt => pt.TagId,
                    (t, pt) => new { t, pt }
                ).Where(res => res.pt.ProductId == p.Id)
                .Select(res => res.t).ToList(),
                //AttributeTypes = _context.attributeTypes.Join(
                //    _context.productAttributeTypes,
                //    at => at.Id,
                //    pat => pat.AttributeTypeId,
                //    (at, pat) => new { at, pat }
                //).Where(res => res.pat.ProductId == p.Id)
                //.Select(res => res.at).ToList()
            })
            .FirstOrDefaultAsync();
        }

        public async Task<List<ProductResponse>> GetAllProductClient()
        {
            return await _context.products
           .Include(p => p.Discount)
           .Include(p => p.Category)
           .Where(product => product.Deleted == false)
           .Select(p => new ProductResponse
           {
               Id = p.Id,
               Name = p.Name,
               //Category = _context.categories
               //     .Where(c => c.Id == p.CategoryId)
               //     .FirstOrDefault(),
               Description = p.Description,
               Discount = p.Discount,
               BasePrice = p.BasePrice,
               Slug = p.Slug,
               //View = p.View,
               //Like = p.Like,
               Thumbnail = p.Thumbnail,
               Status = p.Status,
               UpdatedAt = p.UpdatedAt,
               CreatedAt = p.CreatedAt,
               RateAVG = _context.rates
                    .Where(r => r.ProductId == p.Id)
                    .Select(r => r.Star).ToList(),
               VariantColors = _context.variantAttributeValues
                    .Include(varAttVal => varAttVal.Variant)
                    .Include(varAttVal => varAttVal.AttributeValue)
                    .ThenInclude(attVal => attVal.AttributeType)
                    .Where(varAttVal => varAttVal.Variant.ProductId == p.Id && varAttVal.AttributeValue.AttributeType.Name == "Color")
                    .Select(varAttVal => new VariantColorReponse
                    {
                        VariantId = varAttVal.VariantId,
                        Color = varAttVal.AttributeValue.Value,
                        ColorId = varAttVal.AttributeValueId,
                        Thumbnail = varAttVal.Variant.Thumbnail,
                        Price = varAttVal.Variant.Price
                    }).ToList(),
               Tags = _context.tags.Join(
                    _context.productTags,
                    t => t.Id,
                    pt => pt.TagId,
                    (t, pt) => new { t, pt }
                ).Where(res => res.pt.ProductId == p.Id)
                .Select(res => res.t).ToList(),
               //AttributeTypes = _context.attributeTypes.Join(
               //     _context.productAttributeTypes,
               //     at => at.Id,
               //     pat => pat.AttributeTypeId,
               //     (at, pat) => new { at, pat }
               // ).Where(res => res.pat.ProductId == p.Id)
               // .Select(res => res.at).ToList()
           })
            .ToListAsync();
        }

        public async Task<List<ProductResponse>> GetAllProductAdmin()
        {
            return await _context.products
           .Include(p => p.Discount)
           .Include(p => p.Category)
           .Where(product => product.Deleted == false)
           .Select(p => new ProductResponse
            {
                Id = p.Id,
                Name = p.Name,
                Category = _context.categories
                    .Where(c => c.Id == p.CategoryId)
                    .FirstOrDefault(),
                Description = p.Description,
                Discount = p.Discount,
                BasePrice = p.BasePrice,
                Slug = p.Slug,
                View = p.View,
                Like = p.Like,
                Thumbnail = p.Thumbnail,
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
            })
            .ToListAsync();
        }

        public async Task<List<ProductResponse>> FilterProduct(List<ProductResponse> products, Func<ProductResponse, bool> predicate)
        {
            return products.Where(predicate).ToList();
        }


        public async Task<Product> AddProduct(Product product, List<string>? keywords)
        {
            product.ProductKeywords = new List<ProductKeyword>();

            foreach(var keyword in keywords)
            {
                Keyword? keywordMatch = await this._context.keywords
                    .Where(k => k.Key == keyword)
                    .FirstOrDefaultAsync();

                if(keywordMatch == null)
                {
                    Keyword keywordInsert = new Keyword()
                    {
                        Key = keyword,
                        CreatedAt = DateTime.Now.ToString()
                    };

                    await this._context.keywords.AddAsync(keywordInsert);

                    product.ProductKeywords.Add(new ProductKeyword
                    {
                        KeywordId = keywordInsert.Id
                    });
                }
                else
                {
                    product.ProductKeywords.Add(new ProductKeyword
                    {
                        KeywordId = keywordMatch.Id
                    });
                }
            }

            await this._context.products.AddAsync(product);

            await this._context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> UpdateProduct(Product productUpdate, int id)
        {
            Product? product = await this._context.products
                .Include(p => p.ProductAttributeTypes)
                .Include(p => p.ProductTags)
                .Where(product => product.Deleted == false)
                .Where(product => product.Id == id)
                .FirstOrDefaultAsync();

            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            product.Name = productUpdate.Name;
            product.Description = productUpdate.Description;
            product.CategoryId = productUpdate.CategoryId;
            product.BasePrice = productUpdate.BasePrice;
            product.DiscountId = productUpdate.DiscountId;

            product.ProductAttributeTypes.Clear();
            product.ProductAttributeTypes.AddRange(productUpdate.ProductAttributeTypes);

            product.ProductTags.Clear();
            product.ProductTags.AddRange(productUpdate.ProductTags);

            if (productUpdate.Thumbnail != "")
            {
                product.Thumbnail = productUpdate.Thumbnail;
            }

            product.Slug = productUpdate.Slug;
            product.UpdatedAt = productUpdate.UpdatedAt;

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
                throw new ArgumentNullException("Product not found!");
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
