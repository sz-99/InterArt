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

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetArtworkById(int id)
        {
            try
            {
                var artwork = _artworkService.FetchArtworkById(id);
                if(artwork == null) return NotFound();
                return Ok(artwork);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new { message = "An error occurred while fetching the artwork. Please try again later." });
            }
        }
        [HttpGet]
        [Route("random")]
        public IActionResult GetRandomArtwork()
        {
            try
            {
                var artwork = _artworkService.FetchRandomArtwork();
                if (artwork == null) return NotFound();
                return Ok(artwork);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new { message = "An error occurred while fetching the artwork. Please try again later." });
            }
        }
    }
}
