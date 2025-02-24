using InterArt.Models;
using InterArt.Repository;

namespace InterArt.Services
{
    public class ArtworkService : IArtworkService
    {
        private IArtworkRepository _artworkRepository;

        public ArtworkService(IArtworkRepository artworkRepository)
        {
            _artworkRepository = artworkRepository;
        }

        public List<Artwork> LoadArtworks()
        {
            return _artworkRepository.LoadArtworks();
        }
    }

    public interface IArtworkService
    {
        List<Artwork> LoadArtworks();
    }
}
