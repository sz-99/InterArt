namespace InterArt.Models
{
    public class PostComment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ArtworkId { get; set; } = string.Empty;
        public string CommentText { get; set; } = string.Empty;

    }
}
