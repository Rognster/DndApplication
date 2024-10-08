using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DndApplication.Server.Migrations
{
    /// <inheritdoc />
    public partial class abilityScoresAsInts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AbilityScore",
                table: "Characters");

            migrationBuilder.AddColumn<string>(
                name: "AbilityScores",
                table: "Characters",
                type: "TEXT",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AbilityScores",
                table: "Characters");

            migrationBuilder.AddColumn<string>(
                name: "AbilityScore",
                table: "Characters",
                type: "TEXT",
                nullable: true);
        }
    }
}
