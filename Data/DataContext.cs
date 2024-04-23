using CerealAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace CerealAPI.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Cereal> Cereals { get; init; }
    public DbSet<Image> Images { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Image>()
            .HasOne(i => i.Cereal)
            .WithOne(c => c.Image)
            .HasForeignKey<Image>(i => i.CerealId);
    }
}