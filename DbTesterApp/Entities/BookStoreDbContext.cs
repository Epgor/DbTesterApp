using DbTesterApp.Models.Sql;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver.Core.Configuration;
using StackExchange.Redis;

namespace DbTesterApp.Entities;

public class BookStoreDbContext : DbContext
{
    private static string _connectionString = "";

    public DbSet<BookSql> Books { get; set; }
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
