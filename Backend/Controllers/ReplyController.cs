using Microsoft.AspNetCore.Mvc;
using InterArt.Models;
using InterArt.Services;

namespace InterArt.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReplyController : ControllerBase
    {
        private IReplyService _replyService;

        public ReplyController(IReplyService r)
        {
            _replyService = r;
        }

        [HttpGet]
        public IActionResult GetReplies(int commentId)
        {
            var replies = _replyService.LoadRepliesBycommentId(commentId);
            if(replies !=null)return Ok(replies);
            return BadRequest("No replies found.");
        }

        [HttpPost]
        public IActionResult PostReply(ReplyDTO replyDTO)
        {
            var reply = _replyService.AddNewReply(replyDTO);
            if(reply != null) return Ok(reply);
            return BadRequest();
        }

         [HttpPatch]
        public IActionResult PatchReply(int replyId, ReplyDTO replyDTO)
        {
            var newReply = _replyService.UpdateReply(replyId, replyDTO);
            return newReply != null ? 
            Ok(newReply) 
            : BadRequest("Reply cannot be edited.");
        }

        [HttpDelete]
        public IActionResult DeleteReply(int replyId)
        {
            var result = _replyService.DeleteReply(replyId);
            return result? Ok() : BadRequest("Reply does not exist.");
        }

        
    }
}
