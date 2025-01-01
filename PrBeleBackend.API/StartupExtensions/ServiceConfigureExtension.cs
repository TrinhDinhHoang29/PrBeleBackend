using Microsoft.EntityFrameworkCore;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.ServiceContracts;
using PrBeleBackend.Core.ServiceContracts.CategoryContracts;
using PrBeleBackend.Core.ServiceContracts.ProductContracts;
using PrBeleBackend.Core.Services.CategoryServices;
using PrBeleBackend.Core.Services.ProductServices;
using PrBeleBackend.Core.Services;
using PrBeleBackend.Infrastructure.DbContexts;
using PrBeleBackend.Infrastructure.Repositories;
using PrBeleBackend.Core.DTO.Cloudinary;
using CloudinaryDotNet;
using Microsoft.Extensions.Options;
using PrBeleBackend.Core.ServiceContracts;

namespace PrBeleBackend.API.StartupExtensions
{
    public static class ServiceConfigureExtension
    {
        public static void ServiceConfigure(this IServiceCollection Services, IConfiguration configuration)
        {
            Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            Services.AddEndpointsApiExplorer();
            Services.AddSwaggerGen();

            Services.AddDbContext<BeleStoreContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnect"));
            });

            Services.Configure<CloudinaryConfig>(configuration.GetSection("Cloudinary"));
            Services.AddSingleton(provider =>
            {
                var config = provider.GetRequiredService<IOptions<CloudinaryConfig>>().Value;
                return new Cloudinary(new Account(config.CloudName, config.ApiKey, config.ApiSecret));
            });

            #region DI Category
            Services.AddTransient<ICategoryRepository, CategoryRepository>();
            Services.AddTransient<ICategoryAdderService, CategoryAdderService>();
            Services.AddTransient<ICategoryGetterService, CategoryGetterService>();
            Services.AddTransient<ICategoryUpdaterService, CategoryUpdaterService>();
            Services.AddTransient<ICategorySorterService, CategorySorterService>();
            Services.AddTransient<ICategoryDeleterService, CategoryDeleterService>();
            #endregion

            #region DI Product
            Services.AddTransient<IProductRepository, ProductRepository>();
            Services.AddTransient<IProductGetterService, ProductGetterService>();
            Services.AddTransient<IProductUpdaterService, ProductUpdaterService>();
            Services.AddTransient<IProductModifierService, ProductModifierService>();
            #endregion

            #region DI Cloudinary
            Services.AddTransient<ICloudinaryService, CloudinaryService>();
            #endregion

        }
    }
}
