﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KissU.Modules.GreatWall.DbMigrator.Migrations
{
    [DbContext(typeof(DesignTimeDbContext))]
    internal class DesignTimeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KissU.Modules.GreatWall.Data.Pos.ApplicationPo", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ApplicationId")
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("Code")
                    .HasColumnType("nvarchar(max)");

                b.Property<DateTime?>("CreationTime")
                    .HasColumnType("datetime2");

                b.Property<Guid?>("CreatorId")
                    .HasColumnType("uniqueidentifier");

                b.Property<bool>("Enabled")
                    .HasColumnType("bit");

                b.Property<string>("Extend")
                    .HasColumnType("nvarchar(max)");

                b.Property<bool>("IsDeleted")
                    .HasColumnType("bit");

                b.Property<DateTime?>("LastModificationTime")
                    .HasColumnType("datetime2");

                b.Property<Guid?>("LastModifierId")
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("Name")
                    .HasColumnType("nvarchar(max)");

                b.Property<bool>("RegisterEnabled")
                    .HasColumnType("bit");

                b.Property<string>("Remark")
                    .HasColumnType("nvarchar(max)");

                b.Property<byte[]>("Version")
                    .IsConcurrencyToken()
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnType("rowversion");

                b.HasKey("Id");

                b.ToTable("Application", "Systems");
            });

            modelBuilder.Entity("KissU.Modules.GreatWall.Data.Pos.ResourcePo", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ResourceId")
                    .HasColumnType("uniqueidentifier");

                b.Property<Guid?>("ApplicationId")
                    .HasColumnType("uniqueidentifier");

                b.Property<DateTime?>("CreationTime")
                    .HasColumnType("datetime2");

                b.Property<Guid?>("CreatorId")
                    .HasColumnType("uniqueidentifier");

                b.Property<bool>("Enabled")
                    .HasColumnType("bit");

                b.Property<string>("Extend")
                    .HasColumnType("nvarchar(max)");

                b.Property<bool>("IsDeleted")
                    .HasColumnType("bit");

                b.Property<DateTime?>("LastModificationTime")
                    .HasColumnType("datetime2");

                b.Property<Guid?>("LastModifierId")
                    .HasColumnType("uniqueidentifier");

                b.Property<int>("Level")
                    .HasColumnName("Level")
                    .HasColumnType("int");

                b.Property<string>("Name")
                    .HasColumnType("nvarchar(max)");

                b.Property<Guid?>("ParentId")
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("Path")
                    .HasColumnName("Path")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("PinYin")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Remark")
                    .HasColumnType("nvarchar(max)");

                b.Property<int?>("SortId")
                    .HasColumnType("int");

                b.Property<int>("Type")
                    .HasColumnType("int");

                b.Property<string>("Uri")
                    .HasColumnType("nvarchar(max)");

                b.Property<byte[]>("Version")
                    .IsConcurrencyToken()
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnType("rowversion");

                b.HasKey("Id");

                b.HasIndex("ApplicationId");

                b.HasIndex("ParentId");

                b.ToTable("Resource", "Systems");
            });

            modelBuilder.Entity("KissU.Modules.GreatWall.Domain.Models.Claim", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ClaimId")
                    .HasColumnType("uniqueidentifier");

                b.Property<DateTime?>("CreationTime")
                    .HasColumnType("datetime2");

                b.Property<Guid?>("CreatorId")
                    .HasColumnType("uniqueidentifier");

                b.Property<bool>("Enabled")
                    .HasColumnType("bit");

                b.Property<bool>("IsDeleted")
                    .HasColumnType("bit");

                b.Property<DateTime?>("LastModificationTime")
                    .HasColumnType("datetime2");

                b.Property<Guid?>("LastModifierId")
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("nvarchar(200)")
                    .HasMaxLength(200);

                b.Property<string>("Remark")
                    .HasColumnType("nvarchar(500)")
                    .HasMaxLength(500);

                b.Property<int?>("SortId")
                    .HasColumnType("int");

                b.Property<byte[]>("Version")
                    .IsConcurrencyToken()
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnType("rowversion");

                b.HasKey("Id");

                b.ToTable("Claim", "Systems");
            });

            modelBuilder.Entity("KissU.Modules.GreatWall.Domain.Models.Permission", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PermissionId")
                    .HasColumnType("uniqueidentifier");

                b.Property<DateTime?>("CreationTime")
                    .HasColumnType("datetime2");

                b.Property<Guid?>("CreatorId")
                    .HasColumnType("uniqueidentifier");

                b.Property<bool>("IsDeleted")
                    .HasColumnType("bit");

                b.Property<bool>("IsDeny")
                    .HasColumnType("bit");

                b.Property<DateTime?>("LastModificationTime")
                    .HasColumnType("datetime2");

                b.Property<Guid?>("LastModifierId")
                    .HasColumnType("uniqueidentifier");

                b.Property<Guid>("ResourceId")
                    .HasColumnType("uniqueidentifier");

                b.Property<Guid>("RoleId")
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("Sign")
                    .HasColumnType("nvarchar(256)")
                    .HasMaxLength(256);

                b.Property<byte[]>("Version")
                    .IsConcurrencyToken()
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnType("rowversion");

                b.HasKey("Id");

                b.ToTable("Permission", "Systems");
            });

            modelBuilder.Entity("KissU.Modules.GreatWall.Domain.Models.Role", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("RoleId")
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("Code")
                    .IsRequired()
                    .HasColumnType("nvarchar(256)")
                    .HasMaxLength(256);

                b.Property<DateTime?>("CreationTime")
                    .HasColumnType("datetime2");

                b.Property<Guid?>("CreatorId")
                    .HasColumnType("uniqueidentifier");

                b.Property<bool>("Enabled")
                    .HasColumnType("bit");

                b.Property<bool>("IsAdmin")
                    .HasColumnType("bit");

                b.Property<bool>("IsDeleted")
                    .HasColumnType("bit");

                b.Property<DateTime?>("LastModificationTime")
                    .HasColumnType("datetime2");

                b.Property<Guid?>("LastModifierId")
                    .HasColumnType("uniqueidentifier");

                b.Property<int>("Level")
                    .HasColumnName("Level")
                    .HasColumnType("int");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("nvarchar(256)")
                    .HasMaxLength(256);

                b.Property<string>("NormalizedName")
                    .IsRequired()
                    .HasColumnType("nvarchar(256)")
                    .HasMaxLength(256);

                b.Property<Guid?>("ParentId")
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("Path")
                    .IsRequired()
                    .HasColumnName("Path")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("PinYin")
                    .HasColumnType("nvarchar(200)")
                    .HasMaxLength(200);

                b.Property<string>("Remark")
                    .HasColumnType("nvarchar(500)")
                    .HasMaxLength(500);

                b.Property<string>("Sign")
                    .HasColumnType("nvarchar(256)")
                    .HasMaxLength(256);

                b.Property<int?>("SortId")
                    .HasColumnType("int");

                b.Property<string>("Type")
                    .IsRequired()
                    .HasColumnType("nvarchar(80)")
                    .HasMaxLength(80);

                b.Property<byte[]>("Version")
                    .IsConcurrencyToken()
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnType("rowversion");

                b.HasKey("Id");

                b.ToTable("Role", "Systems");
            });

            modelBuilder.Entity("KissU.Modules.GreatWall.Domain.Models.User", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("UserId")
                    .HasColumnType("uniqueidentifier");

                b.Property<int?>("AccessFailedCount")
                    .HasColumnType("int");

                b.Property<DateTime?>("CreationTime")
                    .HasColumnType("datetime2");

                b.Property<Guid?>("CreatorId")
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("CurrentLoginIp")
                    .HasColumnType("nvarchar(30)")
                    .HasMaxLength(30);

                b.Property<DateTime?>("CurrentLoginTime")
                    .HasColumnType("datetime2");

                b.Property<DateTime?>("DisabledTime")
                    .HasColumnType("datetime2");

                b.Property<string>("Email")
                    .HasColumnType("nvarchar(256)")
                    .HasMaxLength(256);

                b.Property<bool>("EmailConfirmed")
                    .HasColumnType("bit");

                b.Property<bool>("Enabled")
                    .HasColumnType("bit");

                b.Property<bool>("IsDeleted")
                    .HasColumnType("bit");

                b.Property<string>("LastLoginIp")
                    .HasColumnType("nvarchar(30)")
                    .HasMaxLength(30);

                b.Property<DateTime?>("LastLoginTime")
                    .HasColumnType("datetime2");

                b.Property<DateTime?>("LastModificationTime")
                    .HasColumnType("datetime2");

                b.Property<Guid?>("LastModifierId")
                    .HasColumnType("uniqueidentifier");

                b.Property<bool>("LockoutEnabled")
                    .HasColumnType("bit");

                b.Property<DateTimeOffset?>("LockoutEnd")
                    .HasColumnType("datetimeoffset");

                b.Property<int?>("LoginCount")
                    .HasColumnType("int");

                b.Property<string>("NormalizedEmail")
                    .HasColumnType("nvarchar(256)")
                    .HasMaxLength(256);

                b.Property<string>("NormalizedUserName")
                    .HasColumnType("nvarchar(256)")
                    .HasMaxLength(256);

                b.Property<string>("Password")
                    .HasColumnType("nvarchar(256)")
                    .HasMaxLength(256);

                b.Property<string>("PasswordHash")
                    .HasColumnType("nvarchar(1024)")
                    .HasMaxLength(1024);

                b.Property<string>("PhoneNumber")
                    .HasColumnType("nvarchar(64)")
                    .HasMaxLength(64);

                b.Property<bool>("PhoneNumberConfirmed")
                    .HasColumnType("bit");

                b.Property<string>("RegisterIp")
                    .HasColumnType("nvarchar(30)")
                    .HasMaxLength(30);

                b.Property<string>("Remark")
                    .HasColumnType("nvarchar(500)")
                    .HasMaxLength(500);

                b.Property<string>("SafePassword")
                    .HasColumnType("nvarchar(256)")
                    .HasMaxLength(256);

                b.Property<string>("SafePasswordHash")
                    .HasColumnType("nvarchar(1024)")
                    .HasMaxLength(1024);

                b.Property<string>("SecurityStamp")
                    .HasColumnType("nvarchar(1024)")
                    .HasMaxLength(1024);

                b.Property<bool>("TwoFactorEnabled")
                    .HasColumnType("bit");

                b.Property<string>("UserName")
                    .HasColumnType("nvarchar(256)")
                    .HasMaxLength(256);

                b.Property<byte[]>("Version")
                    .IsConcurrencyToken()
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnType("rowversion");

                b.HasKey("Id");

                b.ToTable("User", "Systems");
            });

            modelBuilder.Entity("KissU.Modules.GreatWall.Domain.Models.UserRole", b =>
            {
                b.Property<Guid>("UserId")
                    .HasColumnType("uniqueidentifier");

                b.Property<Guid>("RoleId")
                    .HasColumnType("uniqueidentifier");

                b.HasKey("UserId", "RoleId");

                b.ToTable("UserRole", "Systems");
            });

            modelBuilder.Entity("KissU.Modules.GreatWall.Data.Pos.ResourcePo", b =>
            {
                b.HasOne("KissU.Modules.GreatWall.Data.Pos.ApplicationPo", "Application")
                    .WithMany()
                    .HasForeignKey("ApplicationId");

                b.HasOne("KissU.Modules.GreatWall.Data.Pos.ResourcePo", "Parent")
                    .WithMany()
                    .HasForeignKey("ParentId");
            });
#pragma warning restore 612, 618
        }
    }
}