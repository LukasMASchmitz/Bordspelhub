using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bordspelhub.Migrations
{
    /// <inheritdoc />
    public partial class fixdit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gebruiker",
                table: "Spellen");

            migrationBuilder.DropColumn(
                name: "Gebruiker",
                table: "Forums");

            migrationBuilder.DropColumn(
                name: "Gebruiker",
                table: "Evenementen");

            migrationBuilder.DropColumn(
                name: "Gebruiker",
                table: "Comments");

            migrationBuilder.AddColumn<string>(
                name: "Creator",
                table: "Spellen",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "Forums",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Creator",
                table: "Evenementen",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Commenter",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Creator",
                table: "Spellen");

            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Forums");

            migrationBuilder.DropColumn(
                name: "Creator",
                table: "Evenementen");

            migrationBuilder.DropColumn(
                name: "Commenter",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "Gebruiker",
                table: "Spellen",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Gebruiker",
                table: "Forums",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Gebruiker",
                table: "Evenementen",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Gebruiker",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
