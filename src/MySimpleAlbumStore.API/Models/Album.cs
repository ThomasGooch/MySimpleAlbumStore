namespace MySimpleAlbumStore.API.Models;

public class Album
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public Artist Artist { get; set; } = null!;
    public string? ImageUrl { get; set; }

}
