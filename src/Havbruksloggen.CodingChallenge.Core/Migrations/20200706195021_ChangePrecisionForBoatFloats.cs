using Microsoft.EntityFrameworkCore.Migrations;

namespace Havbruksloggen.CodingChallenge.Core.Migrations
{
    public partial class ChangePrecisionForBoatFloats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "LoA",
                table: "boats",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "decimal(5, 2");

            migrationBuilder.AlterColumn<float>(
                name: "B",
                table: "boats",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5, 2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "LoA",
                table: "boats",
                type: "decimal(5, 2",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<decimal>(
                name: "B",
                table: "boats",
                type: "decimal(5, 2)",
                nullable: false,
                oldClrType: typeof(float));
        }
    }
}
