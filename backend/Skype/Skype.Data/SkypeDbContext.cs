using Skype.Data.Tables;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Skype.Data
{
    public class SkypeDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Member> Members { get; set; }

        public SkypeDbContext() : base($"Server=14.225.27.59;Database=Skype;User Id=sa;Password=123#qwerty;") { }
        public SkypeDbContext(string connectionString) : base(connectionString) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        }
    }
}
