using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.DTO.ContactDTOs
{
    public class ContactUpdatePatchRequest
    {
        [Required]
        [Range(0, 1, ErrorMessage = "Status must be either 0 or 1.")]
        public int Status { get; set; }
    }
}
