namespace MangaAPI.Models;

// Modèle principal représentant un anime
public class AnimeModel
{
    // Identifiant unique de l'anime (issu de MyAnimeList)
    public int Mal_id { get; set; }

    // Le titre de l'anime
    public string Title { get; set; }

    // Résumé ou description de l'anime (peut être nullable)
    public string? Synopsis { get; set; }

    // Images associées à l'anime
    public Images Images { get; set; } = new(); // Initialise un objet `Images` par défaut pour éviter les nulls
}

// Classe représentant les différentes catégories d'images
public class Images
{
    // Image au format JPG
    public ImageType Jpg { get; set; } = new(); // Initialise un objet `ImageType` par défaut
}

// Classe représentant les informations sur une image spécifique
public class ImageType
{
    // URL de l'image
    public string Image_url { get; set; } // Contient le lien de l'image
}