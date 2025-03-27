using Microsoft.AspNetCore.Mvc;
using InterArt.Models;
using InterArt.Services;

namespace InterArt.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : ControllerBase
    {
        private ICommentService _commentService;

        public CommentController(ICommentService cr)
        {
            _commentService = cr;
        }

        [HttpGet]
        public IActionResult GetComments(string artworkId)
        {
            var comments = _commentService.LoadCommentsByArtworkId(artworkId);
            if(comments !=null)return Ok(comments);
            return BadRequest("No comments found.");
        }

        
    }
}
