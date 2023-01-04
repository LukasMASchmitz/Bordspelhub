using System.ComponentModel.DataAnnotations;

namespace Bordspelhub.Models
{
    public class Spel
    {

        [Key]
        public int SpelId { get; set; }

        [Required]
        public string SpelNaam { get; set; }

        [Required]
        public string SpelCategorie { get; set; }

        public int SpelLeeftijdsCategorie { get; set; }

        public string SpelBeschrijving { get; set; }
    }
}
