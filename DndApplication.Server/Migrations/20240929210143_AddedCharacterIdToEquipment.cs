using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DndApplication.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddedCharacterIdToEquipment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemId = table.Column<string>(type: "TEXT", nullable: false),
                    CharacterId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipments_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Name", "Stats_Charisma", "Stats_Constitution", "Stats_Dexterity", "Stats_Intelligence", "Stats_Strength", "Stats_Wisdom" },
                values: new object[,]
                {
                    { 1, "Stefan", 10, 14, 12, 10, 15, 11 },
                    { 2, "Olle", 9, 15, 13, 11, 16, 12 }
                });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "CharacterId", "ItemId" },
                values: new object[,]
                {
                    { 1, 1, "sword" },
                    { 2, 1, "shield" },
                    { 3, 2, "axe" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_CharacterId",
                table: "Equipments",
                column: "CharacterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "INTEGER", nullable: false),
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    ItemId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => new { x.CharacterId, x.Id });
                    table.ForeignKey(
                        name: "FK_Equipment_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
