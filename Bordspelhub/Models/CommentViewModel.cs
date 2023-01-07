namespace Bordspelhub.Models
{
    public class CommentViewModel
    {
        public string commentText { get; set; }
        public int forumId { get; set; }

        public CommentViewModel(string commentText, int forumId)
        {
            this.commentText = commentText;
            this.forumId = forumId;
        }
    }
}
