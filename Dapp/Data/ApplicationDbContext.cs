using DappWeb.Model;
using Microsoft.EntityFrameworkCore;

namespace DappWeb.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
    }
}
