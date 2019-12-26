using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KissU.Modules.GreatWall.DbMigrator.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "systems");

            migrationBuilder.CreateTable(
                name: "Application",
                schema: "systems",
                columns: table => new
                {
                    ApplicationId = table.Column<Guid>(nullable: false),
                    Version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    RegisterEnabled = table.Column<bool>(nullable: false),
                    Remark = table.Column<string>(nullable: true),
                    Extend = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => x.ApplicationId);
                });

            migrationBuilder.CreateTable(
                name: "Claim",
                schema: "systems",
                columns: table => new
                {
                    ClaimId = table.Column<Guid>(nullable: false),
                    Version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    SortId = table.Column<int>(nullable: true),
                    Remark = table.Column<string>(maxLength: 500, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claim", x => x.ClaimId);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                schema: "systems",
                columns: table => new
                {
                    PermissionId = table.Column<Guid>(nullable: false),
                    Version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RoleId = table.Column<Guid>(nullable: false),
                    ResourceId = table.Column<Guid>(nullable: false),
                    IsDeny = table.Column<bool>(nullable: false),
                    Sign = table.Column<string>(maxLength: 256, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.PermissionId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "systems",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(nullable: false),
                    Version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    ParentId = table.Column<Guid>(nullable: true),
                    Path = table.Column<string>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    SortId = table.Column<int>(nullable: true),
                    Code = table.Column<string>(maxLength: 256, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: false),
                    Type = table.Column<string>(maxLength: 80, nullable: false),
                    IsAdmin = table.Column<bool>(nullable: false),
                    Remark = table.Column<string>(maxLength: 500, nullable: true),
                    PinYin = table.Column<string>(maxLength: 200, nullable: true),
                    Sign = table.Column<string>(maxLength: 256, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "systems",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    Version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 64, nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    Password = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(maxLength: 1024, nullable: true),
                    SafePassword = table.Column<string>(maxLength: 256, nullable: true),
                    SafePasswordHash = table.Column<string>(maxLength: 1024, nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LastLoginTime = table.Column<DateTime>(nullable: true),
                    LastLoginIp = table.Column<string>(maxLength: 30, nullable: true),
                    CurrentLoginTime = table.Column<DateTime>(nullable: true),
                    CurrentLoginIp = table.Column<string>(maxLength: 30, nullable: true),
                    LoginCount = table.Column<int>(nullable: true),
                    AccessFailedCount = table.Column<int>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    DisabledTime = table.Column<DateTime>(nullable: true),
                    RegisterIp = table.Column<string>(maxLength: 30, nullable: true),
                    SecurityStamp = table.Column<string>(maxLength: 1024, nullable: true),
                    Remark = table.Column<string>(maxLength: 500, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                schema: "systems",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "Resource",
                schema: "systems",
                columns: table => new
                {
                    ResourceId = table.Column<Guid>(nullable: false),
                    Version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    ParentId = table.Column<Guid>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    SortId = table.Column<int>(nullable: true),
                    ApplicationId = table.Column<Guid>(nullable: true),
                    Uri = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Remark = table.Column<string>(nullable: true),
                    PinYin = table.Column<string>(nullable: true),
                    Extend = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => x.ResourceId);
                    table.ForeignKey(
                        name: "FK_Resource_Application_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "systems",
                        principalTable: "Application",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Resource_Resource_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "systems",
                        principalTable: "Resource",
                        principalColumn: "ResourceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Resource_ApplicationId",
                schema: "systems",
                table: "Resource",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Resource_ParentId",
                schema: "systems",
                table: "Resource",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Claim",
                schema: "systems");

            migrationBuilder.DropTable(
                name: "Permission",
                schema: "systems");

            migrationBuilder.DropTable(
                name: "Resource",
                schema: "systems");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "systems");

            migrationBuilder.DropTable(
                name: "User",
                schema: "systems");

            migrationBuilder.DropTable(
                name: "UserRole",
                schema: "systems");

            migrationBuilder.DropTable(
                name: "Application",
                schema: "systems");
        }
    }
}
