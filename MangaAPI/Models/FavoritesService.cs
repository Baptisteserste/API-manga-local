using MangaAPI.Models;

namespace MangaAPI.Services;

public static class FavoritesService
{
    private static readonly List<AnimeModel> Favorites = new();

    public static IReadOnlyList<AnimeModel> GetFavorites() => Favorites.AsReadOnly();

    public static void AddToFavorites(AnimeModel anime)
    {
        if (!Favorites.Any(a => a.Mal_id == anime.Mal_id))
        {
            Favorites.Add(anime);
        }
    }

    public static void RemoveFromFavorites(AnimeModel anime)
    {
        Favorites.RemoveAll(a => a.Mal_id == anime.Mal_id);
    }
}