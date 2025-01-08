﻿using System;
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
        public string? mainLogo { get; set; }
        [Required]
        public string? subLogo { get; set; }
        [Required]

        public string? Slogan { get; set; }
        [Required]

        public string? Hotline { get; set; }
        [Required]

        public string? Email { get; set; }
        [Required]

        public string? Address { get; set; }
        [Required]

        public string? FacebookLink { get; set; }
        [Required]

        public string? ZaloLink { get; set; }
        [Required]

        public string? InstagramLink { get; set; }
        [Required]

        public string? TiktokLink { get; set; }
        [Required]

        public string? YoutubeLink { get; set; }

    }
}