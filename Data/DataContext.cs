using Microsoft.EntityFrameworkCore;
using Span.Culturio.Api.Data.Entities;

namespace Span.Culturio.Api.Data
{
    public class DataContext : DbContext
    {
        public DbSet<CultureObject> CultureObjects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<PackageItem> PackageItems { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Visits> Visits { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }
    }
}
