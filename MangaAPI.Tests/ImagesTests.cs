using Xunit; // Importation de la bibliothèque de tests unitaires XUnit
using MangaAPI.Models; // Importe les modèles `Images`, `ImageType` et `AnimeModel`

// Namespace pour regrouper tous les tests liés à MangaAPI
namespace MangaAPI.Tests
{
    public class ImagesTests
    {
        // Test 1 : Vérifie si la classe `Images` est bien initialisée avec des valeurs par défaut
        [Fact]
        public void Test1()
        {
            // Arrange & Act : Création d'une instance de `Images`
            var images = new Images();

            // Assert : Vérifie que les propriétés de l'instance ont les valeurs attendues par défaut
            Assert.NotNull(images.Jpg); // La propriété Jpg ne doit pas être null (doit être un objet initialisé)
            Assert.Null(images.Jpg.Image_url); // La propriété Image_url doit initialement être null
        }

        // Test 2 : Vérifie qu’il est possible d'assigner une instance de `ImageType` à la propriété `Jpg` de `Images`
        [Fact]
        public void Test2()
        {
            // Arrange : Crée une instance de `Images` et une instance de `ImageType`
            var images = new Images();
            var newImageType = new ImageType { Image_url = "http://example.com/image.jpg" };

            // Act : Assigne l’objet `ImageType` à la propriété `Jpg`
            images.Jpg = newImageType;

            // Assert : Vérifie que la propriété `Jpg` a été modifiée correctement
            Assert.NotNull(images.Jpg); // Vérifie que la propriété Jpg est bien assignée
            Assert.Equal("http://example.com/image.jpg",
                images.Jpg.Image_url); // Vérifie que l'URL correspond à l’assignation
        }

        // Test 3 : Vérifie que la propriété `Image_url` de la classe `ImageType` peut être assignée directement
        [Fact]
        public void test3()
        {
            // Arrange : Crée une nouvelle instance de `ImageType`
            var imgType = new ImageType();

            // Act : Assigne une URL à la propriété `Image_url`
            imgType.Image_url = "http://example.com/another-image.jpg";

            // Assert : Vérifie que la propriété `Image_url` contient la valeur assignée
            Assert.Equal("http://example.com/another-image.jpg", imgType.Image_url);
        }

        // Test 4 : Vérifie que la classe `Images` fonctionne correctement avec `AnimeModel`
        [Fact]
        public void test4()
        {
            // Arrange : Crée une instance d'AnimeModel avec une image contenant `Image_url`
            var anime = new AnimeModel
            {
                Title = "Naruto",
                Images = new Images
                {
                    Jpg = new ImageType { Image_url = "http://example.com/naruto.jpg" }
                }
            };

            // Act : Accède à l'URL de l'image via les propriétés de `AnimeModel`
            var imageUrl = anime.Images.Jpg.Image_url;

            // Assert : Vérifie que l’URL correspond aux données initiales
            Assert.Equal("http://example.com/naruto.jpg", imageUrl);
        }
    }
}