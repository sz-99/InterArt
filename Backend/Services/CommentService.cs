using System.Runtime.CompilerServices;
using InterArt.Models;
using InterArt.Repository;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace InterArt.Services
{
    public class CommentService : ICommentService
    {
        private ICommentRepository _commentRepository;

        public CommentService(ICommentRepository cr)
        {
            _commentRepository = cr;
        }

        public List<Comment> LoadCommentsByArtworkId(string artworkId)
        {
            return _commentRepository.LoadCommentsByArtworkId(artworkId);
        }

        public bool AddNewComment(CommentDTO commentDTO)
        {
            return _commentRepository.AddNewComment(commentDTO);
        }

    }

    public interface ICommentService
    {
        List<Comment> LoadCommentsByArtworkId(string artworkId);
        public bool AddNewComment(CommentDTO commentDTO);
       
    }
}
