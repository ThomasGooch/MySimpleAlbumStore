


namespace MySimpleAlbumStore.API.Artists.AddArtist;

public record AddArtistCommand(string Name, ICollection<Album>? Albums) : ICommand<AddArtistResult>;
public record AddArtistResult(Guid Id);

public class AddArtistCommandValidator : AbstractValidator<AddArtistCommand>
{
    public AddArtistCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
    }
}

public class AddArtistCommandHandler(IArtistsRepository artistsRepository) : ICommandHandler<AddArtistCommand, AddArtistResult>
{
    public async Task<AddArtistResult> Handle(AddArtistCommand command, CancellationToken cancellationToken)
    {
        var artistToAdd = new Artist() { Name = command.Name, Albums = command.Albums };
        var result = await artistsRepository.AddArtistAsync(artistToAdd);
        return new AddArtistResult(result);
    }
}
