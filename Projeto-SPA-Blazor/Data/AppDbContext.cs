using Microsoft.EntityFrameworkCore;
using Projeto_SPA_Blazor.Models;

namespace Projeto_SPA_Blazor.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
