using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Domain.Entities
{
    public class BlogContent
    {
        public int Id { get; set; }

        public int BlogId { get; set; }

        public string ContentType { get; set; }

        public string ContentText { get; set; }

        public string ImageUrl { get; set; }

        public int Order { get; set; }

        public Blog Blog { get; set; }
    }
}
