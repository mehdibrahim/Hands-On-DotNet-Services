using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "Director", "Name", "Rating", "Sections", "WebSite" },
                values: new object[,]
                {
                    { 1, "Ali Douik", "ENISo", 3.5, "IA,GTE,GMP", "http://www.eniso.rnu.tn" },
                    { 2, "Mohamed Salah", "ENIM", 2.7999999999999998, "Mécanique,énergitique,textile", null },
                    { 3, "Ali Salah", "ENIT", 4.0, "Télécom,Info,Indus", "http://www.enit.rnu.tn" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
