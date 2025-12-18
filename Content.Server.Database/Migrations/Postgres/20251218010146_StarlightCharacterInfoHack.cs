using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Content.Server.Database.Migrations.Postgres
{
    /// <inheritdoc />
    public partial class StarlightCharacterInfoHack : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_job_one_high_priority",
                table: "job");

            migrationBuilder.DropColumn(
                name: "pref_unavailable",
                table: "profile");

            migrationBuilder.DropColumn(
                name: "selected_character_slot",
                table: "preference");

            migrationBuilder.DropColumn(
                name: "priority",
                table: "job");

            migrationBuilder.AddColumn<bool>(
                name: "enabled",
                table: "profile",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "eye_glowing",
                table: "profile",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "facial_hair_glowing",
                table: "profile",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "hair_glowing",
                table: "profile",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "silicon_voice",
                table: "profile",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "voice",
                table: "profile",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "job_priority_entry",
                columns: table => new
                {
                    job_priority_entry_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    preference_id = table.Column<int>(type: "integer", nullable: false),
                    job_name = table.Column<string>(type: "text", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_job_priority_entry", x => x.job_priority_entry_id);
                    table.ForeignKey(
                        name: "FK_job_priority_entry_preference_preference_id",
                        column: x => x.preference_id,
                        principalTable: "preference",
                        principalColumn: "preference_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "player_data",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: true),
                    ghost_theme = table.Column<string>(type: "text", nullable: true),
                    balance = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_player_data", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "sl_character_info",
                columns: table => new
                {
                    profile_id = table.Column<int>(type: "integer", nullable: false),
                    physical_desc = table.Column<string>(type: "character varying(4096)", maxLength: 4096, nullable: false),
                    personality_desc = table.Column<string>(type: "character varying(4096)", maxLength: 4096, nullable: false),
                    personal_notes = table.Column<string>(type: "character varying(4096)", maxLength: 4096, nullable: false),
                    character_secrets = table.Column<string>(type: "character varying(4096)", maxLength: 4096, nullable: false),
                    exploitable_info = table.Column<string>(type: "character varying(4096)", maxLength: 4096, nullable: false),
                    oocnotes = table.Column<string>(type: "character varying(4096)", maxLength: 4096, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sl_character_info", x => x.profile_id);
                    table.ForeignKey(
                        name: "FK_sl_character_info_profile_profile_id",
                        column: x => x.profile_id,
                        principalTable: "profile",
                        principalColumn: "profile_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "star_light_profile",
                columns: table => new
                {
                    star_light_profile_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    profile_id = table.Column<int>(type: "integer", nullable: false),
                    custom_specie_name = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    cybernetic_ids = table.Column<List<string>>(type: "text[]", nullable: false),
                    width = table.Column<float>(type: "real", nullable: false),
                    height = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_star_light_profile", x => x.star_light_profile_id);
                    table.ForeignKey(
                        name: "FK_star_light_profile_profile_profile_id",
                        column: x => x.profile_id,
                        principalTable: "profile",
                        principalColumn: "profile_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_job_one_high_priority",
                table: "job_priority_entry",
                column: "preference_id",
                unique: true,
                filter: "priority = 3");

            migrationBuilder.CreateIndex(
                name: "IX_job_priority_entry_preference_id",
                table: "job_priority_entry",
                column: "preference_id");

            migrationBuilder.CreateIndex(
                name: "UX_JobPriorityEntry_Pref_Job",
                table: "job_priority_entry",
                columns: new[] { "preference_id", "job_name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_star_light_profile_profile_id",
                table: "star_light_profile",
                column: "profile_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "job_priority_entry");

            migrationBuilder.DropTable(
                name: "player_data");

            migrationBuilder.DropTable(
                name: "sl_character_info");

            migrationBuilder.DropTable(
                name: "star_light_profile");

            migrationBuilder.DropColumn(
                name: "enabled",
                table: "profile");

            migrationBuilder.DropColumn(
                name: "eye_glowing",
                table: "profile");

            migrationBuilder.DropColumn(
                name: "facial_hair_glowing",
                table: "profile");

            migrationBuilder.DropColumn(
                name: "hair_glowing",
                table: "profile");

            migrationBuilder.DropColumn(
                name: "silicon_voice",
                table: "profile");

            migrationBuilder.DropColumn(
                name: "voice",
                table: "profile");

            migrationBuilder.AddColumn<int>(
                name: "pref_unavailable",
                table: "profile",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "selected_character_slot",
                table: "preference",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "priority",
                table: "job",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_job_one_high_priority",
                table: "job",
                column: "profile_id",
                unique: true,
                filter: "priority = 3");
        }
    }
}
