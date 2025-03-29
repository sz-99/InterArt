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

        
    }
}
