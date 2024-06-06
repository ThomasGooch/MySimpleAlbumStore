
namespace MySimpleAlbumStore.API.Artists.GetArtistById;

//public record GetArtistByIdRequest(Guid ArtistId);
public record GetArtistByIdResponse(Artist Artist);

public class GetArtistByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("artists/{artistId}", async (Guid artistId, ISender sender) =>
        {
            var result = await sender.Send(new GetArtistByIdQuery(artistId));
            var response = result.Adapt<GetArtistByIdResponse>();
            return Results.Ok(response);
        });
    }
}

