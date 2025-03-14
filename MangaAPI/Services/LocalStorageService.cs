using Microsoft.JSInterop; // Nécessaire pour interagir avec JavaScript via Blazor
using System.Text.Json; // Utilisé pour la sérialisation et la désérialisation des objets

namespace MangaAPI.Services;

// Service pour gérer le stockage local via JavaScript
public class LocalStorageService
{
    private readonly IJSRuntime _jsRuntime; // Instance de IJSRuntime utilisée pour exécuter du code JavaScript

    // Constructeur qui injecte la dépendance IJSRuntime
    public LocalStorageService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime; // Assignation de l'instance JS Runtime pour permettre la communication avec JavaScript
    }

    // Méthode pour enregistrer un élément dans le stockage local
    // <T> : Type générique pour permettre de stocker n'importe quel type de données sérialisables
    public async Task SetItemAsync<T>(string key, T value)
    {
        // Sérialise la valeur en JSON afin qu'elle puisse être stockée sous forme de chaîne dans le localStorage
        var json = JsonSerializer.Serialize(value);

        // Appelle la fonction JavaScript `localStorage.setItem` pour enregistrer l'élément
        await _jsRuntime.InvokeVoidAsync("localStorage.setItem", key, json);
    }

    // Méthode pour récupérer un élément depuis le stockage local
    // <T> : Type générique pour désérialiser les données au format attendu
    public async Task<T?> GetItemAsync<T>(string key)
    {
        // Exécute la commande JavaScript `localStorage.getItem` pour récupérer l'élément correspondant à la clé
        var json = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", key);

        // Si aucune donnée n'est trouvée (valeur null ou chaîne vide), retourne la valeur par défaut pour le type
        return string.IsNullOrEmpty(json)
            ? default
            : JsonSerializer.Deserialize<T>(json); // Désérialise le JSON pour recréer l'objet correspondant
    }

    // Méthode pour supprimer un élément du stockage local
    public async Task RemoveItemAsync(string key)
    {
        // Exécute la commande JavaScript `localStorage.removeItem` pour supprimer l'élément correspondant à la clé
        await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", key);
    }
}