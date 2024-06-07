
using MySimpleAlbumStore.API.Data.Repositories.Albums;

namespace MySimpleAlbumStore.API.Albums.GetAlbums
{
    public record GetAlbumsQuery : IQuery<GetAlbumsResult>;
    public record GetAlbumsResult(IEnumerable<Album>? Albums);
    public class GetAlbumsQueryHandler(IAlbumsRepository albumsRepository) : IQueryHandler<GetAlbumsQuery, GetAlbumsResult>
    {
        public async Task<GetAlbumsResult> Handle(GetAlbumsQuery request, CancellationToken cancellationToken)
        {
            var result = await albumsRepository.GetAlbumsAsync();

            return new GetAlbumsResult(result);

        }
    }
}
