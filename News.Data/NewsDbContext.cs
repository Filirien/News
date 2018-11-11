using Microsoft.EntityFrameworkCore;

namespace News.Data
{
    public class NewsDbContext : DbContext
    {
        public NewsDbContext(DbContextOptions<NewsDbContext> options)
           : base(options)
        {
        }

        public DbSet<Models.News> News { get; set; }        
    }
}
