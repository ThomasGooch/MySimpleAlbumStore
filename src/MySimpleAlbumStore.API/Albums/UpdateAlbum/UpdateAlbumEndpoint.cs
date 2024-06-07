namespace MySimpleAlbumStore.API.Albums.UpdateAlbum
{
    public record UpdateAlbumRequest(Guid AlbumId, string Title, Guid? ArtistId, string? ImageUrl);
    public record UpdateAlbumResponse(bool Success);
    public class UpdateAlbumEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/albums", async (UpdateAlbumRequest request, ISender sender, CancellationToken cancellationToken) =>
            {
                var albumCommand = request.Adapt<UpdateAlbumCommand>();
                var result = await sender.Send(albumCommand, cancellationToken);
                var response = result.Adapt<UpdateAlbumResponse>();
                return Results.Ok(response);
            })
                .WithName("UpdateAlbum")
                .Produces<UpdateAlbumResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .ProducesProblem(StatusCodes.Status404NotFound)
                .WithSummary("Update Album")
                .WithDescription("Update Album");
        }
    }
}
