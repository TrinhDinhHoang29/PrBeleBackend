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
            string sublogo = await _cloudinaryContract.UploadImageAsync(settingUpdateRequest.SubLogoFile, "Settings", 400, 400);
            string mainlogo = await _cloudinaryContract.UploadImageAsync(settingUpdateRequest.MainLogoFile, "Settings", 400, 400);
            string slogan= await _cloudinaryContract.UploadImageAsync(settingUpdateRequest.SloganFile, "Settings", 400, 400);
            settingUpdateRequest.SubLogo = sublogo;
            settingUpdateRequest.MainLogo = mainlogo;
            settingUpdateRequest.Slogan = slogan;
            ValidationHelper.ModelValidation(settingUpdateRequest);
            Setting setting = await _settingRepository.UpdateSetting(settingUpdateRequest.ToSetting());
            return setting;
        }
    }
}
