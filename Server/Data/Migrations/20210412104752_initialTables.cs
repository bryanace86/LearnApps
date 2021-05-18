using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LearnApps.Server.Data.Migrations
{
    public partial class initialTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Decks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FlashCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlashCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameRoundStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameRoundStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameTimers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AllowedTotalTime = table.Column<int>(type: "int", nullable: false),
                    RemainingTotalTime = table.Column<int>(type: "int", nullable: false),
                    ElapsedTotalTime = table.Column<int>(type: "int", nullable: false),
                    AllowedCardTime = table.Column<int>(type: "int", nullable: false),
                    RemainingCardTime = table.Column<int>(type: "int", nullable: false),
                    ElapsedCardTime = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameTimers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeckFlashCard",
                columns: table => new
                {
                    DecksId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FlashCardsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeckFlashCard", x => new { x.DecksId, x.FlashCardsId });
                    table.ForeignKey(
                        name: "FK_DeckFlashCard_Decks_DecksId",
                        column: x => x.DecksId,
                        principalTable: "Decks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeckFlashCard_FlashCards_FlashCardsId",
                        column: x => x.FlashCardsId,
                        principalTable: "FlashCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameRoundAttempts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnteredString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameRoundStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameRoundAttempts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameRoundAttempts_GameRoundStatuses_GameRoundStatusId",
                        column: x => x.GameRoundStatusId,
                        principalTable: "GameRoundStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameRounds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameTimerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameRounds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameRounds_GameTimers_GameTimerId",
                        column: x => x.GameTimerId,
                        principalTable: "GameTimers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameRounds_GameTypes_GameTypeId",
                        column: x => x.GameTypeId,
                        principalTable: "GameTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameRoundResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameRoundId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FlashCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ElapsedCardTime = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameRoundResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameRoundResults_FlashCards_FlashCardId",
                        column: x => x.FlashCardId,
                        principalTable: "FlashCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameRoundResults_GameRounds_GameRoundId",
                        column: x => x.GameRoundId,
                        principalTable: "GameRounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeckFlashCard_FlashCardsId",
                table: "DeckFlashCard",
                column: "FlashCardsId");

            migrationBuilder.CreateIndex(
                name: "IX_GameRoundAttempts_GameRoundStatusId",
                table: "GameRoundAttempts",
                column: "GameRoundStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_GameRoundResults_FlashCardId",
                table: "GameRoundResults",
                column: "FlashCardId");

            migrationBuilder.CreateIndex(
                name: "IX_GameRoundResults_GameRoundId",
                table: "GameRoundResults",
                column: "GameRoundId");

            migrationBuilder.CreateIndex(
                name: "IX_GameRounds_GameTimerId",
                table: "GameRounds",
                column: "GameTimerId");

            migrationBuilder.CreateIndex(
                name: "IX_GameRounds_GameTypeId",
                table: "GameRounds",
                column: "GameTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeckFlashCard");

            migrationBuilder.DropTable(
                name: "GameRoundAttempts");

            migrationBuilder.DropTable(
                name: "GameRoundResults");

            migrationBuilder.DropTable(
                name: "Decks");

            migrationBuilder.DropTable(
                name: "GameRoundStatuses");

            migrationBuilder.DropTable(
                name: "FlashCards");

            migrationBuilder.DropTable(
                name: "GameRounds");

            migrationBuilder.DropTable(
                name: "GameTimers");

            migrationBuilder.DropTable(
                name: "GameTypes");
        }
    }
}
