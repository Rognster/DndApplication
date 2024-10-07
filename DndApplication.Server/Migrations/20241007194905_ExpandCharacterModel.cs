using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DndApplication.Server.Migrations
{
    /// <inheritdoc />
    public partial class ExpandCharacterModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "AbilityScore",
                table: "Characters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Alignment",
                table: "Characters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Background",
                table: "Characters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Class",
                table: "Characters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Equipments",
                table: "Characters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Feats",
                table: "Characters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Features",
                table: "Characters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Languages",
                table: "Characters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Player",
                table: "Characters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Proficiencies",
                table: "Characters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Race",
                table: "Characters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Skills",
                table: "Characters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Spells",
                table: "Characters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subclass",
                table: "Characters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subrace",
                table: "Characters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Traits",
                table: "Characters",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AbilityScore",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Alignment",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Background",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Class",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Equipments",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Feats",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Features",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Languages",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Player",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Proficiencies",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Race",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Skills",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Spells",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Subclass",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Subrace",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Traits",
                table: "Characters");

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
    }
}
