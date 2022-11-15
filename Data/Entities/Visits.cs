using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Span.Culturio.Api.Data.Entities {
    public class Visits {
        public int Id { get; set; }
        public int? SubscriptionId { get; set; }
        public int PackageItemId { get; set; }
        public int VisitsLeft { get; set; }

        public virtual Subscription Subscription { get; set; }
        public virtual PackageItem PackageItem { get; set; }
    }

    public class VisitsConfiguration : IEntityTypeConfiguration<Visits> {
        public void Configure(EntityTypeBuilder<Visits> builder) {
            builder.ToTable("Visits");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Subscription).WithMany(x => x.Visits).HasForeignKey(x => x.SubscriptionId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.PackageItem).WithMany(x => x.Visits).HasForeignKey(x => x.PackageItemId);
            builder.Property(x => x.VisitsLeft).IsRequired();
        }
    }
}