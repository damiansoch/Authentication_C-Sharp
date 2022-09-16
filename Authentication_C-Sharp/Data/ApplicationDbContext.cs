using Authentication_C_Sharp.Models;
using Microsoft.EntityFrameworkCore;

namespace Authentication_C_Sharp.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<User> Users { get; set; } = default!;

        //making email address unique but not primary key
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity => { entity.HasIndex(e=>e.Email).IsUnique(); });
        }
    }
}
