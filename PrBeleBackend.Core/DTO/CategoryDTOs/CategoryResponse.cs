using PrBeleBackend.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.DTO.CategoryDTOs
{
    public class CategoryResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int ReferenceCategoryId { get; set; }
        public int Status { get; set; }
        public string? Slug { get; set; }
        public bool Deleted { get; set; } = false;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public static class CategoryResponseExtensions
    {
        /// <summary>
        /// Đây là hàm dùng để convert từ Model category sang CategoryResponse
        /// </summary>
        public static CategoryResponse ToCategoryResponse (this Category category)
        {
            return new CategoryResponse()
            {
                Id = category.Id,
                Name = category.Name,
                ReferenceCategoryId = category.ReferenceCategoryId,
                Status = category.Status,
                Slug = category.Slug,
                Deleted = category.Deleted,
                CreatedAt = category.CreatedAt,
                UpdatedAt = category.UpdatedAt,

            };
        }
    }
}
