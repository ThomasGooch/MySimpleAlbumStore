
using MySimpleAlbumStore.API.Data.Repositories.Albums;

namespace MySimpleAlbumStore.API.Albums.UpdateAlbum;

public record UpdateAlbumCommand(Guid AlbumId, string Title, Guid? ArtistId, string? ImageUrl) : ICommand<UpdateAlbumResult>;
public record UpdateAlbumResult(bool Success);

public class UpdateAlbumCommandHandler(IAlbumsRepository albumsRepository) : ICommandHandler<UpdateAlbumCommand, UpdateAlbumResult>
{
    public async Task<UpdateAlbumResult> Handle(UpdateAlbumCommand command, CancellationToken cancellationToken)
    {
        var album = await albumsRepository.GetAlbumByIdAsync(command.AlbumId);

        if (album is null)
        {
            throw new NotFoundException("Album", command.AlbumId);
        }

        album.Title = command.Title;
        album.ArtistId = command.ArtistId;
        album.ImageUrl = command.ImageUrl;

        var result = await albumsRepository.UpdateAlbumAsync(album);

        return new UpdateAlbumResult(result);
    }
}
