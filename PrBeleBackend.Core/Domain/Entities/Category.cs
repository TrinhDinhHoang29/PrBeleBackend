using PrBeleBackend.Core.DTO.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Domain.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public int ReferenceCategoryId { get; set; }
        [Required]
        public int Status { get; set; }

        [Required]
        public string? Slug { get; set; }
        public bool Deleted { get; set; } = false;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<Product>? Products { get; set; }
    }
    public static class CategoryExtensions
    {
        /// <summary>
        /// Đây là hàm dùng để convert từ Model CategoryAddRequest sang Category
        /// </summary>
        public static Category ToCategory(this CategoryAddRequest categoryAddRequest)
        {
            return new Category()
            {
                Name = categoryAddRequest.Name,
                ReferenceCategoryId = categoryAddRequest.ReferenceCategoryId,
                Status = categoryAddRequest.Status,
                //CreatedAt = category.CreatedAt,
                //UpdatedAt = category.UpdatedAt,

            };
        }
        public static Category ToCategory(this CategoryUpdateRequest categoryUpdateRequest)
        {
            return new Category()
            {
                Name = categoryUpdateRequest.Name,
                ReferenceCategoryId = categoryUpdateRequest.ReferenceCategoryId,
                Status = categoryUpdateRequest.Status,
                //CreatedAt = category.CreatedAt,
                //UpdatedAt = category.UpdatedAt,

            };
        }
    }
}
