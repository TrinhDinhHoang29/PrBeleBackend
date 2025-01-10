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
            ValidationHelper.ModelValidation(settingUpdateRequest);

            string mainLogo = await _cloudinaryContract.UploadImageAsync(settingUpdateRequest.MainLogo, "Settings", 200, 100);
            string sloganLogo = await _cloudinaryContract.UploadImageAsync(settingUpdateRequest.SloganLogo, "Settings", 200, 100);
            string mainBanner = await _cloudinaryContract.UploadImageAsync(settingUpdateRequest.MainBanner, "Settings", 861, 310);
            string subBanner1 = await _cloudinaryContract.UploadImageAsync(settingUpdateRequest.SubBanner1, "Settings", 85, 62);
            string subBanner2 = await _cloudinaryContract.UploadImageAsync(settingUpdateRequest.SubBanner2, "Settings", 85, 62);
            string slideshowBanner1 = await _cloudinaryContract.UploadImageAsync(settingUpdateRequest.SlideshowBanner1, "Settings", 1920, 787);
            string slideshowBanner2 = await _cloudinaryContract.UploadImageAsync(settingUpdateRequest.SlideshowBanner2, "Settings", 1920, 787);
            string slideshowBanner3 = await _cloudinaryContract.UploadImageAsync(settingUpdateRequest.SlideshowBanner3, "Settings", 1920, 787);


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
