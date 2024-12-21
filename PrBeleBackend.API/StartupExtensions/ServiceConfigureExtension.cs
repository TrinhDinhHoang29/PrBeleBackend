using Microsoft.EntityFrameworkCore;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.ServiceContracts.CategoryContracts;
using PrBeleBackend.Core.ServiceContracts.ProductContracts;
using PrBeleBackend.Core.Services.CategoryServices;
using PrBeleBackend.Core.Services.ProductServices;
using PrBeleBackend.Infrastructure.DbContexts;
using PrBeleBackend.Infrastructure.Repositories;

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

            #region DI Category
            Services.AddScoped<ICategoryRepository, CategoryRepository>();
            Services.AddScoped<ICategoryAdderService, CategoryAdderService>();
            Services.AddScoped<ICategoryGetterService, CategoryGetterService>();
            Services.AddScoped<ICategoryUpdaterService, CategoryUpdaterService>();
            Services.AddScoped<ICategorySorterService, CategorySorterService>();
            Services.AddScoped<ICategoryDeleterService, CategoryDeleterService>();

            Services.AddScoped<IProductRepository, ProductRepository>();
            Services.AddScoped<IProductGetterService, ProductGetterService>();

            #endregion


        }
    }
}
