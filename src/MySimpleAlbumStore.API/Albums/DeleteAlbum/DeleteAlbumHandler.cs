
using MySimpleAlbumStore.API.Data.Repositories.Albums;

namespace MySimpleAlbumStore.API.Albums.DeleteAlbum
{
    public record DeleteAlbumCommand(Guid AlbumId) : ICommand<DeleteAlbumResult>;
    public record DeleteAlbumResult(bool Success);
    public class DeleteAlbumHandler(IAlbumsRepository albumsRepository) : ICommandHandler<DeleteAlbumCommand, DeleteAlbumResult>
    {
        public async Task<DeleteAlbumResult> Handle(DeleteAlbumCommand command, CancellationToken cancellationToken)
        {
            var albumToDelete = await albumsRepository.GetAlbumByIdAsync(command.AlbumId);

            if (albumToDelete == null)
            {
                throw new NotFoundException("album", command.AlbumId);
            }

            var result = await albumsRepository.DeleteAlbumAsync(albumToDelete.AlbumId);

            return new DeleteAlbumResult(result);
        }
    }
}
