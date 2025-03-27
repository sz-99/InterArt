using InterArt.Models;
using InterArt_Backend.DBContext;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Text.Json;

namespace InterArt.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private ArtworkDbContext _db;

        public CommentRepository(ArtworkDbContext artworkDbContext)
        {
            _db = artworkDbContext;
        }

        public  List<Comment> LoadCommentsByArtworkId(string artworkId)
        {
            return _db.Comments.Where(a => a.ArtworkId == artworkId).ToList();
        }

        public bool AddNewComment(CommentDTO commentDTO)
        {
            if(commentDTO.ArtworkId == null || commentDTO.CommentText == null || commentDTO.UserId == 0)
                return false;
            var newComment = new Comment()
            {
                UserId = commentDTO.UserId,
                ArtworkId = commentDTO.ArtworkId,
                CommentText = commentDTO.CommentText,
                Upvote = 0,
                Downvote = 0
            };
            _db.Comments.Add(newComment);
            _db.SaveChanges();
            return true;
        }
    }
    public interface ICommentRepository
    {
        List<Comment> LoadCommentsByArtworkId(string artworkId);
        public bool AddNewComment(CommentDTO commentDTO);
    }

}
