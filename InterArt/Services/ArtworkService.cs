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
    }

    public interface IArtworkService
    {
    }
}
