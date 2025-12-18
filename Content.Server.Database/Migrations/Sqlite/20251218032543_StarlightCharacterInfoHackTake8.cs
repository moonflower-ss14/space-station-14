using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Content.Server.Database.Migrations.Sqlite
{
    /// <inheritdoc />
    public partial class StarlightCharacterInfoHackTake8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "character_secrets",
                table: "sl_character_info");

            migrationBuilder.DropColumn(
                name: "exploitable_info",
                table: "sl_character_info");

            migrationBuilder.DropColumn(
                name: "oocnotes",
                table: "sl_character_info");

            migrationBuilder.DropColumn(
                name: "personal_notes",
                table: "sl_character_info");

            migrationBuilder.DropColumn(
                name: "personality_desc",
                table: "sl_character_info");

            migrationBuilder.DropColumn(
                name: "physical_desc",
                table: "sl_character_info");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "character_secrets",
                table: "sl_character_info",
                type: "TEXT",
                maxLength: 4096,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "exploitable_info",
                table: "sl_character_info",
                type: "TEXT",
                maxLength: 4096,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "oocnotes",
                table: "sl_character_info",
                type: "TEXT",
                maxLength: 4096,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "personal_notes",
                table: "sl_character_info",
                type: "TEXT",
                maxLength: 4096,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "personality_desc",
                table: "sl_character_info",
                type: "TEXT",
                maxLength: 4096,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "physical_desc",
                table: "sl_character_info",
                type: "TEXT",
                maxLength: 4096,
                nullable: false,
                defaultValue: "");
        }
    }
}
