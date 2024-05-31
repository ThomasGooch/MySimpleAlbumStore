
namespace MySimpleAlbumStore.API.Artists.AddArtist;

public record AddArtistCommand(string Name) : ICommand<AddArtistResult>;
public record AddArtistResult(Guid Id);

public class AddArtistCommandHandler(IArtistsRepository artistsRepository) : ICommandHandler<AddArtistCommand, AddArtistResult>
{
    public async Task<AddArtistResult> Handle(AddArtistCommand command, CancellationToken cancellationToken)
    {
        var artistToAdd = new Artist() { Name = command.Name };
        var result = await artistsRepository.AddArtistAsync(artistToAdd);
        return new AddArtistResult(result);
    }
}
