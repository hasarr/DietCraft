using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DietCraft.API.Migrations
{
    /// <inheritdoc />
    public partial class bulkInsert2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isCustom",
                table: "Meals",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 1,
                column: "isCustom",
                value: false);

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 2,
                column: "isCustom",
                value: false);

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "UserIdIfCustom", "isCustom" },
                values: new object[] { 2, true });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isCustom",
                table: "Meals");

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserIdIfCustom",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$10$q8a4rK3A7wblUgM.mAwgheFj.vm9va86QL84yDYz8HA8kwJfLtp9u");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$10$kpgE5duPhmrRrICec7HiGupGOQ.VwmQCHri0/WxsNL2PHAMT/Ywkm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$10$zoPclQTUbuUfmMhxNJw6eutJN4SDvuhDQPgr43z1JXZ4VLuG.3PUK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$10$.NBMSQ9YQ1iP.XeG59sp6erjnNWHKvz3.PJD11lKPU86OzTiGTMSa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "$2a$10$TJA2TVHEN/E1chHMI58Mc.OzzBJwoYAkJDCulJ/ruW7TjKvc8/3IC");
        }
    }
}
