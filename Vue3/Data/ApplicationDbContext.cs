using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

namespace WebApplication1.Data;

public class ApplicationDbContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public ApplicationDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to sql server database
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
    }

    public DbSet<User> Users { get; set; }
}
