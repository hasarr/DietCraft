using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DietCraft.API.Migrations
{
    /// <inheritdoc />
    public partial class newBulk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CarbGram", "FatGram", "Kcal", "ProteinGram" },
                values: new object[] { 1, 11, 155, 13 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CarbGram", "Kcal", "ProteinGram" },
                values: new object[] { 3, 23, 2 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CarbGram", "Kcal", "ProteinGram" },
                values: new object[] { 4, 18, 1 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FatGram", "Kcal", "ProteinGram" },
                values: new object[] { 14, 239, 27 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FatGram", "Kcal" },
                values: new object[] { 100, 884 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CarbGram", "Kcal", "ProteinGram" },
                values: new object[] { 7, 34, 3 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CarbGram", "Kcal", "ProteinGram" },
                values: new object[] { 10, 40, 1 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CarbGram", "Kcal", "ProteinGram" },
                values: new object[] { 28, 130, 2 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CarbGram", "Kcal", "ProteinGram" },
                values: new object[] { 10, 41, 1 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "FatGram", "Kcal", "ProteinGram" },
                values: new object[] { 8, 184, 25 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CarbGram", "Kcal", "ProteinGram" },
                values: new object[] { 3, 15, 1 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CarbGram", "FatGram", "Kcal", "ProteinGram" },
                values: new object[] { 1, 32, 403, 25 });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CarbGram", "FatGram", "Kcal", "ProteinGram" },
                values: new object[] { 0, 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CarbGram", "Kcal", "ProteinGram" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CarbGram", "Kcal", "ProteinGram" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FatGram", "Kcal", "ProteinGram" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FatGram", "Kcal" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CarbGram", "Kcal", "ProteinGram" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CarbGram", "Kcal", "ProteinGram" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CarbGram", "Kcal", "ProteinGram" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CarbGram", "Kcal", "ProteinGram" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "FatGram", "Kcal", "ProteinGram" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CarbGram", "Kcal", "ProteinGram" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CarbGram", "FatGram", "Kcal", "ProteinGram" },
                values: new object[] { 0, 0, 0, 0 });

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
        }
    }
}
