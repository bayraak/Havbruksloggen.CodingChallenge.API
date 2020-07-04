using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Havbruksloggen.CodingChallenge.Core.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    EmpNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(unicode: false, maxLength: 14, nullable: false),
                    LastName = table.Column<string>(unicode: false, maxLength: 16, nullable: false),
                    DeptNo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.EmpNo);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 63, nullable: true),
                    Username = table.Column<string>(maxLength: 63, nullable: true),
                    LastName = table.Column<string>(maxLength: 63, nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "boats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Producer = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    BuildNumber = table.Column<int>(nullable: true),
                    LoA = table.Column<decimal>(type: "decimal(5, 2)", nullable: false),
                    B = table.Column<decimal>(type: "decimal(5, 2)", nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_boats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_boats_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "crew_members",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Email = table.Column<string>(unicode: false, nullable: true),
                    CrewRole = table.Column<int>(nullable: false),
                    CertifiedUntil = table.Column<DateTime>(nullable: false),
                    BoatId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_crew_members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Boats_CrewMemberId",
                        column: x => x.BoatId,
                        principalTable: "boats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_boats_UserId",
                table: "boats",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_crew_members_BoatId",
                table: "crew_members",
                column: "BoatId");

            migrationBuilder.CreateIndex(
                name: "dept_no",
                table: "employees",
                column: "DeptNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "crew_members");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "boats");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
