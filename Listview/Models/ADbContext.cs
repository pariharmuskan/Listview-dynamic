using Microsoft.EntityFrameworkCore;

namespace Listview.Models
{
  
        public class ADbContext : DbContext
        {
            public ADbContext(DbContextOptions<ADbContext> options)
                : base(options)
            {
            }

            public DbSet<Animal> Animals { get; set; }
        
    }
}
