﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using test_seguros_continental.Infraestructure.Data;

#nullable disable

namespace test_seguros_continental.Migrations
{
    [DbContext(typeof(ContinentalContext))]
    [Migration("20250308083240_initialDb")]
    partial class initialDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("test_seguros_continental.Domain.Entities.Client.ClientEntity", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientId"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("TypeClientId")
                        .HasColumnType("int");

                    b.HasKey("ClientId");

                    b.HasIndex("TypeClientId");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("test_seguros_continental.Domain.Entities.Currency.CurrencyEntity", b =>
                {
                    b.Property<int>("CurrencyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CurrencyId"));

                    b.Property<string>("CurrencyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("CurrencyId");

                    b.ToTable("Currency");
                });

            modelBuilder.Entity("test_seguros_continental.Domain.Entities.Quote.QuoteEntity", b =>
                {
                    b.Property<int>("QuoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuoteId"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<string>("DescriptionAsset")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<double>("DownPayment")
                        .HasColumnType("float");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<double>("TotalInsurance")
                        .HasColumnType("float");

                    b.HasKey("QuoteId");

                    b.HasIndex("ClientId");

                    b.HasIndex("CurrencyId");

                    b.ToTable("Quote");
                });

            modelBuilder.Entity("test_seguros_continental.Domain.Entities.RateRange.RateRangeEntity", b =>
                {
                    b.Property<int>("RateRangeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RateRangeId"));

                    b.Property<int>("MountMax")
                        .HasColumnType("int");

                    b.Property<double>("MountMin")
                        .HasColumnType("float");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("RateRangeId");

                    b.ToTable("RateRange");
                });

            modelBuilder.Entity("test_seguros_continental.Domain.Entities.TypeClient.TypeClientEntity", b =>
                {
                    b.Property<int>("TypeClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TypeClientId"));

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TypeClientId");

                    b.ToTable("TypeClient");
                });

            modelBuilder.Entity("test_seguros_continental.Domain.Entities.TypeInsurance.TypeInsuranceEntity", b =>
                {
                    b.Property<int>("TypeInsuranceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TypeInsuranceId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("TypeInsuranceId");

                    b.ToTable("TypeEnsurance");
                });

            modelBuilder.Entity("test_seguros_continental.Domain.Entities.Client.ClientEntity", b =>
                {
                    b.HasOne("test_seguros_continental.Domain.Entities.TypeClient.TypeClientEntity", "TypeClientEntity")
                        .WithMany()
                        .HasForeignKey("TypeClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TypeClientEntity");
                });

            modelBuilder.Entity("test_seguros_continental.Domain.Entities.Quote.QuoteEntity", b =>
                {
                    b.HasOne("test_seguros_continental.Domain.Entities.Client.ClientEntity", "ClientEntity")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("test_seguros_continental.Domain.Entities.Currency.CurrencyEntity", "CurrencyEntity")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClientEntity");

                    b.Navigation("CurrencyEntity");
                });
#pragma warning restore 612, 618
        }
    }
}
