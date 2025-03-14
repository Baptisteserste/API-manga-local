using MangaAPI.Models; // Importe les modèles nécessaires comme `AnimeModel`
using MangaAPI.Services; // Importe les services nécessaires comme `LocalStorageService`

namespace MangaAPI.Services;

// Service pour gérer les animes favoris (stockage local)
public class FavoritesService
{
    private const string StorageKey = "favorites"; // Clé utilisée pour identifier les favoris dans le stockage local
    private readonly LocalStorageService _localStorageService; // Service pour interagir avec le stockage local

    // Constructeur qui injecte LocalStorageService en dépendance (injection de dépendances)
    public FavoritesService(LocalStorageService localStorageService)
    {
        _localStorageService = localStorageService;
    }

    // Récupère tous les animes favoris depuis le stockage local
    public async Task<List<AnimeModel>> GetFavoritesAsync()
    {
        // Tente de récupérer la liste des favoris depuis le stockage local
        var favorites = await _localStorageService.GetItemAsync<List<AnimeModel>>(StorageKey);

        // Retourne la liste des favoris ou une liste vide s'il n'y a rien dans le stockage
        return favorites ?? new List<AnimeModel>();
    }

    // Ajoute un anime à la liste des favoris (uniquement s'il n'y est pas déjà)
    public async Task AddToFavoritesAsync(AnimeModel anime)
    {
        // Récupère la liste actuelle des favoris
        var favorites = await GetFavoritesAsync();

        // Vérifie que l'anime n'est pas déjà dans la liste en comparant son identifiant unique (Mal_id)
        if (!favorites.Any(a => a.Mal_id == anime.Mal_id))
        {
            // Ajoute l'anime à la liste des favoris
            favorites.Add(anime);

            // Met à jour la liste des favoris dans le stockage local
            await _localStorageService.SetItemAsync(StorageKey, favorites);
        }
    }

    // Supprime un anime de la liste des favoris
    public async Task RemoveFromFavoritesAsync(AnimeModel anime)
    {
        // Récupère la liste actuelle des favoris
        var favorites = await GetFavoritesAsync();

        // Supprime tous les éléments correspondant à l'identifiant de l'anime spécifié
        favorites.RemoveAll(a => a.Mal_id == anime.Mal_id);

        // Met à jour la liste des favoris dans le stockage local
        await _localStorageService.SetItemAsync(StorageKey, favorites);
    }
}