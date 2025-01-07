using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.SettingDTOs;
using PrBeleBackend.Core.Helpers;
using PrBeleBackend.Core.ServiceContracts.SettingContracts;


namespace PrBeleBackend.Core.Services.SettingServices
{
    public class SettingUpdaterService : ISettingUpdaterService
    {
        private readonly ISettingRepository _settingRepository;
        public SettingUpdaterService(ISettingRepository settingRepository)
        {
            _settingRepository = settingRepository;
        }
        public async Task<Setting> UpdateSetting(SettingUpdateRequest settingUpdateRequest)
        {
            ValidationHelper.ModelValidation(settingUpdateRequest);
            Setting setting = await _settingRepository.UpdateSetting(settingUpdateRequest.ToSetting());
            return setting;
        }
    }
}
