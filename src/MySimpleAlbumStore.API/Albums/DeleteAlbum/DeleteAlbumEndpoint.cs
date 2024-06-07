namespace MySimpleAlbumStore.API.Albums.DeleteAlbum;

public record DeleteAlbumRequest(Guid AlbumId);
public record DeleteAlbumResponse(bool Success);

public class DeleteAlbumEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/albums/{albumId}", async (Guid albumId, ISender sender, CancellationToken cancellationToken) =>
        {
            var result = await sender.Send(new DeleteAlbumCommand(albumId), cancellationToken);
            var response = result.Adapt<DeleteAlbumResponse>();
            return Results.Ok(response);
        })
            .WithName("DeleteAlbum")
            .Produces<DeleteAlbumResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Delete Album")
            .WithDescription("Delete Album");
    }
}
