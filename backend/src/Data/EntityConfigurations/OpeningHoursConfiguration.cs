using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityConfigurations
{
    internal class OpeningHoursConfiguration : IEntityTypeConfiguration<OpeningHours> 
    {
        public void Configure(EntityTypeBuilder<OpeningHours> builder)
        {
            builder.ToTable("OpeningHours");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Start)
                .IsRequired()
                .HasColumnType("decimal(20,0)");
            
            builder.Property(e => e.End)
                .IsRequired()
                .HasColumnType("decimal(20,0)");

            builder.Property(e => e.Break)
                .IsRequired()
                .HasColumnType("decimal(20,0)");
            
            builder.Property(e => e.DayOfWeek)
                .IsRequired()
                .HasConversion<int>();
            
            builder.HasOne(e => e.Business)
                .WithMany(x => x.OpeningHours)
                .HasForeignKey(e => e.BusinessId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}