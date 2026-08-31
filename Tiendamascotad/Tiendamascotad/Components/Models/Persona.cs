using System.ComponentModel.DataAnnotations;

namespace Tiendamascotad.Components.Models
{
    public class Persona
    {
        [Key]
        public int id_user { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public int phone { get; set; }
        public string adress { get; set; }
        public string password { get; set; }
        public int rol { get; set; }


    }
}
