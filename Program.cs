using CerealAPI;
using CerealAPI.Data;
using CerealAPI.Interfaces;
using CerealAPI.Repositories;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddTransient<Seed>();
builder.Services.AddScoped<ICerealRepository, CerealRepository>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddDbContext<DataContext>((serviceProvider, options) =>
{
    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 36)));
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DataContext>();
    db.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    // Add production-specific error handling middleware
    // For example: app.UseExceptionHandler("/Error");
}

app.UseCors(x => x.WithOrigins("http://localhost:3000")
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

// Seed data if requested
// if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(app);

await app.RunAsync();

// Seed data function
void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetRequiredService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetRequiredService<Seed>();
        service.SeedDataContext();
        service.SeedImages();
    }
}