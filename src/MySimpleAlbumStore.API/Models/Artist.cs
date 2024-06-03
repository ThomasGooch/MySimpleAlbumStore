using System.Collections.ObjectModel;

namespace MySimpleAlbumStore.API.Models;

public class Artist
{
    public Guid ArtistId { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Album>? Albums { get; set; } = new Collection<Album>();
}