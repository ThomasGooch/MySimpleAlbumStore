using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MySimpleAlbumStore.API.Migrations
{
    /// <inheritdoc />
    public partial class SetupOneToManyAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Artists_ArtistId1",
                table: "Albums");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Artists",
                newName: "ArtistId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Albums",
                newName: "AlbumId");

            migrationBuilder.AlterColumn<Guid>(
                name: "ArtistId1",
                table: "Albums",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "ArtistId",
                table: "Albums",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Artists_ArtistId1",
                table: "Albums",
                column: "ArtistId1",
                principalTable: "Artists",
                principalColumn: "ArtistId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Artists_ArtistId1",
                table: "Albums");

            migrationBuilder.RenameColumn(
                name: "ArtistId",
                table: "Artists",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AlbumId",
                table: "Albums",
                newName: "Id");

            migrationBuilder.AlterColumn<Guid>(
                name: "ArtistId1",
                table: "Albums",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ArtistId",
                table: "Albums",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Artists_ArtistId1",
                table: "Albums",
                column: "ArtistId1",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
