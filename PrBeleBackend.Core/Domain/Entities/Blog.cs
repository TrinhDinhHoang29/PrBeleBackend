using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Domain.Entities
{
    public class Blog
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Status { get; set; }

        public int Deleted { get; set; }

        public string CreatedAt { get; set; } 

        public List<BlogContent> Contents { get; set; }
    }
}
