using FluentAssertions;
using MySimpleAlbumStore.API.Artists.GetArtists;

namespace MySimpleAlbumStore.API.Tests
{
    public class GetArtistsHandlerTests
    {
        [Fact]
        public async Task GetArtists_Handle_WhenGivenGetArtistsQuery_ReturnsListOfArtists()
        {
            var query = new GetArtistsQuery();
            var sut = new GetArtistsCommandHandler();
            var result = await sut.Handle(query, CancellationToken.None);
            result.Should().BeAssignableTo<GetArtistsResult>();
            result.Artists.Should().HaveCount(5);

        }
    }
}