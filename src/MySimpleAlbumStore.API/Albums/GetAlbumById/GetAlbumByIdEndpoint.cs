namespace MySimpleAlbumStore.API.Albums.GetAlbumById;

public record GetAlbumByIdRequest(Guid AlbumId);
public record GetAlbumByIdResponse(Album Album);

public class GetAlbumByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/albums/{albumId}", async (Guid albumId, ISender sender) =>
        {

            var result = await sender.Send(new GetAlbumByIdQuery(albumId));
            var response = result.Adapt<GetAlbumByIdResponse>();
            return Results.Ok(response);

        })
            .WithName("GetAlbumById")
            .Produces<GetAlbumByIdResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get Album By Id")
            .WithDescription("Get Album By Id");
    }
}
