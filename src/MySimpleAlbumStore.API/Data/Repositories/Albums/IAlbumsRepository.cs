namespace MySimpleAlbumStore.API.Data.Repositories.Albums
{
    public interface IAlbumsRepository
    {
        Task<IEnumerable<Album>?> GetAlbumsAsync();
        Task<Album?> GetAlbumByIdAsync(Guid id);
        Task<Guid> AddAlbumAsync(Album album);
        Task<bool> UpdateAlbumAsync(Album album);
        Task<bool> DeleteAlbumAsync(Guid id);
    }
}
