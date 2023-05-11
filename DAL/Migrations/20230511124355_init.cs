using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BreakFasts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Create = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Update = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreakFasts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Desserts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Create = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Update = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desserts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dinner",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Update = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dinner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drinks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drinks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lunch",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Create = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Update = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lunch", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sodas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sodas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BreakFasts",
                columns: new[] { "Id", "Create", "Day", "Description", "Name", "Update" },
                values: new object[] { new Guid("7dd9f4ab-7200-45fb-8c2d-aa6b48bb2932"), new DateTime(2023, 5, 11, 14, 43, 54, 996, DateTimeKind.Local).AddTicks(3942), null, "ssss", "sssss", null });

            migrationBuilder.InsertData(
                table: "Desserts",
                columns: new[] { "Id", "Create", "Day", "Description", "Name", "Update" },
                values: new object[] { new Guid("584bc7ec-551a-432c-9903-0ea7607dabc2"), new DateTime(2023, 5, 11, 14, 43, 54, 996, DateTimeKind.Local).AddTicks(3958), null, "ssss", "sssss", null });

            migrationBuilder.InsertData(
                table: "Dinner",
                columns: new[] { "Id", "Created", "Day", "Discription", "Name", "Update" },
                values: new object[] { new Guid("8440829d-ab09-4746-9e41-a44bf90d39ab"), new DateTime(2023, 5, 11, 14, 43, 54, 996, DateTimeKind.Local).AddTicks(3768), null, " ssss", "dd", null });

            migrationBuilder.InsertData(
                table: "Drinks",
                columns: new[] { "Id", "Name", "Size" },
                values: new object[] { new Guid("451cb4b3-4a25-4902-a5ad-2622afb1d09d"), "sssss", "10" });

            migrationBuilder.InsertData(
                table: "Lunch",
                columns: new[] { "Id", "Create", "Day", "Discription", "Name", "Update" },
                values: new object[] { new Guid("d8d698e1-a0c0-4966-8d32-0d583caa2c0b"), new DateTime(2023, 5, 11, 14, 43, 54, 996, DateTimeKind.Local).AddTicks(3913), null, "ssss", "sssss", null });

            migrationBuilder.InsertData(
                table: "Sodas",
                columns: new[] { "Id", "Name", "Size" },
                values: new object[] { new Guid("6e1ac0d7-32d0-45a9-b039-7f92c358800e"), "sssss", "10" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BreakFasts");

            migrationBuilder.DropTable(
                name: "Desserts");

            migrationBuilder.DropTable(
                name: "Dinner");

            migrationBuilder.DropTable(
                name: "Drinks");

            migrationBuilder.DropTable(
                name: "Lunch");

            migrationBuilder.DropTable(
                name: "Sodas");
        }
    }
}
