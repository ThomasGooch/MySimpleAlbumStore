namespace MySimpleAlbumStore.API.Data
{
    public class AlbumStoreContext(DbContextOptions<AlbumStoreContext> options) : DbContext(options)
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>().HasMany(a => a.Albums).WithOne().OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Artist>().HasData(
                new Artist { ArtistId = Guid.NewGuid(), Name = "John Smith" },
                new Artist { ArtistId = Guid.NewGuid(), Name = "Jane Doe" }
            );

            modelBuilder.Entity<Album>().HasData(
                new Album { AlbumId = Guid.NewGuid(), Title = "Album 1", ImageUrl = "https://example.com/album1.jpg" },
                new Album { AlbumId = Guid.NewGuid(), Title = "Album 2", ImageUrl = "https://example.com/album2.jpg" }
            );

        }
    }
}
