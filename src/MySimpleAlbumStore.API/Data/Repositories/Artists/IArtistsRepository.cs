namespace MySimpleAlbumStore.API.Data.Repositories.Artists
{
    public interface IArtistsRepository
    {
        Task<IEnumerable<Artist>?> GetArtistsAsync();
        Task<Artist?> GetArtistByIdAsync(Guid id);
        Task<Guid> AddArtistAsync(Artist artist);
        Task<bool> UpdateArtistAsync(Artist artist);
        Task<bool> DeleteArtistAsync(Guid id);
    }
}
