﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MySimpleAlbumStore.API.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MySimpleAlbumStore.API.Migrations
{
    [DbContext(typeof(AlbumStoreContext))]
    [Migration("20240531205024_SeedingWithOneToMany")]
    partial class SeedingWithOneToMany
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MySimpleAlbumStore.API.Models.Album", b =>
                {
                    b.Property<Guid>("AlbumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ArtistId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ArtistId1")
                        .HasColumnType("uuid");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("AlbumId");

                    b.HasIndex("ArtistId");

                    b.HasIndex("ArtistId1");

                    b.ToTable("Albums");

                    b.HasData(
                        new
                        {
                            AlbumId = new Guid("b3a4341d-43e8-4a5b-9c72-c02c15d34ef5"),
                            ImageUrl = "https://example.com/album1.jpg",
                            Title = "Album 1"
                        },
                        new
                        {
                            AlbumId = new Guid("c144538b-20e3-41fb-b467-3f09b1e5a0e0"),
                            ImageUrl = "https://example.com/album2.jpg",
                            Title = "Album 2"
                        });
                });

            modelBuilder.Entity("MySimpleAlbumStore.API.Models.Artist", b =>
                {
                    b.Property<Guid>("ArtistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ArtistId");

                    b.ToTable("Artists");

                    b.HasData(
                        new
                        {
                            ArtistId = new Guid("0c7a93e1-f31f-42f0-9d0c-9e3dbdf61dac"),
                            Name = "John Smith"
                        },
                        new
                        {
                            ArtistId = new Guid("e9f66cbc-ed05-406d-84ec-05ddff1fba40"),
                            Name = "Jane Doe"
                        });
                });

            modelBuilder.Entity("MySimpleAlbumStore.API.Models.Album", b =>
                {
                    b.HasOne("MySimpleAlbumStore.API.Models.Artist", null)
                        .WithMany("Albums")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MySimpleAlbumStore.API.Models.Artist", "Artist")
                        .WithMany()
                        .HasForeignKey("ArtistId1");

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("MySimpleAlbumStore.API.Models.Artist", b =>
                {
                    b.Navigation("Albums");
                });
#pragma warning restore 612, 618
        }
    }
}
