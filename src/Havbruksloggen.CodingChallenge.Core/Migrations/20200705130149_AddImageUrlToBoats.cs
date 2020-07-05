using Microsoft.EntityFrameworkCore.Migrations;

namespace Havbruksloggen.CodingChallenge.Core.Migrations
{
    public partial class AddImageUrlToBoats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "boats",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "boats");
        }
    }
}
