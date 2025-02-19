using InterArt.Models;
using System.Text.Json;

namespace InterArt.Repository
{
    public class ArtworkRepository : IArtworkRepository
    {
        public static List<Artwork> Artworks { get; set; } = new List<Artwork>();

        public static void GetArtworks()
        {
            string[] file = File.ReadAllLines("./Resources/allArtworks.jsonl");
            foreach(string line in file)
            {
                var artwork = JsonSerializer.Deserialize<Artwork>(line);
                Artworks.Add(artwork);
            }
            var firstTenArts = Artworks.Take(10).ToList();
            foreach(var artwork in firstTenArts)
            {
                Console.WriteLine(artwork.Title);
            }
        }
    }
    public interface IArtworkRepository
    {
    }

}
