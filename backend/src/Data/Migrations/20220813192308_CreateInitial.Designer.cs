﻿// <auto-generated />
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220813192308_CreateInitial")]
    partial class CreateInitial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Domain.Entities.Business", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("BusinessName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CNPJ")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<string>("FantasyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<string>("SocialReson")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.ToTable("Business");
                });

            modelBuilder.Entity("Domain.Entities.BusinessPhotos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BusinessId")
                        .HasColumnType("int");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BusinessId");

                    b.ToTable("BusinessPhotos");
                });

            modelBuilder.Entity("Domain.Entities.OpeningHours", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Break")
                        .HasColumnType("decimal(20,0)");

                    b.Property<int>("BusinessId")
                        .HasColumnType("int");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("int");

                    b.Property<decimal>("End")
                        .HasColumnType("decimal(20,0)");

                    b.Property<decimal>("Start")
                        .HasColumnType("decimal(20,0)");

                    b.HasKey("Id");

                    b.HasIndex("BusinessId");

                    b.ToTable("OpeningHours");
                });

            modelBuilder.Entity("Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BusinessId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BusinessId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Domain.Entities.SocialMedia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BusinessId")
                        .HasColumnType("int");

                    b.Property<string>("Facebook")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instagram")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Whatsapp")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BusinessId");

                    b.ToTable("SocialMedia");
                });

            modelBuilder.Entity("Domain.Entities.Business", b =>
                {
                    b.HasOne("Domain.Entities.Address", "Address")
                        .WithMany("Business")
                        .HasForeignKey("Domain.Entities.Business", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Domain.Entities.BusinessPhotos", b =>
                {
                    b.HasOne("Domain.Entities.Business", "Business")
                        .WithMany("BusinessPhotos")
                        .HasForeignKey("BusinessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Business");
                });

            modelBuilder.Entity("Domain.Entities.OpeningHours", b =>
                {
                    b.HasOne("Domain.Entities.Business", "Business")
                        .WithMany("OpeningHours")
                        .HasForeignKey("BusinessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Business");
                });

            modelBuilder.Entity("Domain.Entities.Product", b =>
                {
                    b.HasOne("Domain.Entities.Business", "Business")
                        .WithMany("Products")
                        .HasForeignKey("BusinessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Business");
                });

            modelBuilder.Entity("Domain.Entities.SocialMedia", b =>
                {
                    b.HasOne("Domain.Entities.Business", "Business")
                        .WithMany("SocialMedias")
                        .HasForeignKey("BusinessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Business");
                });

            modelBuilder.Entity("Domain.Entities.Address", b =>
                {
                    b.Navigation("Business");
                });

            modelBuilder.Entity("Domain.Entities.Business", b =>
                {
                    b.Navigation("BusinessPhotos");

                    b.Navigation("OpeningHours");

                    b.Navigation("Products");

                    b.Navigation("SocialMedias");
                });
#pragma warning restore 612, 618
        }
    }
}
