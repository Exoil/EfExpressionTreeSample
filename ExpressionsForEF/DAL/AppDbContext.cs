using ExpressionsForEF.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpressionsForEF.DAL;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = default!;

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
        
    }
}