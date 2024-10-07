using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DndApplication.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddOneWayCharacterEquipmentRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "Equipments",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_CharacterId",
                table: "Equipments",
                column: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Characters_CharacterId",
                table: "Equipments",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Characters_CharacterId",
                table: "Equipments");

            migrationBuilder.DropIndex(
                name: "IX_Equipments_CharacterId",
                table: "Equipments");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "Equipments");
        }
    }
}
