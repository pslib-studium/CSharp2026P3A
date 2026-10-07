using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace t02efc_nm.Migrations
{
    /// <inheritdoc />
    public partial class inception : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Movieid",
                table: "Movies",
                newName: "MovieId");

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "ArtistId", "FirstName", "LastName" },
                values: new object[] { 1, "Leonardo", "DiCaprio" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "Name" },
                values: new object[] { 1, "Inception" });

            migrationBuilder.InsertData(
                table: "MovieActor",
                columns: new[] { "ArtistId", "MovieId", "RoleName" },
                values: new object[] { 1, 1, "Cobb" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MovieActor",
                keyColumns: new[] { "ArtistId", "MovieId", "RoleName" },
                keyValues: new object[] { 1, 1, "Cobb" });

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "Movies",
                newName: "Movieid");
        }
    }
}
