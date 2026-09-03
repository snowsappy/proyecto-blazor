using System.ComponentModel.DataAnnotations;

namespace Tiendamascotad.Components.Models
{
    public class Mascota
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string specie { get; set; }
        public string breed { get; set; }
        public DateOnly birthdate { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public bool state { get; set; }

        public int CalcularEdad(DateOnly fechaNacimiento)
        {
            DateOnly hoy = DateOnly.FromDateTime(DateTime.Today);

            int edad = hoy.Year - fechaNacimiento.Year;

            if (fechaNacimiento > hoy.AddYears(-edad))
            {
                edad--;
            }

            return edad;
        }
    }
}