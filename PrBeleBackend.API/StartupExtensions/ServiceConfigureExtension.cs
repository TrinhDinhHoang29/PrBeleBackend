using CloudinaryDotNet;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
//using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.Cloudinary;
using PrBeleBackend.Core.ServiceContracts;
using PrBeleBackend.Core.ServiceContracts.AccountContracts;
using PrBeleBackend.Core.ServiceContracts.AttributeContracts;
using PrBeleBackend.Core.ServiceContracts.AuthContracts;
using PrBeleBackend.Core.ServiceContracts.CategoryContracts;
using PrBeleBackend.Core.ServiceContracts.ContactContracts;
using PrBeleBackend.Core.ServiceContracts.CustomerContracts;
using PrBeleBackend.Core.ServiceContracts.DiscountContracts;
using PrBeleBackend.Core.ServiceContracts.JwtContracts;
using PrBeleBackend.Core.ServiceContracts.OrderContracts;
using PrBeleBackend.Core.ServiceContracts.ProductContracts;
using PrBeleBackend.Core.ServiceContracts.RateContracts;
using PrBeleBackend.Core.ServiceContracts.RoleContracts;
using PrBeleBackend.Core.ServiceContracts.SettingContracts;
using PrBeleBackend.Core.ServiceContracts.VariantContracts;
using PrBeleBackend.Core.Services;
using PrBeleBackend.Core.Services.AccountServices;
using PrBeleBackend.Core.Services.AttributeServices;
using PrBeleBackend.Core.Services.AuthServices;
using PrBeleBackend.Core.Services.CategoryServices;
using PrBeleBackend.Core.Services.ContactServices;
using PrBeleBackend.Core.Services.CustomerServices;
using PrBeleBackend.Core.Services.DiscountServices;
using PrBeleBackend.Core.Services.JwtServices;
using PrBeleBackend.Core.Services.OrderServices.cs;
using PrBeleBackend.Core.Services.ProductServices;
using PrBeleBackend.Core.Services.RateServices;
using PrBeleBackend.Core.Services.RoleServices;
using PrBeleBackend.Core.Services.SettingServices;
using PrBeleBackend.Core.Services.VariantServices;
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

            Services.Configure<CloudinaryConfig>(configuration.GetSection("Cloudinary"));
            Services.AddSingleton(provider =>
            {
                var config = provider.GetRequiredService<IOptions<CloudinaryConfig>>().Value;
                return new Cloudinary(new Account(config.CloudName, config.ApiKey, config.ApiSecret));
            });

            #region DI Category
            Services.AddScoped<ICategoryRepository, CategoryRepository>();
            Services.AddScoped<ICategoryAdderService, CategoryAdderService>();
            Services.AddScoped<ICategoryGetterService, CategoryGetterService>();
            Services.AddScoped<ICategoryUpdaterService, CategoryUpdaterService>();
            Services.AddScoped<ICategorySorterService, CategorySorterService>();
            Services.AddScoped<ICategoryDeleterService, CategoryDeleterService>();
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

            #region DI Product
            Services.AddScoped<IProductRepository, ProductRepository>();
            Services.AddScoped<IProductGetterService, ProductGetterService>();
            Services.AddScoped<IProductAdderService, ProductAdderService>();
            Services.AddScoped<IProductUpdaterService, ProductUpdaterService>();
            Services.AddScoped<IProductModifierService, ProductModifierService>();
            Services.AddScoped<IProductDeleterService, ProductDeleterService>();
            Services.AddScoped<IProductSorterService, ProductSorterService>();
            #endregion

            #region DI Attribute
            Services.AddScoped<IAttributeRepository, AttributeRepository>();
            Services.AddScoped<IAttributeGetterService, AttributeGetterService>();
            Services.AddScoped<IAttributeAdderService, AttributeAdderService>();
            Services.AddScoped<IAttributeDeleterService, AttributeDeleterService>();
            Services.AddScoped<IAttributeModifyService, AttributeModifyService>();
            Services.AddScoped<IAttributeSorterService, AttributeSorterService>();
            Services.AddScoped<IAttributeUpdaterService, AttributeUpdaterService>();
            #endregion

            #region DI Variant
            Services.AddScoped<IVariantRepository, VariantRepository>();
            Services.AddScoped<IVariantGetterService, VariantGetterService>();
            Services.AddScoped<IVariantAdderService, VariantAdderService>();
            Services.AddScoped<IVariantUpdaterService, VariantUpdaterService>();
            Services.AddScoped<IVariantDeleterService, VariantDeleterService>();
            Services.AddScoped<IVariantModifierService, VariantModifierService>();

            #endregion

            #region DI Cloudinary
            Services.AddScoped<ICloudinaryContract, CloudinaryService>();
            #endregion

            #region DI Discount
            Services.AddScoped<IDiscountRepository, DiscountRepository>();
            Services.AddScoped<IDiscountAdderService, DiscountAdderServices>();
            Services.AddScoped<IDiscountGetterService, DiscountGetterServices>();
            Services.AddScoped<IDiscountUpdaterService, DiscountUpdaterServices>();
            Services.AddScoped<IDiscountSorterService, DiscountSorterServices>();
            Services.AddScoped<IDiscountDeleterService, DiscountDeleterServices>();
            #endregion

            #region DI Order 
            Services.AddScoped<IOrderRepository, OrderRepository>();
            Services.AddScoped<IOrderGetterService, OrderGetterService>();
            Services.AddScoped<IOrderUpdaterService, OrderUpdaterService>();
            Services.AddScoped<IOrderDeleterService, OrderDeleterService>();
            Services.AddScoped<IOrderSorterService, OrderSorterService>();

            #endregion

            #region DI Rate
            Services.AddScoped<IRateRepository, RateRepository>();
            Services.AddScoped<IRateGetterService, RateGetterService>();
            Services.AddScoped<IRateAdderService, RateAdderService>();
            Services.AddScoped<IRateDeleterService, RateDeleterService>();
            Services.AddScoped<IRateSortService, RateSorterService>();
            #endregion

            #region DI Setting
            Services.AddScoped<ISettingRepository,SettingRepository>();
            Services.AddScoped<ISettingGetterService, SettingGetterService>();
            Services.AddScoped<ISettingUpdaterService,SettingUpdaterService >();

            #endregion

        }
    }
}
