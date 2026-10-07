using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace t02efc_nm.Migrations
{
    /// <inheritdoc />
    public partial class nm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Artists_ArtistId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_ArtistId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "Movies");

            migrationBuilder.CreateTable(
                name: "MovieActor",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "INTEGER", nullable: false),
                    ArtistId = table.Column<int>(type: "INTEGER", nullable: false),
                    RoleName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieActor", x => new { x.MovieId, x.ArtistId, x.RoleName });
                    table.ForeignKey(
                        name: "FK_MovieActor_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieActor_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Movieid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieActor_ArtistId",
                table: "MovieActor",
                column: "ArtistId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieActor");

            migrationBuilder.AddColumn<int>(
                name: "ArtistId",
                table: "Movies",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_ArtistId",
                table: "Movies",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Artists_ArtistId",
                table: "Movies",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "ArtistId");
        }
    }
}
