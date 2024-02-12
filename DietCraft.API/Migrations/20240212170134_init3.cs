using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DietCraft.API.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "IngredientsForMeals",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsOptional",
                value: true);

            migrationBuilder.UpdateData(
                table: "IngredientsForMeals",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsOptional",
                value: true);

            migrationBuilder.UpdateData(
                table: "IngredientsForMeals",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsOptional",
                value: true);

            migrationBuilder.UpdateData(
                table: "IngredientsForMeals",
                keyColumn: "Id",
                keyValue: 10,
                column: "IsOptional",
                value: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "IngredientsForMeals",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsOptional",
                value: false);

            migrationBuilder.UpdateData(
                table: "IngredientsForMeals",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsOptional",
                value: false);

            migrationBuilder.UpdateData(
                table: "IngredientsForMeals",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsOptional",
                value: false);

            migrationBuilder.UpdateData(
                table: "IngredientsForMeals",
                keyColumn: "Id",
                keyValue: 10,
                column: "IsOptional",
                value: false);
        }
    }
}
