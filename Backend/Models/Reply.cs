namespace InterArt.Models
{
    public class Reply
    {
        public int Id { get; set; }
        public int UserId {  get; set; }
        public int CommentId { get; set; }
        public string ReplyText { get; set; } = string.Empty;
    }
}
