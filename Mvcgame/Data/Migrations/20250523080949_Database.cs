using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mvcgame.Data.Migrations
{
    /// <inheritdoc />
    public partial class Database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "armor_ID",
                table: "game_character");

            migrationBuilder.DropColumn(
                name: "potions_ID",
                table: "game_character");

            migrationBuilder.DropColumn(
                name: "weapon_ID",
                table: "game_character");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "armor_ID",
                table: "game_character",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "potions_ID",
                table: "game_character",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "weapon_ID",
                table: "game_character",
                type: "int",
                nullable: true);
        }
    }
}
