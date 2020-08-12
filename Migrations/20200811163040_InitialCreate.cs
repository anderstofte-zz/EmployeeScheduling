using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeScheduling.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    ShiftId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(nullable: false),
                    ShiftStart = table.Column<DateTime>(nullable: false),
                    ShiftEnd = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.ShiftId);
                    table.ForeignKey(
                        name: "FK_Shifts_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Email", "FirstName", "LastName" },
                values: new object[] { 1, "kat.and@acme.com", "Katrine", "Anderson" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Email", "FirstName", "LastName" },
                values: new object[] { 2, "magnus_latif@acme.com", "Magnus", "Latif" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Email", "FirstName", "LastName" },
                values: new object[] { 3, "andy-s@acme.com", "Andy", "Smith" });

            migrationBuilder.InsertData(
                table: "Shifts",
                columns: new[] { "ShiftId", "EmployeeId", "ShiftEnd", "ShiftStart" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 8, 13, 22, 30, 39, 837, DateTimeKind.Local).AddTicks(393), new DateTime(2020, 8, 13, 18, 30, 39, 834, DateTimeKind.Local).AddTicks(5024) },
                    { 2, 1, new DateTime(2020, 8, 15, 0, 30, 39, 837, DateTimeKind.Local).AddTicks(1130), new DateTime(2020, 8, 14, 18, 30, 39, 837, DateTimeKind.Local).AddTicks(1103) },
                    { 3, 1, new DateTime(2020, 8, 12, 1, 30, 39, 837, DateTimeKind.Local).AddTicks(1146), new DateTime(2020, 8, 11, 18, 30, 39, 837, DateTimeKind.Local).AddTicks(1142) },
                    { 4, 2, new DateTime(2020, 8, 14, 0, 30, 39, 837, DateTimeKind.Local).AddTicks(1153), new DateTime(2020, 8, 13, 18, 30, 39, 837, DateTimeKind.Local).AddTicks(1150) },
                    { 5, 2, new DateTime(2020, 8, 15, 22, 30, 39, 837, DateTimeKind.Local).AddTicks(1161), new DateTime(2020, 8, 15, 18, 30, 39, 837, DateTimeKind.Local).AddTicks(1157) },
                    { 6, 2, new DateTime(2020, 8, 11, 23, 30, 39, 837, DateTimeKind.Local).AddTicks(1168), new DateTime(2020, 8, 11, 18, 30, 39, 837, DateTimeKind.Local).AddTicks(1165) },
                    { 7, 3, new DateTime(2020, 8, 13, 2, 30, 39, 837, DateTimeKind.Local).AddTicks(1175), new DateTime(2020, 8, 12, 18, 30, 39, 837, DateTimeKind.Local).AddTicks(1172) },
                    { 8, 3, new DateTime(2020, 8, 15, 0, 30, 39, 837, DateTimeKind.Local).AddTicks(1182), new DateTime(2020, 8, 14, 18, 30, 39, 837, DateTimeKind.Local).AddTicks(1179) },
                    { 9, 3, new DateTime(2020, 8, 11, 21, 30, 39, 837, DateTimeKind.Local).AddTicks(1190), new DateTime(2020, 8, 11, 18, 30, 39, 837, DateTimeKind.Local).AddTicks(1186) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Email",
                table: "Employees",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_EmployeeId",
                table: "Shifts",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shifts");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
