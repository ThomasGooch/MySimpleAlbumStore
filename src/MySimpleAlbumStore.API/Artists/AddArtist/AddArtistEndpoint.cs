



namespace MySimpleAlbumStore.API.Artists.AddArtist;

public record AddArtistRequest(string Name);
public record AddArtistResponse(Guid Id);

public class AddArtistEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/artists", async (AddArtistRequest request, ISender sender, CancellationToken cancellationToken) =>
        {

            var result = await sender.Send(new AddArtistCommand(request.Name), cancellationToken);
            var response = result.Adapt<AddArtistResponse>();
            return Results.Ok(response);


        }).WithName("AddArtists")
            .Produces<AddArtistResponse>(StatusCodes.Status200OK)
            .WithSummary("Add Artist")
            .WithDescription("Add Artist");
    }
}
