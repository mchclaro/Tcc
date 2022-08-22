using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityConfigurations
{
    internal class BusinessPhotosConfiguration : IEntityTypeConfiguration<BusinessPhotos>
    {
        public void Configure(EntityTypeBuilder<BusinessPhotos> builder)
        {
            builder.ToTable("BusinessPhotos");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.PhotoUrl)
                .IsRequired(false)
                .HasColumnType("nvarchar(max)");
            
            builder.HasOne(e => e.Business)
                .WithMany(x => x.BusinessPhotos)
                .HasForeignKey(e => e.BusinessId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}