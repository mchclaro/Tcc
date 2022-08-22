using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityConfigurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product> 
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired(false)
                .HasMaxLength(255);

            builder.Property(e => e.Description)
                .IsRequired(false)
                .HasColumnType("nvarchar(max)");

            builder.HasOne(e => e.Business)
                .WithMany(x => x.Products)
                .HasForeignKey(e => e.BusinessId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}