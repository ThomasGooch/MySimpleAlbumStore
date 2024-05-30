
using Mapster;

namespace MySimpleAlbumStore.API.Artists.GetArtists
{

    // public record GetArtistsRequest();
    public record GetArtistsResponse(List<Artist> Artists);

    public class GetArtistsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/artists", async (ISender sender, CancellationToken cancellationToken) =>
            {
                var result = await sender.Send(new GetArtistsQuery(), cancellationToken);
                var response = result.Adapt<GetArtistsResponse>();
                return Results.Ok(response);
            })
            .WithName("GetArtists")
            .Produces<GetArtistsResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Artists")
            .WithDescription("Get Artists");
        }
    }
}
