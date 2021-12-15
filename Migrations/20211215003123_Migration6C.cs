using Microsoft.EntityFrameworkCore.Migrations;

namespace Book_My_Table.Migrations
{
    public partial class Migration6C : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CardType",
                table: "SavedCard",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardType",
                table: "SavedCard");
        }
    }
}
