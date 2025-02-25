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

        public Artwork FetchArtworkById(int id)
        {
            return _artworkRepository.FetchArtworkById(id);
        }
        public Artwork FetchRandomArtwork()
        {
            return _artworkRepository.FetchRandomArtwork();
        }
    }

    public interface IArtworkService
    {
        Artwork FetchArtworkById(int id);
        Artwork FetchRandomArtwork();
        List<Artwork> LoadArtworks();
    }
}
