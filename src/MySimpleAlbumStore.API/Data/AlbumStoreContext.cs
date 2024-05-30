using Microsoft.EntityFrameworkCore;

namespace MySimpleAlbumStore.API.Data
{
    public class AlbumStoreContext(DbContextOptions<AlbumStoreContext> options) : DbContext(options)
    {
        public DbSet<Artist> Artists { get; set; }

    }
}
