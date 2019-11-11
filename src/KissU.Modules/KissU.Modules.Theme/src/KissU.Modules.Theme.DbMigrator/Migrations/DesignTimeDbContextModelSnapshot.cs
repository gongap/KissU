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
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KissU.Modules.Theme.Domain.Models.Language", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<string>("Abbr")
                        .HasMaxLength(128);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<DateTime?>("CreationTime");

                    b.Property<Guid?>("CreatorId");

                    b.Property<bool?>("IsEnabled");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<Guid?>("LastModifierId");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("Language","Systems");
                });

            modelBuilder.Entity("KissU.Modules.Theme.Domain.Models.LanguageDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<DateTime?>("CreationTime");

                    b.Property<Guid?>("CreatorId");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<Guid?>("LastModifierId");

                    b.Property<Guid>("MainId");

                    b.Property<string>("Value")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("MainId");

                    b.ToTable("LanguageDetail","Systems");
                });

            modelBuilder.Entity("KissU.Modules.Theme.Domain.Models.LanguageDetail", b =>
                {
                    b.HasOne("KissU.Modules.Theme.Domain.Models.Language")
                        .WithMany("Details")
                        .HasForeignKey("MainId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
