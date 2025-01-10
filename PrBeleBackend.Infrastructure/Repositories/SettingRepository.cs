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
           
            setting.MainLogo = settingRequest.MainLogo;
            setting.SloganLogo = settingRequest.SloganLogo;
            setting.Slogan = settingRequest.Slogan;
            setting.Hotline = settingRequest.Hotline;
            setting.Email = settingRequest.Email;
            setting.BranchAddress1 = settingRequest.BranchAddress1;
            setting.BranchAddress2 = settingRequest.BranchAddress2;
            setting.BranchName1 = settingRequest.BranchName1;
            setting.BranchName2 = settingRequest.BranchName2;
            setting.FacebookLink = settingRequest.FacebookLink;
            setting.InstagramLink = settingRequest.InstagramLink;
            setting.YoutubeLink = settingRequest.YoutubeLink;
            setting.MainBanner = settingRequest.MainBanner;
            setting.SubBanner1 = settingRequest.SubBanner1;
            setting.SubBanner2 = settingRequest.SubBanner2;
            setting.SlideshowBanner1 = settingRequest.SlideshowBanner1;
            setting.SlideshowBanner2 = settingRequest.SlideshowBanner2;
            setting.SlideshowBanner3 = settingRequest.SlideshowBanner3;
            setting.Description = settingRequest.Description;
            setting.ServiceInfo1 = settingRequest.ServiceInfo1;
            setting.ServiceInfo2 = settingRequest.ServiceInfo2;
            setting.ServiceInfo3 = settingRequest.ServiceInfo3;
            setting.ServiceInfo4 = settingRequest.ServiceInfo4;
            setting.ServiceTitle1 = settingRequest.ServiceTitle1;
            setting.ServiceTitle2 = settingRequest.ServiceTitle2;
            setting.ServiceTitle3 = settingRequest.ServiceTitle3;
            setting.ServiceTitle4 = settingRequest.ServiceTitle4;

            await _dbContext.SaveChangesAsync();
            return setting;

        }
    }
}
