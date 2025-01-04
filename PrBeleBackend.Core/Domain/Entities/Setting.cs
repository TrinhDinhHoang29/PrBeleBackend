using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Domain.Entities
{
    public class Setting
    {
        public int Id { get; set; }
        public string? Slogan { get; set; }
        public string? Hotline { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? FacebookLink { get; set; }
        public string? ZaloLink { get; set; }
        public string? InstagramLink { get; set; }
        public string? TiktokLink { get; set; }
        public string? YoutubeLink { get; set; }
    }
}
