using PrBeleBackend.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.SettingContracts
{
    public interface ISettingGetterService
    {
        public Task<Setting> GetSetting();
    }
}
