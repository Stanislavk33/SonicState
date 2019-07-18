using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SonicState.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Audios",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Bpm = table.Column<double>(nullable: false),
                    Key = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Audios_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Playlists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Playlists_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChordSequences",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Time = table.Column<double>(nullable: false),
                    Chord = table.Column<string>(nullable: true),
                    AudioId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChordSequences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChordSequences_Audios_AudioId",
                        column: x => x.AudioId,
                        principalTable: "Audios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlaylistAudio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AudioId = table.Column<string>(nullable: true),
                    PlaylistId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistAudio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaylistAudio_Audios_AudioId",
                        column: x => x.AudioId,
                        principalTable: "Audios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlaylistAudio_Playlists_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "Playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Audios_UserId",
                table: "Audios",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ChordSequences_AudioId",
                table: "ChordSequences",
                column: "AudioId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistAudio_AudioId",
                table: "PlaylistAudio",
                column: "AudioId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistAudio_PlaylistId",
                table: "PlaylistAudio",
                column: "PlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_UserId",
                table: "Playlists",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChordSequences");

            migrationBuilder.DropTable(
                name: "PlaylistAudio");

            migrationBuilder.DropTable(
                name: "Audios");

            migrationBuilder.DropTable(
                name: "Playlists");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
