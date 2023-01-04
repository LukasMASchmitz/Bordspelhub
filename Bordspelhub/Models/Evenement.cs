using System.ComponentModel.DataAnnotations;

namespace Bordspelhub.Models
{
    public class Evenement
    {

        [Key]
        public int EvenementId { get; set; }

        [Required]
        public string EvenementNaam { get; set; }

        [Required]
        public string EvenementLocatie { get; set; }

        public string EvenementThema { get; set; }

        public int EvenementDeelnemers { get; set; }

        public ICollection<Gebruiker> Gebruikers { get; set; }
    }
}
