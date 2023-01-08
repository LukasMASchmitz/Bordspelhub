using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bordspelhub.Migrations
{
    /// <inheritdoc />
    public partial class fixgebruiker : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Forums_ForumId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ForumId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "Creator",
                table: "Spellen",
                newName: "Gebruiker");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Gebruiker",
                table: "Spellen",
                newName: "Creator");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ForumId",
                table: "Comments",
                column: "ForumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Forums_ForumId",
                table: "Comments",
                column: "ForumId",
                principalTable: "Forums",
                principalColumn: "ForumId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
