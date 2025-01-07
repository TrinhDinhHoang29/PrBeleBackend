using Microsoft.EntityFrameworkCore;
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Infrastructure.DbContexts;


namespace PrBeleBackend.Infrastructure.Repositories
{
    public class SettingRepository : ISettingRepository
    {
        private readonly BeleStoreContext _dbContext;
        public SettingRepository(BeleStoreContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Setting> GetSetting()
        {
            return await _dbContext.settings.FirstAsync(set=>set.Id == 1 );
        }

        public async Task<Setting> UpdateSetting(Setting settingRequest)
        {
            Setting setting = await _dbContext.settings.FirstAsync(set => set.Id == 1);
           
            setting.subLogo = settingRequest.subLogo;
            setting.mainLogo = settingRequest.mainLogo;
            setting.Slogan = settingRequest.Slogan;
            setting.Email = settingRequest.Email;
            setting.Address = settingRequest.Address;
            setting.ZaloLink = settingRequest.ZaloLink;
            setting.Hotline = settingRequest.Hotline;
            setting.YoutubeLink = settingRequest.YoutubeLink;
            setting.TiktokLink = settingRequest.TiktokLink;
            setting.FacebookLink = settingRequest.FacebookLink;
            await _dbContext.AddAsync(setting);
            return settingRequest;

        }
    }
}
