using MySimpleAlbumStore.API.Data.Repositories.Albums;

namespace MySimpleAlbumStore.API.Albums.GetAlbumById;

public record GetAlbumByIdQuery(Guid AlbumId) : IQuery<GetAlbumByIdResult>;
public record GetAlbumByIdResult(Album? Album);
public class GetAlbumByIdQueryHandler(IAlbumsRepository albumsRepository) : IQueryHandler<GetAlbumByIdQuery, GetAlbumByIdResult>
{


    public async Task<GetAlbumByIdResult> Handle(GetAlbumByIdQuery query, CancellationToken cancellationToken)
    {
        var album = await albumsRepository.GetAlbumByIdAsync(query.AlbumId);

        if (album == null)
        {
            throw new NotFoundException($"Album with id {query.AlbumId} not found");
        }

        return new GetAlbumByIdResult(album);
    }
}

