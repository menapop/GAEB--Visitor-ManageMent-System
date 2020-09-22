using Microsoft.EntityFrameworkCore.Migrations;

namespace VisitorServices.Migrations
{
    public partial class AddImageToVisitorInformation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "VisitorInformations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "VisitorInformations");
        }
    }
}
