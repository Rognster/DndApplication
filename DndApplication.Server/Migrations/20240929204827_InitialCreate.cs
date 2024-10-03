using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DndApplication.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Stats_Strength = table.Column<int>(type: "INTEGER", nullable: false),
                    Stats_Dexterity = table.Column<int>(type: "INTEGER", nullable: false),
                    Stats_Constitution = table.Column<int>(type: "INTEGER", nullable: false),
                    Stats_Intelligence = table.Column<int>(type: "INTEGER", nullable: false),
                    Stats_Wisdom = table.Column<int>(type: "INTEGER", nullable: false),
                    Stats_Charisma = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Characters");
        }
    }
}
