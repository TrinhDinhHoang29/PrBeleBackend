using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Domain.Entities
{
    public class ProductKeyword
    {
        public int ProductId { get; set; }

        public int KeywordId { get; set; }

        public Product Product { get; set; }

        public Keyword Keyword { get; set; }
    }
}
