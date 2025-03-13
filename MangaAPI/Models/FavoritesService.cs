using MangaAPI.Models;
using MangaAPI.Services;

namespace MangaAPI.Services;

public class FavoritesService
{
    private const string StorageKey = "favorites";
    private readonly LocalStorageService _localStorageService;

    public FavoritesService(LocalStorageService localStorageService)
    {
        _localStorageService = localStorageService;
    }

    public async Task<List<AnimeModel>> GetFavoritesAsync()
    {
        var favorites = await _localStorageService.GetItemAsync<List<AnimeModel>>(StorageKey);
        return favorites ?? new List<AnimeModel>(); 
    }

    public async Task AddToFavoritesAsync(AnimeModel anime)
    {
        var favorites = await GetFavoritesAsync();

        if (!favorites.Any(a => a.Mal_id == anime.Mal_id))
        {
            favorites.Add(anime);
            await _localStorageService.SetItemAsync(StorageKey, favorites); 
        }
    }

    public async Task RemoveFromFavoritesAsync(AnimeModel anime)
    {
        var favorites = await GetFavoritesAsync();
        favorites.RemoveAll(a => a.Mal_id == anime.Mal_id);

        await _localStorageService.SetItemAsync(StorageKey, favorites); 
    }
}