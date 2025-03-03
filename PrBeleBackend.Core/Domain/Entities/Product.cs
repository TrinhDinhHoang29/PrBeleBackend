﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrBeleBackend.Core.DTO.ProductDTOs;

namespace PrBeleBackend.Core.Domain.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        //public string? DescriptionPlainText { get; set; }
        public int CategoryId { get; set; }
        public string? Thumbnail { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal BasePrice { get; set; }

        public int View { get; set; }

        public int Like { get; set; }

        public int DiscountId { get; set; }

        public string? Slug { get; set; }

        public string? KeyWord { get; set; }

        public int Status { get; set; }

        public bool Deleted { get; set; } = false;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Category? Category { get; set; }

        public List<WishList> WishList { get; set; }
        public List<ProductKeyword>? ProductKeywords { get; set; }
        public List<ProductAttributeType>? ProductAttributeTypes { get; set; }
        public Discount? Discount { get; set; }
        public List<ProductTag>? ProductTags { get; set; }
        public List<Variant>? Variants { get; set; }
        public List<Rate>? Rates { get; set; }
    }

    public static class ProductExtension
    {
        public static Product ToProduct(this ProductAddRequest productAddRequest)
        {
            List<ProductAttributeType> productAttTyp = new List<ProductAttributeType>();

            foreach (var attributeId in productAddRequest.AttributeTypes)
            {
                productAttTyp.Add(new ProductAttributeType
                {
                    AttributeTypeId = Convert.ToInt32(attributeId)
                });
            }

            List<ProductTag> productTag = new List<ProductTag>();

            foreach (var tag in productAddRequest.Tags)
            {
                productTag.Add(new ProductTag
                {
                    TagId = Convert.ToInt32(tag)
                });
            }

            return new Product
            {
                Name = productAddRequest.Name,
                BasePrice = productAddRequest.BasePrice,
                CategoryId = productAddRequest.CategoryId,
                DiscountId = productAddRequest.DiscountId,
                Status = productAddRequest.Status,
                Description = productAddRequest.Description,
                ProductAttributeTypes = productAttTyp,
                ProductTags = productTag
            };
        }

        public static Product ToProduct(this ProductUpdateRequest productUpdateRequest)
        {
            List<ProductAttributeType> productAttTyp = new List<ProductAttributeType>();

            foreach (var attributeId in productUpdateRequest.AttributeTypes)
            {
                productAttTyp.Add(new ProductAttributeType
                {
                    AttributeTypeId = Convert.ToInt32(attributeId)
                });
            }

            List<ProductTag> productTag = new List<ProductTag>();

            foreach (var tag in productUpdateRequest.Tags)
            {
                productTag.Add(new ProductTag
                {
                    TagId = Convert.ToInt32(tag)
                });
            }

            return new Product
            {
                Name = productUpdateRequest.Name,
                BasePrice = productUpdateRequest.BasePrice,
                CategoryId = productUpdateRequest.CategoryId,
                DiscountId = productUpdateRequest.DiscountId,
                Description = productUpdateRequest.Description,
                ProductAttributeTypes = productAttTyp,
                ProductTags = productTag
            };
        }

        public static Product ToProduct(this ProductResponse productResponse)
        {
            return new Product
            {
                Name = productResponse.Name,
                BasePrice = productResponse.BasePrice,
                CategoryId = productResponse.Category.Id,
                Description = productResponse.Description,
            };
        }
    }
}
