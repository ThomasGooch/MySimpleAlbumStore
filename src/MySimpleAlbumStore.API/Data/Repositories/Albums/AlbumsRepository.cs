
namespace MySimpleAlbumStore.API.Data.Repositories.Albums;

public class AlbumsRepository : IAlbumsRepository
{
    private readonly AlbumStoreContext _context;

    public AlbumsRepository(AlbumStoreContext context)
    {
        _context = context;
    }
    public async Task<Guid> AddAlbumAsync(Album album)
    {
        await _context.Albums.AddAsync(album);
        await _context.SaveChangesAsync();
        return album.AlbumId;
    }

    public async Task<bool> DeleteAlbumAsync(Guid id)
    {
        var albumToDelete = await _context.Albums.FindAsync(id);
        if (albumToDelete is null)
        {
            return false;
        }
        _context.Albums.Remove(albumToDelete);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Album?> GetAlbumByIdAsync(Guid id)
    {
        return await _context.Albums.FindAsync(id);
    }

    public async Task<IEnumerable<Album>?> GetAlbumsAsync()
    {
        return await _context.Albums.ToListAsync();
    }

    public async Task<bool> UpdateAlbumAsync(Album album)
    {
        _context.Entry(album).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return true;
    }
}
