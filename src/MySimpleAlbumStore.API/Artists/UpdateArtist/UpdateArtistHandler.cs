﻿namespace MySimpleAlbumStore.API.Artists.UpdateArtist;

public record UpdateArtistCommand(Guid ArtistId, string Name, ICollection<Album>? Albums) : ICommand<UpdateArtistResult>;
public record UpdateArtistResult(bool Success);
public class UpdateArtistCommandValidator : AbstractValidator<UpdateArtistCommand>
{
    public UpdateArtistCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
    }
}
public class UpdateArtistCommandHandler(IArtistsRepository artistsRepository) : IRequestHandler<UpdateArtistCommand, UpdateArtistResult>
{
    public async Task<UpdateArtistResult> Handle(UpdateArtistCommand request, CancellationToken cancellationToken)
    {
        var artistToUpdate = await artistsRepository.GetArtistByIdAsync(request.ArtistId);
        if (artistToUpdate == null)
        {
            throw new NotFoundException($"Artist not found with id: {request.ArtistId}");
        }

        artistToUpdate.Name = request.Name;
        artistToUpdate.Albums = request.Albums;

        return new UpdateArtistResult(await artistsRepository.UpdateArtistAsync(artistToUpdate));

    }
}
