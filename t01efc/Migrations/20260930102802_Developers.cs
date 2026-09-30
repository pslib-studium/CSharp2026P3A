using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace t01efc.Migrations
{
    /// <inheritdoc />
    public partial class Developers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Developer",
                columns: table => new
                {
                    DeveloperId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developer", x => x.DeveloperId);
                });

            migrationBuilder.CreateTable(
                name: "DeveloperGame",
                columns: table => new
                {
                    DevelopersDeveloperId = table.Column<int>(type: "INTEGER", nullable: false),
                    GamesGameId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperGame", x => new { x.DevelopersDeveloperId, x.GamesGameId });
                    table.ForeignKey(
                        name: "FK_DeveloperGame_Developer_DevelopersDeveloperId",
                        column: x => x.DevelopersDeveloperId,
                        principalTable: "Developer",
                        principalColumn: "DeveloperId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeveloperGame_Games_GamesGameId",
                        column: x => x.GamesGameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Developer",
                columns: new[] { "DeveloperId", "Name" },
                values: new object[,]
                {
                    { 1, "CD Projekt Red" },
                    { 2, "Bethesda Game Studios" },
                    { 3, "Rockstar Games" },
                    { 4, "Valve Corporation" },
                    { 5, "Ubisoft" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperGame_GamesGameId",
                table: "DeveloperGame",
                column: "GamesGameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeveloperGame");

            migrationBuilder.DropTable(
                name: "Developer");
        }
    }
}
