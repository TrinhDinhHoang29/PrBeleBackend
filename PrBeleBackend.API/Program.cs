using PrBeleBackend.API.StartupExtensions;
using PrBeleBackend.Infrastructure.Seeder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ServiceConfigure(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin() // Cho phép từ cổng 3000
              .AllowAnyHeader() // Cho phép mọi Header
              .AllowAnyMethod(); // Cho phép mọi phương thức (GET, POST, PUT, DELETE, ...)
    });
});

var app = builder.Build();

app.UseCors("AllowAllOrigins");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

//SeedData.EnsurePopulated(app);
app.Run();
