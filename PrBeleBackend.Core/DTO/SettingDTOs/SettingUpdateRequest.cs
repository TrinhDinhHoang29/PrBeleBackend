using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.DTO.SettingDTOs
{
    public class SettingUpdateRequest
    {
        [Required]
        public IFormFile? MainLogo { get; set; }
        [Required]

        public IFormFile? SloganLogo { get; set; }
        [Required]
        public string? Slogan { get; set; }
        [Required]
        public string? Hotline { get; set; }
        [Required]
        public string? Email { get; set; }

        [Required]
        public string? BranchName1 { get; set; }
        [Required]
        public string? BranchAddress1 { get; set; }
        [Required]
        public string? BranchName2 { get; set; }
        [Required]
        public string? BranchAddress2 { get; set; }

        [Required]
        public string? FacebookLink { get; set; }
        [Required]
        public string? InstagramLink { get; set; }
        [Required]
        public string? YoutubeLink { get; set; }
        [Required]
        public IFormFile? MainBanner { get; set; }
        [Required]
        public IFormFile? SubBanner1 { get; set; }
        [Required]
        public IFormFile? SubBanner2 { get; set; }
        [Required]
        public IFormFile? SlideshowBanner1 { get; set; }
        [Required]
        public IFormFile? SlideshowBanner2 { get; set; }
        [Required]
        public IFormFile? SlideshowBanner3 { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? ServiceTitle1 { get; set; }
        [Required]
        public string? ServiceInfo1 { get; set; }
        [Required]
        public string? ServiceTitle2 { get; set; }
        [Required]
        public string? ServiceInfo2 { get; set; }
        [Required]
        public string? ServiceTitle3 { get; set; }
        [Required]
        public string? ServiceInfo3 { get; set; }
        [Required]
        public string? ServiceTitle4 { get; set; }
        [Required]
        public string? ServiceInfo4 { get; set; }


    }
}
