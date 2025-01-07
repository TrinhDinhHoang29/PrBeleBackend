using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.ServiceContracts.SettingContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Services.SettingServices
{
    public class SettingGetterService : ISettingGetterService
    {
        private readonly ISettingRepository _settingRepository;
        public SettingGetterService(ISettingRepository settingRepository)
        {
            _settingRepository = settingRepository;
        }
        public Task<Setting> GetSetting()
        {
            return _settingRepository.GetSetting();
        }
    }
}
