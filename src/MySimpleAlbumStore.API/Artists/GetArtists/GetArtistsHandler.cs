


namespace MySimpleAlbumStore.API.Artists.GetArtists;

public record GetArtistsQuery() : IQuery<GetArtistsResult>;
public record GetArtistsResult(IEnumerable<Artist>? Artists);

public class GetArtistsCommandHandler(IArtistsRepository artistsRepository) : IQueryHandler<GetArtistsQuery, GetArtistsResult>
{
    public async Task<GetArtistsResult> Handle(GetArtistsQuery query, CancellationToken cancellationToken)
    {
        var artists = await artistsRepository.GetArtistsAsync();

        return new GetArtistsResult(artists);
    }
}
