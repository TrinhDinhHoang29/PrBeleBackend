using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.ServiceContracts.AccountContracts;
using PrBeleBackend.Core.ServiceContracts.AuthContracts;
using PrBeleBackend.Core.ServiceContracts.CategoryContracts;
using PrBeleBackend.Core.ServiceContracts.ContactContracts;
using PrBeleBackend.Core.ServiceContracts.CustomerContracts;
using PrBeleBackend.Core.ServiceContracts.JwtContracts;
using PrBeleBackend.Core.ServiceContracts.ProductContracts;
using PrBeleBackend.Core.ServiceContracts.RoleContracts;
using PrBeleBackend.Core.Services.AccountServices;
using PrBeleBackend.Core.Services.AuthServices;
using PrBeleBackend.Core.Services.CategoryServices;
using PrBeleBackend.Core.Services.ContactServices;
using PrBeleBackend.Core.Services.CustomerServices;
using PrBeleBackend.Core.Services.JwtServices;
using PrBeleBackend.Core.Services.ProductServices;
using PrBeleBackend.Core.Services.RoleServices;
using PrBeleBackend.Infrastructure.DbContexts;
using PrBeleBackend.Infrastructure.Repositories;
using System.Text;
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

            Services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Description = "Please enter JWT with Bearer into field",
                    Name = "Authorization",
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
            });

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

            #region DI Customer
            Services.AddScoped<ICustomerRepository, CustomerRepository>();
            Services.AddScoped<ICustomerGetterService, CustomerGetterService>();
            Services.AddScoped<ICustomerSorterService, CustomerSorterService>();
            Services.AddScoped<ICustomerUpdaterService, CustomerUpdaterService>();
            Services.AddScoped<ICustomerDeleterService, CustomerDeleterService>();

            #endregion

            #region DI Contact
            Services.AddScoped<IContactRepository,ContactRepository>();
            Services.AddScoped<IContactGetterSerivce, ContactGetterService>();
            Services.AddScoped<IContactUpdaterService, ContactUpdaterService>();
            Services.AddScoped<IContactDeleterService, ContactDeleterService>();
            Services.AddScoped<IContactSorterService, ContactSorterService>();
            #endregion

            #region DI Auth
            Services.AddScoped<IAuthService, AuthService>();
            #endregion

            #region DI Jwt
            Services.AddTransient<IJwtService, JwtService>();
            #endregion
        }
    }
}
