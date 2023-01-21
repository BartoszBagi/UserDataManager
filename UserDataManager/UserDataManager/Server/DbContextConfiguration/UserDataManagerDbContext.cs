using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UserDataManager.Server.Models;

namespace UserDataManager.Server.DbContextConfiguration
{
    public class UserDataManagerDbContext : DbContext
    {
        public string Schema { get; } = "UserDataManager";
        internal DbSet<User> Users { get; set; }
        internal DbSet<UserAttribute> Attributes { get; set; }
        public UserDataManagerDbContext()
        {

        }

        public UserDataManagerDbContext(DbContextOptions<UserDataManagerDbContext> options)
        : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("UserDataManager");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema(Schema);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
