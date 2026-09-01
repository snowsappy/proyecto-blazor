using System.ComponentModel.DataAnnotations;

namespace Tiendamascotad.Components.Models
{
    public class Solicitud
    {
        [Key]

        public int id_adoption { get; set; }
        public int id_user { get; set; }
        public int id_pet { get; set; }
        public DateOnly date_request { get; set; }
        public bool adoption_state { get; set; }
        public string reason { get; set; }
    }
}
