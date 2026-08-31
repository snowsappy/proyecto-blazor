using System.ComponentModel.DataAnnotations;

namespace API_pets.Models
{
    public class Pet
    {
        [Key]
         int id { get; set; }
        string name { get; set; }
        string specie { get; set; }
        string breed { get; set; }
        DateOnly birthdate { get; set; }
        string description { get; set; }
        string image { get; set; }
        bool state { get; set; }
    }
}
