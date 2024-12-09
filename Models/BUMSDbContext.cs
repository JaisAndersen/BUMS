using Microsoft.EntityFrameworkCore;

namespace BUMS
{
    public class BUMSDbContext : DbContext
    {
        public BUMSDbContext(DbContextOptions<BUMSDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Access> Accesss { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
    }
}
