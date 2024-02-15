using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DietCraft.API.Migrations
{
    /// <inheritdoc />
    public partial class change_MealIngredients_name : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
