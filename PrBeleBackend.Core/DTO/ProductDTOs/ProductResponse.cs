﻿using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.DTO.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PrBeleBackend.Core.DTO.ProductDTOs
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public string Thumbnail { get; set; }
        public string Description { get; set; }
        public string Discount { get; set; }
        public decimal BasePrice { get; set; }
        public string Slug { get; set; }
        public int View { get; set; }
        public int Like { get; set; }
        public int Status { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<AttributeType> AttributeTypes { get; set; }
    }

    //public static class ProductResponseExtensions
    //{
    //    /// <summary>
    //    /// Đây là hàm dùng để convert từ Model category sang CategoryResponse
    //    /// </summary>
    //    public static ProductResponse ToCategoryResponse(this Product product)
    //    {
    //        return new ProductResponse()
    //        {
    //            Id = product.Id,
    //            Name = product.Name,
    //            Category 
    //        };
    //    }
    //}
}
