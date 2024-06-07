namespace MySimpleAlbumStore.API.Artists.GetArtistById;

public record GetArtistByIdQuery(Guid ArtistId) : IQuery<GetArtistByIdResult>;
public record GetArtistByIdResult(Artist Artist);
public class GetArtistByIdQueryHandler(IArtistsRepository artistsRepository) : IQueryHandler<GetArtistByIdQuery, GetArtistByIdResult>
{
    public async Task<GetArtistByIdResult> Handle(GetArtistByIdQuery request, CancellationToken cancellationToken)
    {
        var artist = await artistsRepository.GetArtistByIdAsync(request.ArtistId);

        return artist is null ? throw new NotFoundException($"Artists not found with id: {request.ArtistId}") : new GetArtistByIdResult(artist);
    }
}

