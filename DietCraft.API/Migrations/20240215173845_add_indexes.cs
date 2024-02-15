using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DietCraft.API.Migrations
{
    /// <inheritdoc />
    public partial class add_indexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserDiets_DietId",
                table: "UserDiets");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingListIngredients_ShoppingListId",
                table: "ShoppingListIngredients");

            migrationBuilder.RenameColumn(
                name: "isStepByStep",
                table: "Recipes",
                newName: "IsStepByStep");

            migrationBuilder.RenameColumn(
                name: "isCustom",
                table: "Meals",
                newName: "IsCustom");

            migrationBuilder.RenameColumn(
                name: "isCustom",
                table: "Diets",
                newName: "IsCustom");

            migrationBuilder.AddColumn<bool>(
                name: "IsCustom",
                table: "DietTypes",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UserIdIfCustom",
                table: "DietTypes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "DietTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IsCustom", "UserIdIfCustom" },
                values: new object[] { false, 0 });

            migrationBuilder.UpdateData(
                table: "DietTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "IsCustom", "UserIdIfCustom" },
                values: new object[] { false, 0 });

            migrationBuilder.UpdateData(
                table: "DietTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "IsCustom", "UserIdIfCustom" },
                values: new object[] { false, 0 });

            migrationBuilder.UpdateData(
                table: "DietTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "IsCustom", "UserIdIfCustom" },
                values: new object[] { false, 0 });

            migrationBuilder.UpdateData(
                table: "DietTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "IsCustom", "UserIdIfCustom" },
                values: new object[] { false, 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$10$uIXRD5TlLL27tybi38G3COQ6DFw8H3o3Z3cSoQG0Mwk6HL9Go7vCi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$10$woYf5nd9pQSaxCVk2n0AQuG7HFW0ESyXhfNcWsjeuTEKkbua1jyhO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$10$.pjgCLwlQrTOBzAZUFwAteff5SXK5m4zLYmK7UGHwd3FcFzY96DcG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$10$/b0XFrJWw70rCWZkoNp/QedUIqegGB.D2syLECG1T7ECJnYdf9Ale");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "$2a$10$07hF3W8RiZkgFo4ZyLj04.3ML.RNepV1OzKOC2/kfebALO01iOtNG");

            migrationBuilder.CreateIndex(
                name: "IX_UserDiets_DietId_UserId",
                table: "UserDiets",
                columns: new[] { "DietId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingLists_Name_UserId",
                table: "ShoppingLists",
                columns: new[] { "Name", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListIngredients_ShoppingListId_IngredientId",
                table: "ShoppingListIngredients",
                columns: new[] { "ShoppingListId", "IngredientId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Name",
                table: "Roles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_Name",
                table: "Recipes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Meals_Name_IsCustom_UserIdIfCustom",
                table: "Meals",
                columns: new[] { "Name", "IsCustom", "UserIdIfCustom" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Diets_Name_IsCustom_UserIdIfCustom",
                table: "Diets",
                columns: new[] { "Name", "IsCustom", "UserIdIfCustom" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DietTypes_Name_IsCustom_UserIdIfCustom",
                table: "DietTypes",
                columns: new[] { "Name", "IsCustom", "UserIdIfCustom" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserDiets_DietId_UserId",
                table: "UserDiets");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingLists_Name_UserId",
                table: "ShoppingLists");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingListIngredients_ShoppingListId_IngredientId",
                table: "ShoppingListIngredients");

            migrationBuilder.DropIndex(
                name: "IX_Roles_Name",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_Name",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Meals_Name_IsCustom_UserIdIfCustom",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Diets_Name_IsCustom_UserIdIfCustom",
                table: "Diets");

            migrationBuilder.DropIndex(
                name: "IX_DietTypes_Name_IsCustom_UserIdIfCustom",
                table: "DietTypes");

            migrationBuilder.DropColumn(
                name: "IsCustom",
                table: "DietTypes");

            migrationBuilder.DropColumn(
                name: "UserIdIfCustom",
                table: "DietTypes");

            migrationBuilder.RenameColumn(
                name: "IsStepByStep",
                table: "Recipes",
                newName: "isStepByStep");

            migrationBuilder.RenameColumn(
                name: "IsCustom",
                table: "Meals",
                newName: "isCustom");

            migrationBuilder.RenameColumn(
                name: "IsCustom",
                table: "Diets",
                newName: "isCustom");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$10$SU.Ka6nvOdX15p8.7eFr4OXz8qEz2R1aUw/4zBXQxDVIJlg5yluKi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$10$0H5.BPpHfZiNkHmoACqGBuIhplU44xks29p8cdY9yp7okzY.OWxaa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$10$vVyI57NOixCUe7.QPfQTx.K5sWCzx9UmR1ne6l13jvbjs2jXW8Z/e");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$10$IgqUrkWuD7AH31ITYsWtUO1KvQYXz8cXMGiH.Lvw/3e05qr3pByiW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "$2a$10$hdCG7L8Y6KJJ2Gp7yj9dQeqs7SYilDnaLO5PJFkhsoiChm5E8aJKa");

            migrationBuilder.CreateIndex(
                name: "IX_UserDiets_DietId",
                table: "UserDiets",
                column: "DietId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListIngredients_ShoppingListId",
                table: "ShoppingListIngredients",
                column: "ShoppingListId");
        }
    }
}
