using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MySimpleAlbumStore.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "AlbumId",
                keyValue: new Guid("738ea536-f44c-45ab-bfc5-e856f483bad0"));

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "AlbumId",
                keyValue: new Guid("88326a7d-79d5-4c7f-a7e2-d0e04f1836ac"));

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: new Guid("b109cacf-33b4-4004-9b8a-2a030220e765"));

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: new Guid("ed1d9c53-2ea8-42c4-9596-728d4c0e839e"));

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "ArtistId", "Name" },
                values: new object[,]
                {
                    { new Guid("21f04af8-8d28-4465-a098-da58fe86388c"), "John Smith" },
                    { new Guid("822e1f8a-d8d6-4adc-8740-9ca68cbf9f61"), "Jane Doe" }
                });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "AlbumId", "ArtistId", "ImageUrl", "Title" },
                values: new object[,]
                {
                    { new Guid("3eeb18da-97b2-44cb-a9f1-dfc5234e04f7"), new Guid("822e1f8a-d8d6-4adc-8740-9ca68cbf9f61"), "https://example.com/album2.jpg", "Album 2" },
                    { new Guid("a3084d34-c610-4408-aaee-0624117bc1cf"), new Guid("21f04af8-8d28-4465-a098-da58fe86388c"), "https://example.com/album1.jpg", "Album 1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "AlbumId",
                keyValue: new Guid("3eeb18da-97b2-44cb-a9f1-dfc5234e04f7"));

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "AlbumId",
                keyValue: new Guid("a3084d34-c610-4408-aaee-0624117bc1cf"));

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: new Guid("21f04af8-8d28-4465-a098-da58fe86388c"));

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: new Guid("822e1f8a-d8d6-4adc-8740-9ca68cbf9f61"));

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "ArtistId", "Name" },
                values: new object[,]
                {
                    { new Guid("b109cacf-33b4-4004-9b8a-2a030220e765"), "John Smith" },
                    { new Guid("ed1d9c53-2ea8-42c4-9596-728d4c0e839e"), "Jane Doe" }
                });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "AlbumId", "ArtistId", "ImageUrl", "Title" },
                values: new object[,]
                {
                    { new Guid("738ea536-f44c-45ab-bfc5-e856f483bad0"), new Guid("b109cacf-33b4-4004-9b8a-2a030220e765"), "https://example.com/album1.jpg", "Album 1" },
                    { new Guid("88326a7d-79d5-4c7f-a7e2-d0e04f1836ac"), new Guid("ed1d9c53-2ea8-42c4-9596-728d4c0e839e"), "https://example.com/album2.jpg", "Album 2" }
                });
        }
    }
}
