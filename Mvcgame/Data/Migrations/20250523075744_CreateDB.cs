using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mvcgame.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Armors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    protection = table.Column<int>(type: "int", nullable: false),
                    durability = table.Column<int>(type: "int", nullable: false),
                    max_durability = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Potions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    protection = table.Column<int>(type: "int", nullable: false),
                    damage = table.Column<int>(type: "int", nullable: false),
                    heal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Potions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    damage = table.Column<int>(type: "int", nullable: false),
                    durability = table.Column<int>(type: "int", nullable: false),
                    max_durability = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "game_character",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nickname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    max_HP = table.Column<int>(type: "int", nullable: false),
                    HP = table.Column<int>(type: "int", nullable: false),
                    armor_ID = table.Column<int>(type: "int", nullable: true),
                    ArmorsID = table.Column<int>(type: "int", nullable: true),
                    weapon_ID = table.Column<int>(type: "int", nullable: true),
                    WeaponsID = table.Column<int>(type: "int", nullable: true),
                    potions_ID = table.Column<int>(type: "int", nullable: true),
                    PotionsID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_game_character", x => x.ID);
                    table.ForeignKey(
                        name: "FK_game_character_Armors_ArmorsID",
                        column: x => x.ArmorsID,
                        principalTable: "Armors",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_game_character_Potions_PotionsID",
                        column: x => x.PotionsID,
                        principalTable: "Potions",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_game_character_Weapons_WeaponsID",
                        column: x => x.WeaponsID,
                        principalTable: "Weapons",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_game_character_ArmorsID",
                table: "game_character",
                column: "ArmorsID");

            migrationBuilder.CreateIndex(
                name: "IX_game_character_PotionsID",
                table: "game_character",
                column: "PotionsID");

            migrationBuilder.CreateIndex(
                name: "IX_game_character_WeaponsID",
                table: "game_character",
                column: "WeaponsID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "game_character");

            migrationBuilder.DropTable(
                name: "Armors");

            migrationBuilder.DropTable(
                name: "Potions");

            migrationBuilder.DropTable(
                name: "Weapons");
        }
    }
}
