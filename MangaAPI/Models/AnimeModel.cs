namespace MangaAPI.Models;

public class AnimeModel
{
    public int Mal_id { get; set; }
    public string Title { get; set; }
    public string? Synopsis { get; set; }
    public Images Images { get; set; } = new();
}

public class Images
{
    public ImageType Jpg { get; set; } = new();
}

public class ImageType
{
    public string Image_url { get; set; }
}