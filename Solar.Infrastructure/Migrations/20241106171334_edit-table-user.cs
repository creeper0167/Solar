using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solar.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class edittableuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleTypeId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RoleType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleTypeId",
                table: "Users",
                column: "RoleTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_RoleType_RoleTypeId",
                table: "Users",
                column: "RoleTypeId",
                principalTable: "RoleType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_RoleType_RoleTypeId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "RoleType");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleTypeId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RoleTypeId",
                table: "Users");
        }
    }
}
