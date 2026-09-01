using System.ComponentModel.DataAnnotations;

namespace API_pets.Models
{
    public class Pet
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
    }
}
