using InterArt.Models;
using InterArt_Backend.DBContext;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Text.Json;

namespace InterArt.Repository
{
    public class ReplyRepository : IReplyRepository
    {
        private ArtworkDbContext _db;

        public ReplyRepository(ArtworkDbContext artworkDbContext)
        {
            _db = artworkDbContext;
        }

        public  List<Reply> LoadRepliesByCommentId(int commentId)
        {
            return _db.Replies.Where(a => a.CommentId == commentId).ToList();
        }

        public Reply AddNewReply(ReplyDTO replyDTO)
        {
            var newReply = new Reply()
            {
                UserId = replyDTO.UserId,
                CommentId = replyDTO.CommentId,
                ReplyText = replyDTO.ReplyText
            };
            _db.Replies.Add(newReply);
            _db.SaveChanges();
            return newReply;
        }
        public Reply UpdateReply(int replyId, ReplyDTO replyDTO)
        {
            if(string.IsNullOrEmpty(replyDTO.ReplyText)||
                        replyDTO.CommentId == 0 || 
                        replyDTO.UserId == 0)
            {
                return null;
            }

            var reply = _db.Replies.FirstOrDefault(r=>r.Id == replyId);
            if(reply == null) return null;

            reply.ReplyText = replyDTO.ReplyText;
            _db.SaveChanges();

            return reply;
        }
        public bool DeleteReply(int replyId)
        {
            var reply = _db.Replies.FirstOrDefault(a=>a.Id == replyId);
            if(reply == null ) return false;

            _db.Replies.Remove(reply);
            _db.SaveChanges();
            return true;
        }
    }
    public interface IReplyRepository
    {
        List<Reply> LoadRepliesByCommentId(int commentId);
        Reply AddNewReply(ReplyDTO replyDTO);
        Reply UpdateReply(int replyId, ReplyDTO replyDTO);
        bool DeleteReply(int replyId);
    }

}
