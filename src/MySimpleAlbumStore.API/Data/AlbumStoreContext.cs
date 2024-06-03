namespace MySimpleAlbumStore.API.Data
{
    public class AlbumStoreContext(DbContextOptions<AlbumStoreContext> options) : DbContext(options)
    {


        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>()
              .HasMany(c => c.Albums)
              .WithOne(e => e.Artist);

            var artistId1 = Guid.NewGuid();
            var artistId2 = Guid.NewGuid();



            modelBuilder.Entity<Artist>().HasData(
                new Artist { ArtistId = artistId1, Name = "John Smith" },
                new Artist { ArtistId = artistId2, Name = "Jane Doe" }
            );


            modelBuilder.Entity<Album>().HasData(
                new Album { AlbumId = Guid.NewGuid(), Title = "Album 1", ImageUrl = "https://example.com/album1.jpg", ArtistId = artistId1 },
                new Album { AlbumId = Guid.NewGuid(), Title = "Album 2", ImageUrl = "https://example.com/album2.jpg", ArtistId = artistId2 }
            );

        }
    }
}
