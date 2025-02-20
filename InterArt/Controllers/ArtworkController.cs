using Microsoft.AspNetCore.Mvc;
using InterArt.Models;
using InterArt.Services;

namespace InterArt.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArtworkController : ControllerBase
    {
        private IArtworkService _artworkService;

        public ArtworkController(IArtworkService artworkService)
        {
            _artworkService = artworkService;
        }

        [HttpGet]
        public IActionResult GetArtworks()
        {
            var artworks = _artworkService.LoadArtworks();
            return Ok(artworks);
        }
    }
}
