using Microsoft.EntityFrameworkCore.Migrations;

namespace Book_My_Table.Migrations
{
    public partial class Migration8C : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NameOnCard",
                table: "SavedCard",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameOnCard",
                table: "SavedCard");
        }
    }
}
