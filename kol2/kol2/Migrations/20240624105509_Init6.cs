using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace kol2.Migrations
{
    /// <inheritdoc />
    public partial class Init6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "IdCharacter", "CurrentWeight", "FirstName", "LastName", "MaxWeight" },
                values: new object[,]
                {
                    { 1, 10, "roman", "fuskii", 40 },
                    { 2, 12, "dd", "vcvc", 50 }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "IdItem", "Name", "Weight" },
                values: new object[,]
                {
                    { 1, "oksy", 20 },
                    { 2, "Anna", 15 }
                });

            migrationBuilder.InsertData(
                table: "Titles",
                columns: new[] { "IdTitle", "Name" },
                values: new object[,]
                {
                    { 1, "zzz" },
                    { 2, "ccc" }
                });

            migrationBuilder.InsertData(
                table: "Backpacks",
                columns: new[] { "IdCharacter", "IdItem", "Ammount" },
                values: new object[,]
                {
                    { 1, 2, 1 },
                    { 2, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "CharacterTitles",
                columns: new[] { "IdCharacter", "IdTitle", "AquiredAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2023, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Backpacks",
                keyColumns: new[] { "IdCharacter", "IdItem" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Backpacks",
                keyColumns: new[] { "IdCharacter", "IdItem" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "CharacterTitles",
                keyColumns: new[] { "IdCharacter", "IdTitle" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CharacterTitles",
                keyColumns: new[] { "IdCharacter", "IdTitle" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "IdCharacter",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "IdCharacter",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "IdItem",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "IdItem",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "IdTitle",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "IdTitle",
                keyValue: 2);
        }
    }
}
