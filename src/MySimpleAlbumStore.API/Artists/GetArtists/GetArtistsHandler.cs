

using Microsoft.EntityFrameworkCore;
using MySimpleAlbumStore.API.Data;

namespace MySimpleAlbumStore.API.Artists.GetArtists;

public record GetArtistsQuery() : IQuery<GetArtistsResult>;
public record GetArtistsResult(List<Artist> Artists);

public class GetArtistsCommandHandler(AlbumStoreContext context) : IQueryHandler<GetArtistsQuery, GetArtistsResult>
{
    public async Task<GetArtistsResult> Handle(GetArtistsQuery query, CancellationToken cancellationToken)
    {
        var artists = await context.Set<Artist>().ToListAsync(cancellationToken);
        return new GetArtistsResult(artists);
    }
}
