using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MySimpleAlbumStore.API.Migrations
{
    /// <inheritdoc />
    public partial class SetupOneToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    ArtistId1 = table.Column<Guid>(type: "uuid", nullable: false),
                    ArtistId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Albums_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Albums_Artists_ArtistId1",
                        column: x => x.ArtistId1,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_ArtistId",
                table: "Albums",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Albums_ArtistId1",
                table: "Albums",
                column: "ArtistId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Albums");

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
    }
}
