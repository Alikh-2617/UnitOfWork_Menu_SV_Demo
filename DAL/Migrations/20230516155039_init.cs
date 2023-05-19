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
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                values: new object[] { new Guid("7af782a6-6438-4ff7-a937-100284e85dbc"), new DateTime(2023, 5, 16, 17, 50, 39, 275, DateTimeKind.Local).AddTicks(3218), null, "ssss", "sssss", null });

            migrationBuilder.InsertData(
                table: "Desserts",
                columns: new[] { "Id", "Create", "Day", "Description", "Name", "Update" },
                values: new object[] { new Guid("85f05a5c-7806-4e22-a148-5392e3db8e1f"), new DateTime(2023, 5, 16, 17, 50, 39, 275, DateTimeKind.Local).AddTicks(3233), null, "ssss", "sssss", null });

            migrationBuilder.InsertData(
                table: "Dinner",
                columns: new[] { "Id", "Created", "Day", "Discription", "Name", "Update" },
                values: new object[] { new Guid("87f9365e-06d4-47d5-88e1-e3c40050e1ec"), new DateTime(2023, 5, 16, 17, 50, 39, 275, DateTimeKind.Local).AddTicks(3044), null, " ssss", "dd", null });

            migrationBuilder.InsertData(
                table: "Drinks",
                columns: new[] { "Id", "Name", "Size" },
                values: new object[] { new Guid("413dd321-f897-4d31-aa28-4bf8137e8291"), "sssss", "10" });

            migrationBuilder.InsertData(
                table: "Lunch",
                columns: new[] { "Id", "Create", "Day", "Description", "Name", "Update" },
                values: new object[] { new Guid("d4278dd2-b675-4dde-bd07-a6b10ca6eed2"), new DateTime(2023, 5, 16, 17, 50, 39, 275, DateTimeKind.Local).AddTicks(3198), null, "ssss", "sssss", null });

            migrationBuilder.InsertData(
                table: "Sodas",
                columns: new[] { "Id", "Name", "Size" },
                values: new object[] { new Guid("85155d52-e441-4123-8083-6bb86f2e8610"), "sssss", "10" });
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
