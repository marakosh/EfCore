using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "ForecastHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ForecastHistories_CityId",
                table: "ForecastHistories",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ForecastHistories_City_CityId",
                table: "ForecastHistories",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForecastHistories_City_CityId",
                table: "ForecastHistories");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropIndex(
                name: "IX_ForecastHistories_CityId",
                table: "ForecastHistories");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "ForecastHistories");
        }
    }
}
