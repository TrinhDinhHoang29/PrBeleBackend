using PrBeleBackend.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.DTO.CustomerDTOs
{
    public class CliCustomerUpdateRequest
    {
        [Required,StringLength(60)]
        public string? name {  get; set; }
        [Required,Phone]
        public string? phone { get; set; }
        [Required]
        public DateTime birthDay { get; set; }
        [Required]
        public SexOptions? sex { get; set; }
    }
}
