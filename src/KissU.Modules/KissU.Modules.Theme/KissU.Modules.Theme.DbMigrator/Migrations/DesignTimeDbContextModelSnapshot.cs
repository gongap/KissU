﻿// <auto-generated />
using System;
using KissU.Modules.Theme.DbMigrator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KissU.Modules.Theme.DbMigrator.Migrations
{
    [DbContext(typeof(DesignTimeDbContext))]
    partial class DesignTimeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KissU.Modules.Theme.Domain.Models.Language", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Abbr")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastModifierId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("Language","systems");
                });

            modelBuilder.Entity("KissU.Modules.Theme.Domain.Models.LanguageDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastModifierId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MainId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MainId");

                    b.ToTable("LanguageDetail","systems");
                });

            modelBuilder.Entity("KissU.Modules.Theme.Domain.Models.LanguageDetail", b =>
                {
                    b.HasOne("KissU.Modules.Theme.Domain.Models.Language", null)
                        .WithMany("Details")
                        .HasForeignKey("MainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
