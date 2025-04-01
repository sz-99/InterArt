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

        public Reply UpdateReply(int replyId, ReplyDTO replyDTO)
        {
            return _replyRepository.UpdateReply(replyId, replyDTO);
        }

        public bool DeleteReply(int replyId)
        {
            return _replyRepository.DeleteReply(replyId);
        }

    }

    public interface IReplyService
    {
        List<Reply> LoadRepliesBycommentId(int commentId);
        Reply AddNewReply(ReplyDTO replyDTO);
        Reply UpdateReply(int replyId, ReplyDTO replyDTO);
        bool DeleteReply(int replyId);
       
    }
}
