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
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Create = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Update = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sodas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BreakFasts",
                columns: new[] { "Id", "Create", "Day", "Description", "ImageName", "Name", "Update" },
                values: new object[] { new Guid("e187f2c3-c6d9-4c93-afe2-f1039f625b3d"), new DateTime(2023, 5, 29, 13, 44, 53, 717, DateTimeKind.Local).AddTicks(1527), null, "ssss", null, "sssss", null });

            migrationBuilder.InsertData(
                table: "Desserts",
                columns: new[] { "Id", "Create", "Day", "Description", "ImageName", "Name", "Update" },
                values: new object[] { new Guid("63c8f89f-01c5-4c72-8467-7f62cb1b3441"), new DateTime(2023, 5, 29, 13, 44, 53, 717, DateTimeKind.Local).AddTicks(1544), null, "ssss", null, "sssss", null });

            migrationBuilder.InsertData(
                table: "Dinner",
                columns: new[] { "Id", "Created", "Day", "Discription", "ImageName", "Name", "Update" },
                values: new object[] { new Guid("91d9f395-8338-4070-8671-548f8da6456b"), new DateTime(2023, 5, 29, 13, 44, 53, 717, DateTimeKind.Local).AddTicks(1346), null, " ssss", null, "dd", null });

            migrationBuilder.InsertData(
                table: "Drinks",
                columns: new[] { "Id", "ImageName", "Name", "Size" },
                values: new object[] { new Guid("e1cb238d-0fa2-4f9c-b736-3124bdf12b99"), null, "sssss", "10" });

            migrationBuilder.InsertData(
                table: "Lunch",
                columns: new[] { "Id", "Create", "Day", "Description", "ImageName", "Name", "Update" },
                values: new object[] { new Guid("e9a70caf-7f30-4f5c-ab06-1f8972ad3b89"), new DateTime(2023, 5, 29, 13, 44, 53, 717, DateTimeKind.Local).AddTicks(1508), null, "ssss", null, "sssss", null });

            migrationBuilder.InsertData(
                table: "Sodas",
                columns: new[] { "Id", "ImageName", "Name", "Size" },
                values: new object[] { new Guid("3b6539af-a259-496f-b0f0-8326a42bbab1"), null, "sssss", "10" });
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
