using System.ComponentModel.DataAnnotations;

namespace Bordspelhub.Models
{
    public class Gebruiker
    {

        [Key]
        public int GebruikerId { get; set;}

        [Required]
        public string GebruikerNaam { get; set;}

        [Required]
        public string GebruikerEmail { get; set;}

        public int GebruikerLeeftijd { get; set;}

        public string GebruikerGeslacht { get; set; }

        public ICollection<Evenement> Evenementen { get; set; }
        public ICollection<Spel> Spellen { get; set; }
    }
}
