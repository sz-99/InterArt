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

        public Comment UpdateComment(int commentId, CommentDTO commentDTO)
        {
            if (string.IsNullOrEmpty(commentDTO.ArtworkId) || 
            string.IsNullOrEmpty(commentDTO.CommentText) || 
            commentDTO.UserId == 0)
            {
                return null;
            }
            
            var comment = _db.Comments.FirstOrDefault(a => a.Id == commentId);
            if (comment == null) return null;

            comment.CommentText = commentDTO.CommentText;
            _db.SaveChanges();

            return comment;
        }

        public bool DeleteComment(int commentId)
        {
            var commentToDelete = _db.Comments.FirstOrDefault(c=>c.Id == commentId);
            if(commentToDelete == null) return false;

            _db.Comments.Remove(commentToDelete);
            _db.SaveChanges();
            return true;
        }

        public bool UpvoteComment(int commentId)
        {
            var comment = _db.Comments.FirstOrDefault(c=>c.Id==commentId);
            if(comment == null) return false;

            comment.Upvote++;
            _db.SaveChanges();
            return true;
        }

        public bool DownvoteComment(int commentId)
        {
            var comment = _db.Comments.FirstOrDefault(c=>c.Id==commentId);
            if(comment == null) return false;

            comment.Downvote++;
            _db.SaveChanges();
            return true;
        }
    }
    public interface ICommentRepository
    {
        List<Comment> LoadCommentsByArtworkId(string artworkId);
        public bool AddNewComment(CommentDTO commentDTO);
        Comment UpdateComment(int commentId, CommentDTO commentDTO);
        bool DeleteComment(int commentId);
        bool UpvoteComment(int commentId);
        bool DownvoteComment(int commentId);
    }

}
