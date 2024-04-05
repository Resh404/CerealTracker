using CerealAPI;
using CerealAPI.Data;
using CerealAPI.Interfaces;
using CerealAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;


// Establish database connection
await EstablishDatabaseConnection();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// Add other services
builder.Services.AddControllers();
builder.Services.AddTransient<Seed>();
builder.Services.AddScoped<ICerealRepository, CerealRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Seed data if requested
if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();

// Seed data function
void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<Seed>();
        service.SeedDataContext();
    }
}

// Method to establish database connection
async Task EstablishDatabaseConnection()
{
    try
    {
        await AdoDatabaseConnector.ConnectToDatabaseAsync();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error establishing database connection: {ex}");
        throw;
    }
}