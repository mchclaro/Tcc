using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityConfigurations
{
    internal class SocialMediaConfiguration : IEntityTypeConfiguration<SocialMedia>
    {
        public void Configure(EntityTypeBuilder<SocialMedia> builder)
        {
            builder.ToTable("SocialMedia");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Phone)
                .IsRequired(false)
                .HasMaxLength(255);
            
            builder.Property(e => e.Whatsapp)
                .IsRequired(false)
                .HasMaxLength(255);

            builder.Property(e => e.Instagram)
                .IsRequired(false)
                .HasMaxLength(255);

            builder.Property(e => e.Facebook)
                .IsRequired(false)
                .HasMaxLength(255);
        }
    }
}