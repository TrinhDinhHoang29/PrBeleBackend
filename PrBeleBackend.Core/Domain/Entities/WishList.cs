using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Domain.Entities
{
    public class WishList
    {
        public int CustomerId { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public Customer Customer { get; set; }
    }
}
