using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace t01efc.Migrations
{
    /// <inheritdoc />
    public partial class Developers2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeveloperGame_Developer_DevelopersDeveloperId",
                table: "DeveloperGame");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Developer",
                table: "Developer");

            migrationBuilder.RenameTable(
                name: "Developer",
                newName: "Developers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Developers",
                table: "Developers",
                column: "DeveloperId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeveloperGame_Developers_DevelopersDeveloperId",
                table: "DeveloperGame",
                column: "DevelopersDeveloperId",
                principalTable: "Developers",
                principalColumn: "DeveloperId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeveloperGame_Developers_DevelopersDeveloperId",
                table: "DeveloperGame");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Developers",
                table: "Developers");

            migrationBuilder.RenameTable(
                name: "Developers",
                newName: "Developer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Developer",
                table: "Developer",
                column: "DeveloperId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeveloperGame_Developer_DevelopersDeveloperId",
                table: "DeveloperGame",
                column: "DevelopersDeveloperId",
                principalTable: "Developer",
                principalColumn: "DeveloperId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
