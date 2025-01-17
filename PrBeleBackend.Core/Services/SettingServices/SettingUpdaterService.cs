using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.SettingDTOs;
using PrBeleBackend.Core.Helpers;
using PrBeleBackend.Core.ServiceContracts;
using PrBeleBackend.Core.ServiceContracts.SettingContracts;


namespace PrBeleBackend.Core.Services.SettingServices
{
    public class SettingUpdaterService : ISettingUpdaterService
    {
        private readonly ISettingRepository _settingRepository;
        private readonly ICloudinaryContract _cloudinaryContract;
        public SettingUpdaterService(ISettingRepository settingRepository,
            ICloudinaryContract cloudinaryContract)
        {
            _settingRepository = settingRepository;
            _cloudinaryContract = cloudinaryContract;
        }
        public async Task<Setting> UpdateSetting(SettingUpdateRequest settingUpdateRequest)
        {
            string mainLogo = "";
            string sloganLogo = "";
            string mainBanner = "";
            string subBanner1 = "";
            string subBanner2 = "";
            string slideshowBanner1="";
            string slideshowBanner2 = "";
            string slideshowBanner3 = "";

            if (settingUpdateRequest.MainLogo!=null)
                 mainLogo = await _cloudinaryContract.UploadImageAsync(settingUpdateRequest.MainLogo, "Settings", 2000, 1000);
            if (settingUpdateRequest.SloganLogo != null)
                sloganLogo = await _cloudinaryContract.UploadImageAsync(settingUpdateRequest.SloganLogo, "Settings", 2000, 1000);
            if (settingUpdateRequest.MainBanner != null)
                 mainBanner = await _cloudinaryContract.UploadImageAsync(settingUpdateRequest.MainBanner, "Settings", 1722, 620);
            if (settingUpdateRequest.SubBanner1 != null)
                subBanner1 = await _cloudinaryContract.UploadImageAsync(settingUpdateRequest.SubBanner1, "Settings", 820, 620);
            if (settingUpdateRequest.SubBanner2 != null)
                 subBanner2 = await _cloudinaryContract.UploadImageAsync(settingUpdateRequest.SubBanner2, "Settings", 820, 620);
            if (settingUpdateRequest.SlideshowBanner1 != null)
                slideshowBanner1 = await _cloudinaryContract.UploadImageAsync(settingUpdateRequest.SlideshowBanner1, "Settings", 1920, 787);
            if (settingUpdateRequest.SlideshowBanner2 != null)
                 slideshowBanner2 = await _cloudinaryContract.UploadImageAsync(settingUpdateRequest.SlideshowBanner2, "Settings", 1920, 787);
            if (settingUpdateRequest.SlideshowBanner3 != null)
                slideshowBanner3 = await _cloudinaryContract.UploadImageAsync(settingUpdateRequest.SlideshowBanner3, "Settings", 1920, 787);
            ValidationHelper.ModelValidation(settingUpdateRequest);

            Setting setting = settingUpdateRequest.ToSetting();
            setting.MainLogo = mainLogo;
            setting.SloganLogo = sloganLogo;
            setting.MainBanner = mainBanner;
            setting.SubBanner1 = subBanner1;
            setting.SubBanner2 = subBanner2;
            setting.SlideshowBanner1 = slideshowBanner1;
            setting.SlideshowBanner2 = slideshowBanner2;
            setting.SlideshowBanner3 = slideshowBanner3;
            ValidationHelper.ModelValidation(setting);

            Setting result = await _settingRepository.UpdateSetting(setting);
            return result;
        }
    }
}
