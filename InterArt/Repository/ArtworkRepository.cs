using InterArt.Models;
using System.Text.Json;

namespace InterArt.Repository
{
    public class ArtworkRepository : IArtworkRepository
    {
        public  List<Artwork> Artworks { get; set; } = new List<Artwork>();

        public  List<Artwork> LoadArtworks()
        {
            var artworks = new List<Artwork>();
            string[] file = File.ReadAllLines("./Resources/allArtworks.jsonl");
            foreach(string line in file)
            {
                var artwork = JsonSerializer.Deserialize<Artwork>(line);
                artworks.Add(artwork);
            }
            
            return artworks.Take(10).ToList();
        }
    }
    public interface IArtworkRepository
    {
        public List<Artwork> LoadArtworks();
    }

}
