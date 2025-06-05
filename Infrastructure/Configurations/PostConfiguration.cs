using Getting_Started.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Getting_Started.Infrastructure.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Title).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Content).IsRequired();
            builder.HasMany(p => p.Comments).WithOne(c => c.Post).HasForeignKey(c => c.PostId);
        }
    }

}
