using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bordspelhub.Migrations
{
    /// <inheritdoc />
    public partial class updateusers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gebruiker",
                table: "Forums");

            migrationBuilder.DropColumn(
                name: "Gebruiker",
                table: "Evenementen");

            migrationBuilder.DropColumn(
                name: "Gebruiker",
                table: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "Gebruiker",
                table: "Spellen",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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
                name: "Owner",
                table: "Forums");

            migrationBuilder.DropColumn(
                name: "Creator",
                table: "Evenementen");

            migrationBuilder.DropColumn(
                name: "Commenter",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "Gebruiker",
                table: "Spellen",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
