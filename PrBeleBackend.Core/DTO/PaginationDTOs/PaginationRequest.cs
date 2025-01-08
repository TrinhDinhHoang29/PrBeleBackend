using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.DTO.Pagination
{
    public class PaginationRequest
    {
        [DefaultValue(1)]
        public int Page { get; set; }

        [DefaultValue(4)]
        //[Required]
        public int Limit { get; set; }
    }
}
