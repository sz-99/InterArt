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
    }
    public interface IReplyRepository
    {
        List<Reply> LoadRepliesByCommentId(int commentId);
    }

}
