using Microsoft.EntityFrameworkCore;
using PrBeleBackend.Infrastructure.DbContexts;

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
            
        }
    }
}
