using EShop.Entities.Domain;
using Microsoft.EntityFrameworkCore;

namespace EShop.Data
{
    public class LocaleDBContext : ApplicationDbContext
    {
        public LocaleDBContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<LocalizedContent> LocalizedContent { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
