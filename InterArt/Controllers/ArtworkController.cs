using Microsoft.AspNetCore.Mvc;
using InterArt.Models;

namespace InterArt.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArtworkController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetArtworks()
        {
            return Ok(new Artwork());
        }
    }
}
