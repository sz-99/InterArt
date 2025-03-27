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
    }
    public interface ICommentRepository
    {
        List<Comment> LoadCommentsByArtworkId(string artworkId);
    }

}
