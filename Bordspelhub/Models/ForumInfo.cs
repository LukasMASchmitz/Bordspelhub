namespace Bordspelhub.Models
{
    public class ForumInfo
    {
        public ForumInfo() { }

        public IEnumerable<Comment>? Comments { get; set; }
        public IEnumerable<Forum>? Forums { get; set; }


    }
}
