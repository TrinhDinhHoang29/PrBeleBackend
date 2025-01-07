using PrBeleBackend.Core.DTO.SettingDTOs;

namespace PrBeleBackend.Core.Domain.Entities
{
    public class Setting
    {
        public int Id { get; set; }
        public string? mainLogo { get; set; }
        public string? subLogo { get; set; }
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
    public static class SettingExtension
    {
        public static Setting ToSetting(this SettingUpdateRequest settingUpdateRequest)
        {
            return new Setting
            {
                mainLogo = settingUpdateRequest.MainLogo,
                subLogo = settingUpdateRequest.SubLogo,
                Slogan = settingUpdateRequest.Slogan,
                Hotline = settingUpdateRequest.Hotline,
                Email = settingUpdateRequest.Email,
                Address = settingUpdateRequest.Address,
                FacebookLink = settingUpdateRequest.FacebookLink,
                ZaloLink = settingUpdateRequest.ZaloLink,
                TiktokLink = settingUpdateRequest.TiktokLink,
                InstagramLink = settingUpdateRequest.InstagramLink,
                YoutubeLink = settingUpdateRequest.YoutubeLink,
            };
        }
    }
}
