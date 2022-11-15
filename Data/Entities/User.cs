using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Span.Culturio.Api.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public virtual ICollection<Subscription> Subscriptions { get; set; }

        public class UserConfigurationBuilder : IEntityTypeConfiguration<User>
        {
            public void Configure(EntityTypeBuilder<User> builder)
            {
                builder.ToTable("Users");
                builder.HasKey(x => x.Id);
                builder.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
                builder.Property(x => x.LastName).IsRequired().HasMaxLength(100);
                builder.Property(x => x.Email).IsRequired().HasMaxLength(255);
                builder.Property(x => x.Username).IsRequired().HasMaxLength(100);
                builder.Property(x => x.PasswordHash).IsRequired().HasMaxLength(255);
                builder.Property(x => x.PasswordSalt).IsRequired().HasMaxLength(255);
            }
        }
    }
}
