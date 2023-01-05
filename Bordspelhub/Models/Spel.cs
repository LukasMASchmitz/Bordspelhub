using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Bordspelhub.Models
{
    public class Spel
    {
        [Key]
        public int SpelId { get; set; }
        [Required]
        public string SpelNaam { get; set;}
        [Required]
        public int Gebruiker { get; set;}
        public string Categorie { get; set; }
        public int Pegi { get; set; }
        public string Beschrijving { get; set; }
    }
}
