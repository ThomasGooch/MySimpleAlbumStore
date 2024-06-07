namespace MySimpleAlbumStore.API.Artists.UpdateArtist
{
    public record UpdateArtistRequest(Guid ArtistId, string Name, ICollection<Album>? Albums);
    public record UpdateArtistResponse(bool Success);
    public class UpdateArtistEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("artists", async (UpdateArtistRequest request, ISender sender) =>
            {
                var result = await sender.Send(new UpdateArtistCommand(request.ArtistId, request.Name, request.Albums));
                var response = result.Adapt<UpdateArtistResponse>();
                return Results.Ok(response);
            })
            .WithName("UpdateArtist")
            .Produces<UpdateArtistResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Update Artist")
            .WithDescription("Update Artist");
        }
    }
}
