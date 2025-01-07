using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.DTO.SettingDTOs;
using PrBeleBackend.Core.Services.SettingServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.SettingContracts
{
    public interface ISettingUpdaterService
    {
        public Task<Setting> UpdateSetting(SettingUpdateRequest settingUpdateRequest);
    }
}
