

namespace MySimpleAlbumStore.API.Artists.GetArtists;

public record GetArtistsQuery() : IQuery<GetArtistsResult>;
public record GetArtistsResult(List<Artist> Artists);

public class GetArtistsCommandHandler : IQueryHandler<GetArtistsQuery, GetArtistsResult>
{
    public async Task<GetArtistsResult> Handle(GetArtistsQuery query, CancellationToken cancellationToken)
    {
        return await Task.FromResult(new GetArtistsResult(new List<Artist>
        {
            new() { Id = Guid.NewGuid(), Name = "The Beatles" },
            new() { Id = Guid.NewGuid(), Name = "The Rolling Stones" },
            new() { Id = Guid.NewGuid(), Name = "The Who" },
            new() { Id = Guid.NewGuid(), Name = "The Kinks" },
            new() { Id = Guid.NewGuid(), Name = "The Doors"}
        }));
    }
}
