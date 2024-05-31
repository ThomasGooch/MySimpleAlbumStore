namespace MySimpleAlbumStore.API.Data
{
    public class AlbumStoreContext(DbContextOptions<AlbumStoreContext> options) : DbContext(options)
    {
        public DbSet<Artist> Artists { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>().HasData(
                 new Artist { Id = Guid.NewGuid(), Name = "Metallica" },
                 new Artist { Id = Guid.NewGuid(), Name = "Iron Maiden" },
                 new Artist { Id = Guid.NewGuid(), Name = "Megadeth" }
            );
        }
    }
}
