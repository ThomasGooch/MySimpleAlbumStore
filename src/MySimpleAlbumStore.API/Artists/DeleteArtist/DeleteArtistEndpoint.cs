
namespace MySimpleAlbumStore.API.Artists.DeleteArtist
{
    public record DeleteArtistRequest(Guid ArtistId);
    public record DeleteArtistResponse(bool Success);

    public class DeleteArtistEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("artists/{artistId}", async (Guid artistId, ISender sender) =>
            {
                var result = await sender.Send(new DeleteArtistCommand(artistId));
                var response = result.Adapt<DeleteArtistResponse>();
                return Results.Ok(response);

            });
        }
    }
}
