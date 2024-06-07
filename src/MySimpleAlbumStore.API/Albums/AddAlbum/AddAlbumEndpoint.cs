namespace MySimpleAlbumStore.API.Albums.AddAlbum
{
    public record AddAlbumRequest(string Title, string? ImageUrl, Guid? ArtistId);
    public record AddAlbumResponse(Guid AlbumId);
    public class AddAlbumEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/albums", async (AddAlbumRequest request, ISender sender, CancellationToken cancellationToken) =>
            {
                var albumToAdd = request.Adapt<AddAlbumCommand>();
                var result = await sender.Send(albumToAdd, cancellationToken);
                var response = result.Adapt<AddAlbumResponse>();
                return Results.Ok(response);
            })
                .WithName("AddAlbum")
                .Produces<AddAlbumResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Add Album")
                .WithDescription("Add Album");
        }
    }
}
