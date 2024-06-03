using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MySimpleAlbumStore.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("9fee74ea-80ce-4d66-9fe0-3e73c40959b4"), "Metallica" },
                    { new Guid("bd1404f5-487d-44cb-8aae-5ab28b4349ee"), "Iron Maiden" },
                    { new Guid("dd62b67a-8e0b-4f29-bd5f-4c5f9f191c60"), "Megadeth" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("9fee74ea-80ce-4d66-9fe0-3e73c40959b4"));

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("bd1404f5-487d-44cb-8aae-5ab28b4349ee"));

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("dd62b67a-8e0b-4f29-bd5f-4c5f9f191c60"));
        }
    }
}
