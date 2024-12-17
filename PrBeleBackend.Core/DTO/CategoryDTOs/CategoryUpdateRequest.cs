using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.DTO.CategoryDTOs
{
    public class CategoryUpdateRequest
    {


        [Required]
        public string? Name { get; set; }

        public int ReferenceCategoryId { get; set; }
        [Required]
        public int Status { get; set; }


    }
}
