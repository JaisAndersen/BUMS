using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BUMS{
    public class BUMSDbContext : IdentityDbContext<User>{
        public BUMSDbContext(DbContextOptions<BUMSDbContext> options) : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);
        }
        required public override DbSet<User> Users { get; set; }
        public DbSet<Group>? Groups { get; set; }
        public DbSet<Access>? Access { get; set; }
        public DbSet<UserGroup>? UserGroups { get; set; }
    }
}
