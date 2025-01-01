using Microsoft.EntityFrameworkCore;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.ServiceContracts.AccountContracts;
using PrBeleBackend.Core.ServiceContracts.CategoryContracts;
using PrBeleBackend.Core.ServiceContracts.ProductContracts;
using PrBeleBackend.Core.ServiceContracts.RoleContracts;
using PrBeleBackend.Core.Services.AccountServices;
using PrBeleBackend.Core.Services.CategoryServices;
using PrBeleBackend.Core.Services.ProductServices;
using PrBeleBackend.Core.Services.RoleServices;
using PrBeleBackend.Infrastructure.DbContexts;
using PrBeleBackend.Infrastructure.Repositories;
using System.Text.Json.Serialization;

namespace PrBeleBackend.API.StartupExtensions
{
    public static class ServiceConfigureExtension
    {
        public static void ServiceConfigure(this IServiceCollection Services, IConfiguration configuration)
        {
            Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });
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

            #region DI Account
            Services.AddScoped<IAccountRepository, AccountRepository>();
            Services.AddScoped<IAccountAdderService,AccountAdderService>();
            Services.AddScoped<IAccountGetterService,AccountGetterService>();
            Services.AddScoped<IAccountUpdaterService,AccountUpdaterService>();
            Services.AddScoped<IAccountDeleterService,AccountDeleterService>();
            Services.AddScoped<IAccountSorterService, AccountSorterService>();
            #endregion

            #region DI Role
            Services.AddScoped<IRoleRepository,RoleRepository>();
            Services.AddScoped<IRoleGetterService,RoleGetterService>();
            Services.AddScoped<IRoleAdderService,RoleAdderService>();
            #endregion
        }
    }
}
