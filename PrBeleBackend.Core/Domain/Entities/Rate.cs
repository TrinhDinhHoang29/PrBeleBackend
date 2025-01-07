using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Domain.Entities
{
    public class Rate
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        [StringLength(16)]
        public string? UserType { get; set; }
        public int UserId { get; set; }
        public int Star { get; set; }
        [StringLength(255)]
        public string? Content { get; set; }
        public int ReferenceRateId { get; set; }
        public int Status { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Product? Product { get; set; }
        public Customer? Customer { get; set; }
        public Account? Account { get; set; }
        public Rate? RateReference { get; set; }

    }
}
