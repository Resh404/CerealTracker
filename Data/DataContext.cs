using CerealAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace CerealAPI.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Cereal> Cereals { get; init; }
}