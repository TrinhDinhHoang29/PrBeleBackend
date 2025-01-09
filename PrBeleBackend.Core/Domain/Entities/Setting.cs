using PrBeleBackend.Core.DTO.SettingDTOs;

namespace PrBeleBackend.Core.Domain.Entities
{
    public class Setting
    {
        public int Id { get; set; }
        public string? MainLogo { get; set; }
        public string? SloganLogo { get; set; }
        public string? Slogan { get; set; }
        public string? Hotline { get; set; }
        public string? Email { get; set; }

        public string? BranchName1 { get; set; }
        public string? BranchAddress1 { get; set; }
        public string? BranchName2 { get; set; }
        public string? BranchAddress2 { get; set; }

        public string? FacebookLink { get; set; }
        public string? InstagramLink { get; set; }
        public string? YoutubeLink { get; set; }
        public string? MainBanner { get; set; }
        public string? SubBanner1 { get; set; }
        public string? SubBanner2 { get; set; }
        public string? SlideshowBanner1 { get; set; }
        public string? SlideshowBanner2 { get; set; }
        public string? SlideshowBanner3 { get; set; }
        public string? Description { get; set; }
        public string? ServiceTitle1 { get; set; }
        public string? ServiceInfo1 { get; set; }
        public string? ServiceTitle2 { get; set; }
        public string? ServiceInfo2 { get; set; }
        public string? ServiceTitle3 { get; set; }
        public string? ServiceInfo3 { get; set; }
        public string? ServiceTitle4 { get; set; }
        public string? ServiceInfo4 { get; set; }


    }
    public static class SettingExtension
    {
        public static Setting ToSetting(this SettingUpdateRequest settingUpdateRequest)
        {
            return new Setting
            {
                Slogan = settingUpdateRequest.Slogan,
                Hotline = settingUpdateRequest.Hotline,
                Email = settingUpdateRequest.Email,
                BranchName1 = settingUpdateRequest.BranchName1,
                BranchAddress1 = settingUpdateRequest.BranchAddress1,
                BranchName2 = settingUpdateRequest.BranchName2,
                BranchAddress2 = settingUpdateRequest.BranchAddress2,
                FacebookLink = settingUpdateRequest.FacebookLink,
                InstagramLink = settingUpdateRequest.InstagramLink,
                YoutubeLink = settingUpdateRequest.YoutubeLink,
                Description = settingUpdateRequest.Description,
                ServiceInfo1 = settingUpdateRequest.ServiceInfo1,
                ServiceInfo2 = settingUpdateRequest.ServiceInfo2,
                ServiceInfo3 = settingUpdateRequest.ServiceInfo3,   
                ServiceInfo4 = settingUpdateRequest.ServiceInfo4,
                ServiceTitle1 = settingUpdateRequest.ServiceTitle1,
                ServiceTitle2 = settingUpdateRequest.ServiceTitle2,
                ServiceTitle3 = settingUpdateRequest.ServiceTitle3,
                ServiceTitle4 = settingUpdateRequest.ServiceTitle4,
            };
        }
    }
}
