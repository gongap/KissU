﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KissU.Modules.GreatWall.DbMigrator.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                "Systems");

            migrationBuilder.CreateTable(
                "Application",
                schema: "Systems",
                columns: table => new
                {
                    ApplicationId = table.Column<Guid>(),
                    Version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Enabled = table.Column<bool>(),
                    RegisterEnabled = table.Column<bool>(),
                    Remark = table.Column<string>(nullable: true),
                    Extend = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>()
                },
                constraints: table => { table.PrimaryKey("PK_Application", x => x.ApplicationId); });

            migrationBuilder.CreateTable(
                "Claim",
                schema: "Systems",
                columns: table => new
                {
                    ClaimId = table.Column<Guid>(),
                    Version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Name = table.Column<string>(maxLength: 200),
                    Enabled = table.Column<bool>(),
                    SortId = table.Column<int>(nullable: true),
                    Remark = table.Column<string>(maxLength: 500, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>()
                },
                constraints: table => { table.PrimaryKey("PK_Claim", x => x.ClaimId); });

            migrationBuilder.CreateTable(
                "Permission",
                schema: "Systems",
                columns: table => new
                {
                    PermissionId = table.Column<Guid>(),
                    Version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RoleId = table.Column<Guid>(),
                    ResourceId = table.Column<Guid>(),
                    IsDeny = table.Column<bool>(),
                    Sign = table.Column<string>(maxLength: 256, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>()
                },
                constraints: table => { table.PrimaryKey("PK_Permission", x => x.PermissionId); });

            migrationBuilder.CreateTable(
                "Role",
                schema: "Systems",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(),
                    Version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    ParentId = table.Column<Guid>(nullable: true),
                    Path = table.Column<string>(),
                    Level = table.Column<int>(),
                    Enabled = table.Column<bool>(),
                    SortId = table.Column<int>(nullable: true),
                    Code = table.Column<string>(maxLength: 256),
                    Name = table.Column<string>(maxLength: 256),
                    NormalizedName = table.Column<string>(maxLength: 256),
                    Type = table.Column<string>(maxLength: 80),
                    IsAdmin = table.Column<bool>(),
                    Remark = table.Column<string>(maxLength: 500, nullable: true),
                    PinYin = table.Column<string>(maxLength: 200, nullable: true),
                    Sign = table.Column<string>(maxLength: 256, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>()
                },
                constraints: table => { table.PrimaryKey("PK_Role", x => x.RoleId); });

            migrationBuilder.CreateTable(
                "User",
                schema: "Systems",
                columns: table => new
                {
                    UserId = table.Column<Guid>(),
                    Version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(),
                    PhoneNumber = table.Column<string>(maxLength: 64, nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(),
                    Password = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(maxLength: 1024, nullable: true),
                    SafePassword = table.Column<string>(maxLength: 256, nullable: true),
                    SafePasswordHash = table.Column<string>(maxLength: 1024, nullable: true),
                    LockoutEnabled = table.Column<bool>(),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LastLoginTime = table.Column<DateTime>(nullable: true),
                    LastLoginIp = table.Column<string>(maxLength: 30, nullable: true),
                    CurrentLoginTime = table.Column<DateTime>(nullable: true),
                    CurrentLoginIp = table.Column<string>(maxLength: 30, nullable: true),
                    LoginCount = table.Column<int>(nullable: true),
                    AccessFailedCount = table.Column<int>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(),
                    Enabled = table.Column<bool>(),
                    DisabledTime = table.Column<DateTime>(nullable: true),
                    RegisterIp = table.Column<string>(maxLength: 30, nullable: true),
                    SecurityStamp = table.Column<string>(maxLength: 1024, nullable: true),
                    Remark = table.Column<string>(maxLength: 500, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>()
                },
                constraints: table => { table.PrimaryKey("PK_User", x => x.UserId); });

            migrationBuilder.CreateTable(
                "UserRole",
                schema: "Systems",
                columns: table => new
                {
                    UserId = table.Column<Guid>(),
                    RoleId = table.Column<Guid>()
                },
                constraints: table => { table.PrimaryKey("PK_UserRole", x => new {x.UserId, x.RoleId}); });

            migrationBuilder.CreateTable(
                "Resource",
                schema: "Systems",
                columns: table => new
                {
                    ResourceId = table.Column<Guid>(),
                    Version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    ParentId = table.Column<Guid>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    Level = table.Column<int>(),
                    Enabled = table.Column<bool>(),
                    SortId = table.Column<int>(nullable: true),
                    ApplicationId = table.Column<Guid>(nullable: true),
                    Uri = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<int>(),
                    Remark = table.Column<string>(nullable: true),
                    PinYin = table.Column<string>(nullable: true),
                    Extend = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => x.ResourceId);
                    table.ForeignKey(
                        "FK_Resource_Application_ApplicationId",
                        x => x.ApplicationId,
                        principalSchema: "Systems",
                        principalTable: "Application",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Resource_Resource_ParentId",
                        x => x.ParentId,
                        principalSchema: "Systems",
                        principalTable: "Resource",
                        principalColumn: "ResourceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                "IX_Resource_ApplicationId",
                schema: "Systems",
                table: "Resource",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                "IX_Resource_ParentId",
                schema: "Systems",
                table: "Resource",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Claim",
                "Systems");

            migrationBuilder.DropTable(
                "Permission",
                "Systems");

            migrationBuilder.DropTable(
                "Resource",
                "Systems");

            migrationBuilder.DropTable(
                "Role",
                "Systems");

            migrationBuilder.DropTable(
                "User",
                "Systems");

            migrationBuilder.DropTable(
                "UserRole",
                "Systems");

            migrationBuilder.DropTable(
                "Application",
                "Systems");
        }
    }
}