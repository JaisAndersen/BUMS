using Microsoft.EntityFrameworkCore;

namespace BUMS
{
    public class BUMSDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=mssql5.unoeuro.com;Initial Catalog=jaand_dk_db_bums;User ID=jaand_dk;Password=kbm3ydDrAF9cap4n2E6H;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Access> Access { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
    }
}
