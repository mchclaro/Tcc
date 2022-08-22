using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityConfigurations
{
    internal class BusinessConfiguration : IEntityTypeConfiguration<Business>
    {
        public void Configure(EntityTypeBuilder<Business> builder)
        {
            builder.ToTable("Business");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.CNPJ)
                .IsRequired()
                .HasMaxLength(14);
            
            builder.Property(e => e.SocialReson)
                .IsRequired(false)
                .HasMaxLength(255);

            builder.Property(e => e.FantasyName)
                .IsRequired(false)
                .HasMaxLength(255);
            
            builder.Property(e => e.BusinessName)
                .IsRequired(false)
                .HasMaxLength(255);
            
            builder.Property(e => e.Priority)
                .IsRequired()
                .HasConversion<int>();
            
            builder.Property(e => e.Category)
                .IsRequired()
                .HasConversion<int>();

            builder.HasOne(e => e.Address)
                .WithMany(x => x.Business)
                .HasForeignKey(e => e.AddressId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}