using Microsoft.AspNetCore.Mvc;
using InterArt.Models;
using InterArt.Services;
using Microsoft.Identity.Client;

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
        [Route("{artworkId}")]
        public IActionResult GetComments(string artworkId)
        {
            var comments = _commentService.LoadCommentsByArtworkId(artworkId);
            if(comments !=null)return Ok(comments);
            return BadRequest("No comments found.");
        }

        [HttpPost]
        public IActionResult PostComment(CommentDTO commentDTO)
        {
            bool result = _commentService.AddNewComment(commentDTO);
            return result? Ok(): BadRequest("Comment cannot be posted.");
            
        }

        [HttpPatch]
        [Route("{commentId}")]
        public IActionResult PatchComment(int commentId, CommentDTO commentDTO)
        {
            var newComment = _commentService.UpdateComment(commentId, commentDTO);
            return newComment != null ? 
            Ok(newComment) 
            : BadRequest("Comment cannot be edited.");
        }

        [HttpDelete]
        [Route("{commentId}")]
        public IActionResult DeleteComment(int commentId)
        {
            bool result = _commentService.DeleteComment(commentId);
            return result? Ok(): BadRequest();
        }

        [HttpPatch]
        [Route("{commentId}/up")]
        public IActionResult PatchUpvoteComment(int commentId)
        {
            bool result = _commentService.UpvoteComment(commentId);
            return result? Ok(): BadRequest();
        }

        [HttpPatch]
        [Route("{commentId}/down")]

        public IActionResult PatchDownvoteComment(int commentId)
        {
            bool result = _commentService.DownvoteComment(commentId);
            return result? Ok(): BadRequest();
        }

        
    }
}
