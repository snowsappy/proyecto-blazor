using System.ComponentModel.DataAnnotations;

namespace Tiendamascotad.Components.Models
{
    public class Persona
    {
        [Required]
        [StringLength(50,MinimumLength =8)]
        public string? Name { get; set; }
        [Required]
        [Phone]
        public int numero { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="correo invalido")]
        public string? gmail { get; set; }
        public string? mensaje { get; set; }
   

    }
}
