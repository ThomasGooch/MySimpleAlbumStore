using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MySimpleAlbumStore.API.Migrations
{
    /// <inheritdoc />
    public partial class seedingArtistsToAlbums : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Artists_ArtistId1",
                table: "Albums");

            migrationBuilder.DropIndex(
                name: "IX_Albums_ArtistId1",
                table: "Albums");

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

            migrationBuilder.DropColumn(
                name: "ArtistId1",
                table: "Albums");

            migrationBuilder.AlterColumn<Guid>(
                name: "ArtistId",
                table: "Albums",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<Guid>(
                name: "ArtistId",
                table: "Albums",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "ArtistId1",
                table: "Albums",
                type: "uuid",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Albums_ArtistId1",
                table: "Albums",
                column: "ArtistId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Artists_ArtistId1",
                table: "Albums",
                column: "ArtistId1",
                principalTable: "Artists",
                principalColumn: "ArtistId");
        }
    }
}
