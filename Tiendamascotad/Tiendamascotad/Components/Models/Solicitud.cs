using System.ComponentModel.DataAnnotations;

namespace Tiendamascotad.Components.Models
{
    public class Solicitud
    {
        [Key]

        int id_adoption { get; set; }
        int id_user { get; set; }
        int id_pet { get; set; }
        DateOnly date_request { get; set; }
        bool adoption_state { get; set; }
        string reason { get; set; }
    }
}
