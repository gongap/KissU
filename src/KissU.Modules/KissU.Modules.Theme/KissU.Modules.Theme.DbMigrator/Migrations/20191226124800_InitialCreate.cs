using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KissU.Modules.Theme.DbMigrator.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "systems");

            migrationBuilder.CreateTable(
                name: "Language",
                schema: "systems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    CreatorId = table.Column<Guid>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(maxLength: 10, nullable: false),
                    Text = table.Column<string>(maxLength: 64, nullable: false),
                    Abbr = table.Column<string>(maxLength: 128, nullable: true),
                    IsEnabled = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LanguageDetail",
                schema: "systems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MainId = table.Column<Guid>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    Key = table.Column<string>(maxLength: 256, nullable: false),
                    Value = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LanguageDetail_Language_MainId",
                        column: x => x.MainId,
                        principalSchema: "systems",
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LanguageDetail_MainId",
                schema: "systems",
                table: "LanguageDetail",
                column: "MainId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LanguageDetail",
                schema: "systems");

            migrationBuilder.DropTable(
                name: "Language",
                schema: "systems");
        }
    }
}
