namespace InterArt.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ArtworkId { get; set; } = string.Empty;
        public string CommentText { get; set; } = string.Empty;
        public int Upvote { get; set; }
        public int Downvote { get; set; }

    }
}
