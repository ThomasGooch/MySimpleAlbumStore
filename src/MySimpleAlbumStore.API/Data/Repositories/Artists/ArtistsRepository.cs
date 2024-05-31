namespace MySimpleAlbumStore.API.Data.Repositories.Artists;

public class ArtistsRepository : IArtistsRepository
{
    private readonly AlbumStoreContext _context;

    public ArtistsRepository(AlbumStoreContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Artist>?> GetArtistsAsync()
    {
        return await _context.Artists.ToListAsync();
    }

    public async Task<Artist?> GetArtistByIdAsync(Guid id)
    {
        return await _context.Artists.FindAsync(id);
    }

    public async Task<Guid> AddArtistAsync(Artist artist)
    {
        _context.Artists.Add(artist);
        await _context.SaveChangesAsync();
        return artist.Id;
    }

    public async Task<bool> UpdateArtistAsync(Artist artist)
    {
        _context.Entry(artist).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteArtistAsync(Guid id)
    {
        var artist = await _context.Artists.FindAsync(id);

        if (artist == null)
        {
            return false;
        }

        _context.Artists.Remove(artist);
        await _context.SaveChangesAsync();

        return true;
    }
}

