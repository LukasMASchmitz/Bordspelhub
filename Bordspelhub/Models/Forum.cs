using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bordspelhub.Models
{
    public class Forum
    {
        [Key]
        public int ForumId { get; set; }
        [Required]
        public string Titel { get; set; }
        [Required]
        public string Onderwerp { get; set; }
        [Required]
        public string Owner { get; set; }
        public Spel? Spel { get; set; }
        public Evenement? Evenement { get; set; }
    }
}
