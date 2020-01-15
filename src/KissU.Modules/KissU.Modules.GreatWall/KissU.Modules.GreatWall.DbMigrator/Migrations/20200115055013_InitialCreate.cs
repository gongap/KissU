using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KissU.Modules.GreatWall.DbMigrator.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "iam");

            migrationBuilder.CreateTable(
                name: "Applications",
                schema: "iam",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
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
                    table.PrimaryKey("PK_Applications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                schema: "iam",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
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
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "iam",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
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
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "iam",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "iam",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
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
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                schema: "iam",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
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
                    table.PrimaryKey("PK_Resources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resources_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "iam",
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Resources_Resources_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "iam",
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Resources_ApplicationId",
                schema: "iam",
                table: "Resources",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_ParentId",
                schema: "iam",
                table: "Resources",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permissions",
                schema: "iam");

            migrationBuilder.DropTable(
                name: "Resources",
                schema: "iam");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "iam");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "iam");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "iam");

            migrationBuilder.DropTable(
                name: "Applications",
                schema: "iam");
        }
    }
}
