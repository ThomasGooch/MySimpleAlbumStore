namespace MySimpleAlbumStore.API.Albums.GetAlbums
{
    //public record GetAlbumsRequest();
    public record GetAlbumsResponse(IEnumerable<Album>? Albums);
    public class GetAlbumsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/albums", async (ISender sender) =>
            {
                var result = await sender.Send(new GetAlbumsQuery());
                var response = result.Adapt<GetAlbumsResponse>();
                return Results.Ok(response);
            }).WithName("GetAlbums")
            .Produces<GetAlbumsResponse>(StatusCodes.Status200OK)
            .WithSummary("Get Albums")
            .WithDescription("Get Albums");
        }
    }
}
