using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DietCraft.API.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DietTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CarbPercent = table.Column<byte>(type: "INTEGER", nullable: false),
                    ProteinPercent = table.Column<byte>(type: "INTEGER", nullable: false),
                    FatPercent = table.Column<byte>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    IsVegan = table.Column<bool>(type: "INTEGER", nullable: false),
                    Kcal = table.Column<int>(type: "INTEGER", nullable: false),
                    ProteinGram = table.Column<int>(type: "INTEGER", nullable: false),
                    CarbGram = table.Column<int>(type: "INTEGER", nullable: false),
                    FatGram = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    IsVegan = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserIdIfCustom = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Diets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    DietTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    isCustom = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserIdIfCustom = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diets_DietTypes_DietTypeId",
                        column: x => x.DietTypeId,
                        principalTable: "DietTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IngredientsForMeals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IngredientId = table.Column<int>(type: "INTEGER", nullable: false),
                    MealId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsOptional = table.Column<bool>(type: "INTEGER", nullable: false),
                    Grams = table.Column<decimal>(type: "TEXT", nullable: false),
                    Mililiters = table.Column<decimal>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientsForMeals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngredientsForMeals_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientsForMeals_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    DescriptionHTML = table.Column<string>(type: "TEXT", nullable: false),
                    TitleHTML = table.Column<string>(type: "TEXT", nullable: false),
                    MealId = table.Column<int>(type: "INTEGER", nullable: false),
                    isStepByStep = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    RoleId = table.Column<byte>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingLists_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserDiets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DietId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxKcal = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDiets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDiets_Diets_DietId",
                        column: x => x.DietId,
                        principalTable: "Diets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserDiets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingListIngredients",
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
                table: "DietTypes",
                columns: new[] { "Id", "CarbPercent", "FatPercent", "Name", "ProteinPercent" },
                values: new object[,]
                {
                    { 1, (byte)50, (byte)25, "Vegetarian", (byte)25 },
                    { 2, (byte)10, (byte)60, "Ketogenic", (byte)30 },
                    { 3, (byte)40, (byte)30, "Balanced", (byte)30 },
                    { 4, (byte)20, (byte)40, "Low Carb", (byte)40 },
                    { 5, (byte)45, (byte)35, "Mediterranean", (byte)20 }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "CarbGram", "FatGram", "IsVegan", "Kcal", "Name", "Price", "ProteinGram" },
                values: new object[,]
                {
                    { 1, 10, 0, true, 50, "Broccoli", 3.5m, 3 },
                    { 2, 0, 10, false, 200, "Chicken", 7.5m, 20 },
                    { 3, 0, 15, false, 250, "Salmon", 10.0m, 22 },
                    { 4, 25, 2, true, 120, "Quinoa", 5.0m, 4 },
                    { 5, 0, 20, false, 300, "Beef", 12.0m, 25 }
                });

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "Id", "IsVegan", "Name", "UserIdIfCustom" },
                values: new object[,]
                {
                    { 1, true, "Broccoli Salad", 0 },
                    { 2, false, "Grilled Chicken", 0 },
                    { 3, false, "Salmon Fillet", 0 },
                    { 4, true, "Quinoa Bowl", 0 },
                    { 5, false, "Beef Stir Fry", 0 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { (byte)1, "Admin" },
                    { (byte)2, "User" },
                    { (byte)3, "Manager" },
                    { (byte)4, "Viewer" },
                    { (byte)5, "Tester" }
                });

            migrationBuilder.InsertData(
                table: "Diets",
                columns: new[] { "Id", "DietTypeId", "Name", "UserIdIfCustom", "isCustom" },
                values: new object[,]
                {
                    { 1, 1, "Vegan Diet", 0, false },
                    { 2, 2, "Ketogenic Diet", 0, false },
                    { 3, 3, "Balanced Diet", 1, true },
                    { 4, 4, "Low Carb Diet", 2, true },
                    { 5, 5, "Mediterranean Diet", 3, true }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DescriptionHTML", "MealId", "Name", "TitleHTML", "isStepByStep" },
                values: new object[,]
                {
                    { 1, "<p>Delicious broccoli salad recipe.</p>", 1, "Broccoli Salad Recipe", "<h1>Broccoli Salad</h1>", true },
                    { 2, "<p>Perfectly grilled chicken recipe.</p>", 2, "Grilled Chicken Recipe", "<h1>Grilled Chicken</h1>", true },
                    { 3, "<p>Simple and tasty salmon fillet recipe.</p>", 3, "Salmon Fillet Recipe", "<h1>Salmon Fillet</h1>", true },
                    { 4, "<p>Healthy and flavorful quinoa bowl recipe.</p>", 4, "Quinoa Bowl Recipe", "<h1>Quinoa Bowl</h1>", true },
                    { 5, "<p>Quick and easy beef stir fry recipe.</p>", 5, "Beef Stir Fry Recipe", "<h1>Beef Stir Fry</h1>", true }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PasswordHash", "RoleId", "UserName" },
                values: new object[,]
                {
                    { 1, "john@example.com", "John", "Doe", "hashed_password", (byte)2, "john_doe" },
                    { 2, "alice@example.com", "Alice", "Smith", "hashed_password", (byte)2, "alice_smith" },
                    { 3, "bob@example.com", "Bob", "Johnson", "hashed_password", (byte)2, "bob_johnson" },
                    { 4, "emily@example.com", "Emily", "Brown", "hashed_password", (byte)2, "emily_brown" },
                    { 5, "david@example.com", "David", "Wilson", "hashed_password", (byte)2, "david_wilson" }
                });

            migrationBuilder.InsertData(
                table: "ShoppingLists",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, "Weekly Grocery List", 1 },
                    { 2, "Monthly Grocery List", 2 },
                    { 3, "Family Grocery List", 3 },
                    { 4, "Holiday Grocery List", 4 },
                    { 5, "Emergency Grocery List", 5 }
                });

            migrationBuilder.InsertData(
                table: "UserDiets",
                columns: new[] { "Id", "DietId", "MaxKcal", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 2000, 1 },
                    { 2, 2, 1800, 2 },
                    { 3, 3, 2200, 3 },
                    { 4, 4, 1900, 4 },
                    { 5, 5, 2100, 5 }
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

            migrationBuilder.CreateIndex(
                name: "IX_Diets_DietTypeId",
                table: "Diets",
                column: "DietTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientsForMeals_IngredientId",
                table: "IngredientsForMeals",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientsForMeals_MealId",
                table: "IngredientsForMeals",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_MealId",
                table: "Recipes",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListIngredients_IngredientId",
                table: "ShoppingListIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListIngredients_ShoppingListId",
                table: "ShoppingListIngredients",
                column: "ShoppingListId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingLists_UserId",
                table: "ShoppingLists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDiets_DietId",
                table: "UserDiets",
                column: "DietId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDiets_UserId",
                table: "UserDiets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientsForMeals");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "ShoppingListIngredients");

            migrationBuilder.DropTable(
                name: "UserDiets");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "ShoppingLists");

            migrationBuilder.DropTable(
                name: "Diets");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "DietTypes");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
