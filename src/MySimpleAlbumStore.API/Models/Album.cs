namespace MySimpleAlbumStore.API.Models;

public class Album
{
    public Guid AlbumId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public Guid ArtistId { get; set; }
    public Artist? Artist { get; set; }
}
