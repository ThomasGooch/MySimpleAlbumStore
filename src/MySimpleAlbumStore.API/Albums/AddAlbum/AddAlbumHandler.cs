
using MySimpleAlbumStore.API.Data.Repositories.Albums;

namespace MySimpleAlbumStore.API.Albums.AddAlbum
{
    public record AddAlbumCommand(string Title, string? ImageUrl, Guid? ArtistId) : ICommand<AddAlbumResult>;
    public record AddAlbumResult(Guid AlbumId);

    public class AddAlbumCommandValidator : AbstractValidator<AddAlbumCommand>
    {
        public AddAlbumCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(50);
        }
    }
    public class AddAlbumCommandHandler(IAlbumsRepository albumsRepository) : ICommandHandler<AddAlbumCommand, AddAlbumResult>
    {
        public async Task<AddAlbumResult> Handle(AddAlbumCommand command, CancellationToken cancellationToken)
        {
            var albumToAdd = new Album() { Title = command.Title, ImageUrl = command.ImageUrl, ArtistId = command.ArtistId };
            var result = await albumsRepository.AddAlbumAsync(albumToAdd);
            return new AddAlbumResult(result);
        }
    }
}
