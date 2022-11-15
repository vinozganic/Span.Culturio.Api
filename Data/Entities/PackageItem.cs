using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Span.Culturio.Api.Data.Entities
{
    public class PackageItem
    {
        public int Id { get; set; }
        public int CultureObjectId { get; set; }
        public int PackageId { get; set; }
        public int AvailableVisitsCount { get; set; }

        public virtual CultureObject CultureObject { get; set; }
        public virtual Package Package { get; set; }
        public virtual IEnumerable<Visits> Visits { get; set; }
    }

    public class PackageItemConfiguration : IEntityTypeConfiguration<PackageItem>
    {
        public void Configure(EntityTypeBuilder<PackageItem> builder)
        {
            builder.ToTable("PackageItems");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.CultureObject).WithMany(x => x.PackageItems).HasForeignKey(x => x.CultureObjectId);
            builder.HasOne(x => x.Package).WithMany(x => x.PackageItems).HasForeignKey(x => x.PackageId);
            builder.Property(x => x.AvailableVisitsCount).IsRequired();
        }
    }
}
