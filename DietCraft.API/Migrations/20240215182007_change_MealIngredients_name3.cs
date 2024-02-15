using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DietCraft.API.Migrations
{
    /// <inheritdoc />
    public partial class change_MealIngredients_name3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                newName: "MealIngredients");

            migrationBuilder.RenameIndex(
                name: "IX_MealIngredient_MealId",
                table: "MealIngredients",
                newName: "IX_MealIngredients_MealId");

            migrationBuilder.RenameIndex(
                name: "IX_MealIngredient_IngredientId",
                table: "MealIngredients",
                newName: "IX_MealIngredients_IngredientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MealIngredients",
                table: "MealIngredients",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$10$RUvIrvplu8B1ceIr0A1o8ua1qPj0oS1i8n05aIUNpVBkzC7u5IXa.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$10$TuS9tsKD8G2z1Ltpbk81hewYRDzf2KQGy9F.Sy3VdU4QjFSTFvWkO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$10$eQqw.6ac1JZI5jfApKf/ouGcLAObJ9/wRHxZvBuUUBbzwSfwi.IZi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$10$UQUzdhwdttdVUUIQxJYaK.gf6ccbTdaG.1c.W6tQUOyxSdrnqUOMC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "$2a$10$d5MgICIKUlP.lZpjlnJoPuKayO4yJY8BBa/v.Yo6r5uZiGictY7/K");

            migrationBuilder.AddForeignKey(
                name: "FK_MealIngredients_Ingredients_IngredientId",
                table: "MealIngredients",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MealIngredients_Meals_MealId",
                table: "MealIngredients",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealIngredients_Ingredients_IngredientId",
                table: "MealIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_MealIngredients_Meals_MealId",
                table: "MealIngredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MealIngredients",
                table: "MealIngredients");

            migrationBuilder.RenameTable(
                name: "MealIngredients",
                newName: "MealIngredient");

            migrationBuilder.RenameIndex(
                name: "IX_MealIngredients_MealId",
                table: "MealIngredient",
                newName: "IX_MealIngredient_MealId");

            migrationBuilder.RenameIndex(
                name: "IX_MealIngredients_IngredientId",
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
    }
}
