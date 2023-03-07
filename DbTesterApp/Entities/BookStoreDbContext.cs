using DbTesterApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DbTesterApp.Entities;

public class BookStoreDbContext : DbContext
{
    private static string _connectionString = "";

    public DbSet<Book> Books { get; set; }
    public DbSet<Library> Libraries { get; set; }
    public DbSet<BaseOrganization> Organizations { get; set; }
    public DbSet<BaseWorker> Workers { get; set; }
    public DbSet<BaseVector> Vectors { get; set; }
    public DbSet<BasePoint> Points { get; set; }
    public DbSet<Number> Numbers { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
    }

    public static void ConfigureConnection(string connectionString)
    {
        _connectionString = connectionString;
    }
}
