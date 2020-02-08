using Microsoft.EntityFrameworkCore;
using src.Models;

namespace src
{
    public class AppDbContext : DbContext
    {

        public DbSet<Url> Urls { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Url>().ToTable("urls");
            builder.Entity<Url>().HasKey(p => p.ShortUrl);
            builder.Entity<Url>().Property(p => p.LongUrl);
        }
    }
}