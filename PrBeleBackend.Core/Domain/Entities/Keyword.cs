using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Domain.Entities
{
    public class Keyword
    {
        [Key]
        public int Id { get; set; }

        public string Key { get; set; }

        [Required]
        public string CreatedAt { get; set; }

        public List<ProductKeyword> ProductKeywords { get; set; }
    }
}
