using System.ComponentModel.DataAnnotations;

namespace Weeklyapp.DataLayer.Entities
{
    public class Cliente
    {
        [Required]
        public string CodiceFiscale { get; set; }

        [Required]
        public string Cognome { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Citta { get; set; }

        [Required]
        public string Provincia { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Telefono { get; set; }

        [Phone]
        public string Cellulare { get; set; }
    }
}
