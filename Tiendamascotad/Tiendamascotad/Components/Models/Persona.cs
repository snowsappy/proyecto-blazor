using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tiendamascotad.Components.Models
{
    public class Persona
    {
        [Key]

        public int id_user { get; set; }
        [Required]
        [StringLength(20)]
        public string firstname { get; set; }
        [Required]
        [StringLength(50)]
        [RegularExpression(
       @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+$",
       ErrorMessage = "Only letters are allowed")]
        
        public string lastname { get; set; }
        [EmailAddress]
        [Required]
        public string email { get; set; }
        [Length(10, 10)]
        [Required]
        public string? phone { get; set; }
        [Required]

        public string adress { get; set; }
        [PasswordPropertyText]
        [Required]
        public string password { get; set; }
       
        public bool rol { get; set; }


    }
}
