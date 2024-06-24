using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kol2.Migrations
{
    /// <inheritdoc />
    public partial class Init5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Backpacks_Items_Iditem",
                table: "Backpacks");

            migrationBuilder.RenameColumn(
                name: "Iditem",
                table: "Backpacks",
                newName: "IdItem");

            migrationBuilder.RenameIndex(
                name: "IX_Backpacks_Iditem",
                table: "Backpacks",
                newName: "IX_Backpacks_IdItem");

            migrationBuilder.CreateTable(
                name: "CharacterTitles",
                columns: table => new
                {
                    IdCharacter = table.Column<int>(type: "int", nullable: false),
                    IdTitle = table.Column<int>(type: "int", nullable: false),
                    AquiredAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterTitles", x => new { x.IdCharacter, x.IdTitle });
                    table.ForeignKey(
                        name: "FK_CharacterTitles_Characters_IdCharacter",
                        column: x => x.IdCharacter,
                        principalTable: "Characters",
                        principalColumn: "IdCharacter",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterTitles_Titles_IdTitle",
                        column: x => x.IdTitle,
                        principalTable: "Titles",
                        principalColumn: "IdTitle",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterTitles_IdTitle",
                table: "CharacterTitles",
                column: "IdTitle");

            migrationBuilder.AddForeignKey(
                name: "FK_Backpacks_Items_IdItem",
                table: "Backpacks",
                column: "IdItem",
                principalTable: "Items",
                principalColumn: "IdItem",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Backpacks_Items_IdItem",
                table: "Backpacks");

            migrationBuilder.DropTable(
                name: "CharacterTitles");

            migrationBuilder.RenameColumn(
                name: "IdItem",
                table: "Backpacks",
                newName: "Iditem");

            migrationBuilder.RenameIndex(
                name: "IX_Backpacks_IdItem",
                table: "Backpacks",
                newName: "IX_Backpacks_Iditem");

            migrationBuilder.AddForeignKey(
                name: "FK_Backpacks_Items_Iditem",
                table: "Backpacks",
                column: "Iditem",
                principalTable: "Items",
                principalColumn: "IdItem",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
