using Microsoft.EntityFrameworkCore.Migrations;

namespace Book_My_Table.Migrations
{
    public partial class Migration4C : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerAddress",
                table: "Booking");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerAddress",
                table: "Booking",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
