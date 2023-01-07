using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bordspelhub.Models
{
    public class Comment
    {
        
        [Key]
        public int CommentId { get; set; }
        [Required]
        public string CommentText { get; set; }
        [ForeignKey("Forum")]
        public int ForumId { get; set; }
        [Required]
        public string Commenter { get; set; }
    }
}
