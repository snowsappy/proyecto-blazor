using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tiendamascotad.Components.Models
{
    public class Persona
    {
        [Key]

        public int id_user { get; set; }
        [StringLength(20)]
        public string firstname { get; set; }

        [StringLength(50)]
        [RegularExpression(
       @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+$",
       ErrorMessage = "Only letters are allowed")]
        public string lastname { get; set; }
        [EmailAddress]
        public string email { get; set; }
        [Length(10, 10)]
        public string? phone { get; set; }

        public string adress { get; set; }
        [PasswordPropertyText]
        public string password { get; set; }
        public int rol { get; set; }


    }
}
