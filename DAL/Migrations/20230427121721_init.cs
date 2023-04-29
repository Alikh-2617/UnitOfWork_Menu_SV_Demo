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
                name: "DaysMenu",
                columns: table => new
                {
                    Day = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaysMenu", x => x.Day);
                });

            migrationBuilder.CreateTable(
                name: "BreakFasts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Create = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Update = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Day1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreakFasts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BreakFasts_DaysMenu_Day1",
                        column: x => x.Day1,
                        principalTable: "DaysMenu",
                        principalColumn: "Day");
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
                    Day1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desserts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Desserts_DaysMenu_Day1",
                        column: x => x.Day1,
                        principalTable: "DaysMenu",
                        principalColumn: "Day");
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
                    Day1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dinner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dinner_DaysMenu_Day1",
                        column: x => x.Day1,
                        principalTable: "DaysMenu",
                        principalColumn: "Day");
                });

            migrationBuilder.CreateTable(
                name: "Drinks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DaysMenuDay = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drinks_DaysMenu_DaysMenuDay",
                        column: x => x.DaysMenuDay,
                        principalTable: "DaysMenu",
                        principalColumn: "Day");
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
                    Day1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lunch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lunch_DaysMenu_Day1",
                        column: x => x.Day1,
                        principalTable: "DaysMenu",
                        principalColumn: "Day");
                });

            migrationBuilder.CreateTable(
                name: "Sodas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DaysMenuDay = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sodas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sodas_DaysMenu_DaysMenuDay",
                        column: x => x.DaysMenuDay,
                        principalTable: "DaysMenu",
                        principalColumn: "Day");
                });

            migrationBuilder.InsertData(
                table: "Dinner",
                columns: new[] { "Id", "Created", "Day1", "Discription", "Name", "Update" },
                values: new object[] { new Guid("21671386-f42a-4642-9e48-add0ab44f363"), new DateTime(2023, 4, 27, 14, 17, 20, 935, DateTimeKind.Local).AddTicks(2206), null, " ssss", "dd", null });

            migrationBuilder.InsertData(
                table: "Lunch",
                columns: new[] { "Id", "Create", "Day1", "Discription", "Name", "Update" },
                values: new object[] { new Guid("c8c0ccbb-fc6f-4466-abaa-0a497b9c0e62"), new DateTime(2023, 4, 27, 14, 17, 20, 935, DateTimeKind.Local).AddTicks(2380), null, "ssss", "sssss", null });

            migrationBuilder.CreateIndex(
                name: "IX_BreakFasts_Day1",
                table: "BreakFasts",
                column: "Day1");

            migrationBuilder.CreateIndex(
                name: "IX_Desserts_Day1",
                table: "Desserts",
                column: "Day1");

            migrationBuilder.CreateIndex(
                name: "IX_Dinner_Day1",
                table: "Dinner",
                column: "Day1");

            migrationBuilder.CreateIndex(
                name: "IX_Drinks_DaysMenuDay",
                table: "Drinks",
                column: "DaysMenuDay");

            migrationBuilder.CreateIndex(
                name: "IX_Lunch_Day1",
                table: "Lunch",
                column: "Day1");

            migrationBuilder.CreateIndex(
                name: "IX_Sodas_DaysMenuDay",
                table: "Sodas",
                column: "DaysMenuDay");
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

            migrationBuilder.DropTable(
                name: "DaysMenu");
        }
    }
}
