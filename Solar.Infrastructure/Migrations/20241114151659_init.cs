using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solar.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aggregates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PvSystemId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnergyOutput = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EnergyDirectConsumption = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EnergyProductionTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EnergySelfConsumptionTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EnergyConsumptionTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SavingsCO2 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SavingsTrees = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SavingsTravelCar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SavingsTravelPlane = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Profits = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Earnings = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Savings = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LogDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aggregates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PowerType = table.Column<int>(type: "int", nullable: false),
                    PictureAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aggregates");

            migrationBuilder.DropTable(
                name: "Equipments");
        }
    }
}
