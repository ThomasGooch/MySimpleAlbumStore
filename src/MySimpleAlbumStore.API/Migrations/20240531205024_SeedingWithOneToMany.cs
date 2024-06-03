using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MySimpleAlbumStore.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingWithOneToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "AlbumId", "ArtistId", "ArtistId1", "ImageUrl", "Title" },
                values: new object[,]
                {
                    { new Guid("b3a4341d-43e8-4a5b-9c72-c02c15d34ef5"), null, null, "https://example.com/album1.jpg", "Album 1" },
                    { new Guid("c144538b-20e3-41fb-b467-3f09b1e5a0e0"), null, null, "https://example.com/album2.jpg", "Album 2" }
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "ArtistId", "Name" },
                values: new object[,]
                {
                    { new Guid("0c7a93e1-f31f-42f0-9d0c-9e3dbdf61dac"), "John Smith" },
                    { new Guid("e9f66cbc-ed05-406d-84ec-05ddff1fba40"), "Jane Doe" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "AlbumId",
                keyValue: new Guid("b3a4341d-43e8-4a5b-9c72-c02c15d34ef5"));

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "AlbumId",
                keyValue: new Guid("c144538b-20e3-41fb-b467-3f09b1e5a0e0"));

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: new Guid("0c7a93e1-f31f-42f0-9d0c-9e3dbdf61dac"));

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: new Guid("e9f66cbc-ed05-406d-84ec-05ddff1fba40"));
        }
    }
}
