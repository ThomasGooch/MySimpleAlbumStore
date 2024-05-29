namespace MySimpleAlbumStore.API.Models
{
    public class Album
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public List<Artist> Artist { get; set; } = [];
        public string ImageUrl { get; set; } = string.Empty;

    }
}
