using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DietCraft.API.Migrations
{
    /// <inheritdoc />
    public partial class change_MealIngredients_name2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientsForMeals_Ingredients_IngredientId",
                table: "IngredientsForMeals");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientsForMeals_Meals_MealId",
                table: "IngredientsForMeals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientsForMeals",
                table: "IngredientsForMeals");

            migrationBuilder.RenameTable(
                name: "IngredientsForMeals",
                newName: "MealIngredient");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientsForMeals_MealId",
                table: "MealIngredient",
                newName: "IX_MealIngredient_MealId");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientsForMeals_IngredientId",
                table: "MealIngredient",
                newName: "IX_MealIngredient_IngredientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MealIngredient",
                table: "MealIngredient",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$10$PxMled0vg4fbXMFBq5Wt6e2UHJPa7kTlAuJZSTY35BHShKS0CMhd6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$10$.VHk5J3JIV3QKztRoiEeGuECMVh3pqJZYVlVCWy7OhY/8uZ8bHVm6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$10$dYZh1kIceoiOYaa5dfoAC.j9DX0ugJOTu5A8b4a/nMYGpSSLT4rnW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$10$pMVimY/6JfGOZbRJvISqFufnp/35LnHAqiYU4lWf6s6uwaVoUr6T6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "$2a$10$JwJqblmQr1ykdZ2A.o9kwePgenM78/FTJXWaMAmL4FWs/sa/KWYXq");

            migrationBuilder.AddForeignKey(
                name: "FK_MealIngredient_Ingredients_IngredientId",
                table: "MealIngredient",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MealIngredient_Meals_MealId",
                table: "MealIngredient",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealIngredient_Ingredients_IngredientId",
                table: "MealIngredient");

            migrationBuilder.DropForeignKey(
                name: "FK_MealIngredient_Meals_MealId",
                table: "MealIngredient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MealIngredient",
                table: "MealIngredient");

            migrationBuilder.RenameTable(
                name: "MealIngredient",
                newName: "IngredientsForMeals");

            migrationBuilder.RenameIndex(
                name: "IX_MealIngredient_MealId",
                table: "IngredientsForMeals",
                newName: "IX_IngredientsForMeals_MealId");

            migrationBuilder.RenameIndex(
                name: "IX_MealIngredient_IngredientId",
                table: "IngredientsForMeals",
                newName: "IX_IngredientsForMeals_IngredientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientsForMeals",
                table: "IngredientsForMeals",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$10$neuytSj0rdWuNamjqr6GIuGTRO8MUhBkGtfR9Zy3Y3/UEG29iykSm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$10$3047j/oeOPK/9a5kZqrspOjS/EcJiGStaW0NG2dhEn5jp93WTKDHG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$10$Q1UiGYiORYWsAlner0mBluY/HL48BQD7NuRxWPMKChsxIZzaDQXzy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$10$NlLFPlmXEQEbQ5d5BE6vnuurqaKqC2V3b2r7QeRw0l/o8BnCoXI0.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "$2a$10$Fl734FOcjlns9sV.F4nu3.X2c5sKCy81TOqixTlRuKfPBTKguYQHO");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientsForMeals_Ingredients_IngredientId",
                table: "IngredientsForMeals",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientsForMeals_Meals_MealId",
                table: "IngredientsForMeals",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
