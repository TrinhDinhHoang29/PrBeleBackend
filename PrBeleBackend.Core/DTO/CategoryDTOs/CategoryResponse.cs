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
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? ReferenceCategoryId { get; set; }
        public int Status { get; set; }
        public string? Slug { get; set; }
        public bool Deleted { get; set; } = false;
    }
}
