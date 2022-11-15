using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Span.Culturio.Api.Data.Entities
{
    public class CultureObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactEmail { get; set; }
        public string Address { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public int AdminUserId
        {
            get; set;
        }

        public virtual ICollection<PackageItem> PackageItems { get; set; }

        public class CultureObjectConfigurationBuilder : IEntityTypeConfiguration<CultureObject>
        {
            public void Configure(EntityTypeBuilder<CultureObject> builder)
            {
                builder.ToTable("CultureObjects");
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
                builder.Property(x => x.ContactEmail).IsRequired().HasMaxLength(255);
                builder.Property(x => x.Address).IsRequired().HasMaxLength(250);
                builder.Property(x => x.ZipCode).IsRequired();
                builder.Property(x => x.City).IsRequired().HasMaxLength(250);
                builder.Property(x => x.AdminUserId).IsRequired();
            }
        }
    }
}