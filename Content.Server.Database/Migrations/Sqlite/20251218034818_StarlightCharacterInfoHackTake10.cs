using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Content.Server.Database.Migrations.Sqlite
{
    /// <inheritdoc />
    public partial class StarlightCharacterInfoHackTake10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "custom_specie_name",
                table: "star_light_profile");

            migrationBuilder.DropColumn(
                name: "cybernetic_ids",
                table: "star_light_profile");

            migrationBuilder.DropColumn(
                name: "height",
                table: "star_light_profile");

            migrationBuilder.DropColumn(
                name: "width",
                table: "star_light_profile");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "custom_specie_name",
                table: "star_light_profile",
                type: "TEXT",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cybernetic_ids",
                table: "star_light_profile",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "height",
                table: "star_light_profile",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "width",
                table: "star_light_profile",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
