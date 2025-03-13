using System.Net.Http.Json;
using MangaAPI.Models;

namespace MangaAPI.Services;

public class JikanService
{
    private readonly HttpClient _httpClient;

    public JikanService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<AnimeModel>> GetAnimesAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<MangaAPIResponse>("https://api.jikan.moe/v4/anime");
        return response?.Data ?? new List<AnimeModel>();
    }
    
    private class MangaAPIResponse
    {
        public List<AnimeModel> Data { get; set; } = new();
    }
}