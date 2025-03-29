using System.Runtime.CompilerServices;
using InterArt.Models;
using InterArt.Repository;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace InterArt.Services
{
    public class ReplyService : IReplyService
    {
        private IReplyRepository _replyRepository;

        public ReplyService(IReplyRepository r)
        {
            _replyRepository = r;
        }

        public List<Reply> LoadRepliesBycommentId(int commentId)
        {
            return _replyRepository.LoadRepliesByCommentId(commentId);
        }

        public Reply AddNewReply(ReplyDTO replyDTO)
        {
            return _replyRepository.AddNewReply(replyDTO);
        }

    }

    public interface IReplyService
    {
        List<Reply> LoadRepliesBycommentId(int commentId);
        public Reply AddNewReply(ReplyDTO replyDTO);
       
    }
}
