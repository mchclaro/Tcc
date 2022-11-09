using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AddLatLongToAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true);
            
            migrationBuilder.AddColumn<string>(
                name: "Longitude",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Address");

        }
    }
}
