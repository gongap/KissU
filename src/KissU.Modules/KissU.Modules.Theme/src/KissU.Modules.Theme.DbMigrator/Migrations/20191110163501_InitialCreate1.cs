using Microsoft.EntityFrameworkCore.Migrations;

namespace KissU.Modules.Theme.DbMigrator.Migrations
{
    public partial class InitialCreate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Abbr",
                schema: "Systems",
                table: "Language");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Abbr",
                schema: "Systems",
                table: "Language",
                maxLength: 128,
                nullable: true);
        }
    }
}
