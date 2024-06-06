namespace MySimpleAlbumStore.API.Artists.DeleteArtist;

public record DeleteArtistCommand(Guid ArtistId) : IRequest<DeleteArtistResult>;
public record DeleteArtistResult(bool Success);
public class DeleteArtistHandler(IArtistsRepository artistsRepository) : IRequestHandler<DeleteArtistCommand, DeleteArtistResult>
{




    public async Task<DeleteArtistResult> Handle(DeleteArtistCommand request, CancellationToken cancellationToken)
    {
        var artist = await artistsRepository.GetArtistByIdAsync(request.ArtistId);

        if (artist == null)
        {
            throw new NotFoundException($"Artist not found with id: {request.ArtistId}");
        }

        await artistsRepository.DeleteArtistAsync(artist.ArtistId);

        return new DeleteArtistResult(true);
    }
}

