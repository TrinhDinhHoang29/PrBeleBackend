

using PrBeleBackend.Core.Domain.Entities;

namespace PrBeleBackend.Core.Domain.RepositoryContracts
{
    public interface ISettingRepository
    {
        public Task<Setting> GetSetting();
        public Task<Setting> UpdateSetting(Setting setting);

    }
}
