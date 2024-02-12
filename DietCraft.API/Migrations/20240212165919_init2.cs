using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DietCraft.API.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CarbGram", "Kcal", "Name", "Price", "ProteinGram" },
                values: new object[] { 0, 0, "Jajka", 1.0m, 0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FatGram", "Kcal", "Name", "Price", "ProteinGram" },
                values: new object[] { 0, 0, "Szpinak", 2.0m, 0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FatGram", "IsVegan", "Kcal", "Name", "Price", "ProteinGram" },
                values: new object[] { 0, true, 0, "Pomidory", 3.0m, 0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CarbGram", "FatGram", "IsVegan", "Kcal", "Name", "Price", "ProteinGram" },
                values: new object[] { 0, 0, false, 0, "Kurczak", 4.0m, 0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FatGram", "IsVegan", "Kcal", "Name", "Price", "ProteinGram" },
                values: new object[] { 0, true, 0, "Oliwa z oliwek", 5.0m, 0 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "CarbGram", "FatGram", "IsVegan", "Kcal", "Name", "Price", "ProteinGram" },
                values: new object[,]
                {
                    { 6, 0, 0, false, 0, "Brokuły", 6.0m, 0 },
                    { 7, 0, 0, true, 0, "Cebula", 7.0m, 0 },
                    { 8, 0, 0, false, 0, "Ryż", 8.0m, 0 },
                    { 9, 0, 0, true, 0, "Marchewka", 9.0m, 0 },
                    { 10, 0, 0, false, 0, "Tuńczyk", 10.0m, 0 },
                    { 11, 0, 0, true, 0, "Ogórki", 11.0m, 0 },
                    { 12, 0, 0, false, 0, "Ser", 12.0m, 0 }
                });

            migrationBuilder.InsertData(
                table: "IngredientsForMeals",
                columns: new[] { "Id", "Grams", "IngredientId", "IsOptional", "MealId", "Mililiters", "Quantity" },
                values: new object[,]
                {
                    { 1, 100m, 1, false, 1, 0m, 1 },
                    { 2, 150m, 2, false, 1, 0m, 1 },
                    { 3, 50m, 3, false, 1, 0m, 1 },
                    { 4, 80m, 4, false, 1, 0m, 1 },
                    { 5, 100m, 3, false, 2, 0m, 1 },
                    { 6, 80m, 5, false, 2, 0m, 1 },
                    { 8, 150m, 4, false, 3, 0m, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IsVegan", "Name" },
                values: new object[] { false, "Jajecznica" });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "IsVegan", "Name" },
                values: new object[] { true, "Sałatka grecka" });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Kurczak z ryżem");

            migrationBuilder.InsertData(
                table: "IngredientsForMeals",
                columns: new[] { "Id", "Grams", "IngredientId", "IsOptional", "MealId", "Mililiters", "Quantity" },
                values: new object[,]
                {
                    { 7, 120m, 6, false, 2, 0m, 1 },
                    { 9, 100m, 8, false, 3, 0m, 1 },
                    { 10, 80m, 9, false, 3, 0m, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "IngredientsForMeals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "IngredientsForMeals",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "IngredientsForMeals",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "IngredientsForMeals",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "IngredientsForMeals",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "IngredientsForMeals",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "IngredientsForMeals",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "IngredientsForMeals",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "IngredientsForMeals",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "IngredientsForMeals",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CarbGram", "Kcal", "Name", "Price", "ProteinGram" },
                values: new object[] { 10, 50, "Broccoli", 3.5m, 3 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FatGram", "Kcal", "Name", "Price", "ProteinGram" },
                values: new object[] { 10, 200, "Chicken", 7.5m, 20 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FatGram", "IsVegan", "Kcal", "Name", "Price", "ProteinGram" },
                values: new object[] { 15, false, 250, "Salmon", 10.0m, 22 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CarbGram", "FatGram", "IsVegan", "Kcal", "Name", "Price", "ProteinGram" },
                values: new object[] { 25, 2, true, 120, "Quinoa", 5.0m, 4 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FatGram", "IsVegan", "Kcal", "Name", "Price", "ProteinGram" },
                values: new object[] { 20, false, 300, "Beef", 12.0m, 25 });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IsVegan", "Name" },
                values: new object[] { true, "Broccoli Salad" });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "IsVegan", "Name" },
                values: new object[] { false, "Grilled Chicken" });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Salmon Fillet");

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "Id", "IsVegan", "Name", "UserIdIfCustom" },
                values: new object[,]
                {
                    { 4, true, "Quinoa Bowl", 0 },
                    { 5, false, "Beef Stir Fry", 0 }
                });
        }
    }
}
