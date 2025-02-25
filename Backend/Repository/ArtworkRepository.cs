using InterArt.Models;
using InterArt_Backend.DBContext;
using System.Text.Json;

namespace InterArt.Repository
{
    public class ArtworkRepository : IArtworkRepository
    {
        private ArtworkDbContext _db;

        public ArtworkRepository(ArtworkDbContext artworkDbContext)
        {
            _db = artworkDbContext;
        }

        public  List<Artwork> LoadArtworks()
        {
            return _db.Artworks.ToList();

        }
        public Artwork FetchArtworkById(int id)
        {
            var artwork = _db.Artworks.First(x => x.Id == id);
            if (artwork == null) return null;
            return artwork;
        }

        public Artwork FetchRandomArtwork()
        {

            var count = _db.Artworks.Count();
            if (count == 0) return null;

            var randomIndex = new Random().Next(0, count);
            return _db.Artworks.Skip(randomIndex).FirstOrDefault();
        }
    }
    public interface IArtworkRepository
    {
        Artwork FetchArtworkById(int id);
        Artwork FetchRandomArtwork();
        public List<Artwork> LoadArtworks();
    }

}
