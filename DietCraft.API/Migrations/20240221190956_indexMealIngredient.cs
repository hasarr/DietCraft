using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DietCraft.API.Migrations
{
    /// <inheritdoc />
    public partial class indexMealIngredient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingListIngredients");

            migrationBuilder.DropIndex(
                name: "IX_MealIngredients_IngredientId",
                table: "MealIngredients");

            migrationBuilder.CreateTable(
                name: "ShoppingListIngredient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ShoppingListId = table.Column<int>(type: "INTEGER", nullable: false),
                    IngredientId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingListIngredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingListIngredient_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingListIngredient_ShoppingLists_ShoppingListId",
                        column: x => x.ShoppingListId,
                        principalTable: "ShoppingLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ShoppingListIngredient",
                columns: new[] { "Id", "IngredientId", "Quantity", "ShoppingListId" },
                values: new object[,]
                {
                    { 1, 1, 2, 1 },
                    { 2, 2, 1, 1 },
                    { 3, 3, 3, 2 },
                    { 4, 4, 2, 3 },
                    { 5, 5, 1, 4 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$10$C6eCPgBjc4vRoY4tBAgC3.BgDAFodK2.5HitMhRJZQI15Jr4yWVAy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$10$PFWhzwURniv5.tnwNUnlDOCCtg.4CY8d3W63hnL2PgIilsWy81Z6C");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$10$V5Y1lc.Hx1tb6pLktAVh4./ngTu7tsG3nLPJcpusLVDjbjUaOcqUK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$10$XgOhp6E5rzzLFScG7OAGTOD7gckK8FdaSpOrzqg7IEBNpHjpuj23.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "$2a$10$F4bB6ti5OXCw0ZnQD3W7q.FF79mlmq4L50c5XpT8xsjzBMxQ14NL2");

            migrationBuilder.CreateIndex(
                name: "IX_MealIngredients_IngredientId_MealId",
                table: "MealIngredients",
                columns: new[] { "IngredientId", "MealId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListIngredient_IngredientId",
                table: "ShoppingListIngredient",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListIngredient_ShoppingListId_IngredientId",
                table: "ShoppingListIngredient",
                columns: new[] { "ShoppingListId", "IngredientId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingListIngredient");

            migrationBuilder.DropIndex(
                name: "IX_MealIngredients_IngredientId_MealId",
                table: "MealIngredients");

            migrationBuilder.CreateTable(
                name: "ShoppingListIngredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IngredientId = table.Column<int>(type: "INTEGER", nullable: false),
                    ShoppingListId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingListIngredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingListIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingListIngredients_ShoppingLists_ShoppingListId",
                        column: x => x.ShoppingListId,
                        principalTable: "ShoppingLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ShoppingListIngredients",
                columns: new[] { "Id", "IngredientId", "Quantity", "ShoppingListId" },
                values: new object[,]
                {
                    { 1, 1, 2, 1 },
                    { 2, 2, 1, 1 },
                    { 3, 3, 3, 2 },
                    { 4, 4, 2, 3 },
                    { 5, 5, 1, 4 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$10$kB/23bpMbDbLl6yTWfh.yOXNidPUY2S.oq2DkZf3CNr3t7Yx8ayBO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$10$99XX0KptARzKb2uAoqoiiuHAAf2lrf/EHoUf2wk8ST0ACg4MGqEV2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$10$bLg1QeDatp4i4xzlBgdNwOHi/CFvp4rbt54zx2hrqq20qB0Kx/anC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$10$ILqLv0pqCNBKkK8dozZWVuoMxeiiBguyab4zqpUwJAKzBLv.X1KnK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "$2a$10$1RJKPyqiXfFN2hMIu5Tr9OAda7oLekjfJ7c8E4l2HfljBY4beQtam");

            migrationBuilder.CreateIndex(
                name: "IX_MealIngredients_IngredientId",
                table: "MealIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListIngredients_IngredientId",
                table: "ShoppingListIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListIngredients_ShoppingListId_IngredientId",
                table: "ShoppingListIngredients",
                columns: new[] { "ShoppingListId", "IngredientId" },
                unique: true);
        }
    }
}
