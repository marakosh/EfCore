﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ForecastHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Temp = table.Column<float>(type: "real", nullable: false),
                    Humidity = table.Column<int>(type: "int", nullable: false),
                    FeelsLike = table.Column<float>(type: "real", nullable: false),
                    WindSpeed = table.Column<float>(type: "real", nullable: false),
                    Pressure = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForecastHistories", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ForecastHistories");
        }
    }
}
