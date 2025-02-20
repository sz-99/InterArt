using InterArt.Models;
using InterArt_Backend.DBContext;
using System.Text.Json;

namespace InterArt.Repository
{
    public class ArtworkRepository : IArtworkRepository
    {
        private ArtworkDbContext _artworkDbContext;

        public ArtworkRepository(ArtworkDbContext artworkDbContext)
        {
            _artworkDbContext = artworkDbContext;
        }

        public  List<Artwork> LoadArtworks()
        {
            return _artworkDbContext.Artworks.ToList();

        }
    }
    public interface IArtworkRepository
    {
        public List<Artwork> LoadArtworks();
    }

}
