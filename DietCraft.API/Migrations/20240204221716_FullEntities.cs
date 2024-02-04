using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DietCraft.API.Migrations
{
    /// <inheritdoc />
    public partial class FullEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserIdIfCustomDiet",
                table: "Diets",
                newName: "UserIdIfCustom");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$10$1j4uSrWgQ0K8bzmvKV5vK.Jts/7eQqaZLAN6zIwR7iw7MbHJb3tP6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$10$WFwVHEa7fV1gEqqslopnuuM8ESdUkieUMMVKh/Gr4/N7FXXBRN3pi");

            migrationBuilder.CreateIndex(
                name: "IX_UserDiets_DietId",
                table: "UserDiets",
                column: "DietId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDiets_UserId",
                table: "UserDiets",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDiets_Diets_DietId",
                table: "UserDiets",
                column: "DietId",
                principalTable: "Diets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDiets_Users_UserId",
                table: "UserDiets",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDiets_Diets_DietId",
                table: "UserDiets");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDiets_Users_UserId",
                table: "UserDiets");

            migrationBuilder.DropIndex(
                name: "IX_UserDiets_DietId",
                table: "UserDiets");

            migrationBuilder.DropIndex(
                name: "IX_UserDiets_UserId",
                table: "UserDiets");

            migrationBuilder.RenameColumn(
                name: "UserIdIfCustom",
                table: "Diets",
                newName: "UserIdIfCustomDiet");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$10$zVZE7ruiAwBhJ/RQsCuaTO.7CQi7zhYyeEtvaka1gu8D1DyZNplgu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$10$ihXwUVjMNtV4A8c5T69j0eYjNFu83XSQ9o0g8QNDib4sfqJf8K/4y");
        }
    }
}
