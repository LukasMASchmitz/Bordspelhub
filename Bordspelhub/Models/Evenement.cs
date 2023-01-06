using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bordspelhub.Models
{
    public class Evenement
    {
        [Key]
        public int EvenementId { get; set; }
        [Required]
        public string EvenementNaam { get; set; }
        [Required]
        public string Locatie { get; set; }
        [Required]
        public string EvenementDatum { get; set; }
        [Required] 
        public string URL { get; set; }
        [Required]
        public string Creator { get; set; }
        public string Beschrijving { get; set; }
    }
}
