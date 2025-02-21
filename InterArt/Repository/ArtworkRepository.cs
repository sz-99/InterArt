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
    }
    public interface IArtworkRepository
    {
        public List<Artwork> LoadArtworks();
    }

}
