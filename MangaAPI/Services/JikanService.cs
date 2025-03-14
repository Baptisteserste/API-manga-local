using System.Net.Http.Json; // Permet l'utilisation de méthodes utiles comme `GetFromJsonAsync` pour les requêtes HTTP
using MangaAPI.Models; // Importation des modèles nécessaires, comme `AnimeModel`

namespace MangaAPI.Services;

// Service pour interagir avec l'API Jikan
public class JikanService
{
    private readonly HttpClient _httpClient; // Client HTTP utilisé pour faire des appels externes à l'API Jikan

    // Constructeur du service JikanService. Le HttpClient est injecté .
    public JikanService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Méthode principale pour récupérer une liste d'animes depuis l'API Jikan
    public async Task<List<AnimeModel>> GetAnimesAsync()
    {
        // Effectue une requête GET sur l'API Jikan pour obtenir des données des animes au format JSON
        var response = await _httpClient.GetFromJsonAsync<MangaAPIResponse>("https://api.jikan.moe/v4/anime");

        // Retourne la liste de données des animes récupérés ou une liste vide si aucune donnée n'est disponible
        return response?.Data ?? new List<AnimeModel>();
    }

    // Classe interne pour représenter la structure de la réponse spécifique de l'API Jikan
    private class MangaAPIResponse
    {
        // Liste d'animes contenue dans la réponse API
        public List<AnimeModel> Data { get; set; } = new(); // Initialise une liste vide par défaut
    }
}