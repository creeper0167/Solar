using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solar.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addRequestTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RequestDateTime",
                table: "EnergyFlowDatas",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequestDateTime",
                table: "EnergyFlowDatas");
        }
    }
}
