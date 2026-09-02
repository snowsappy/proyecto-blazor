using System.ComponentModel.DataAnnotations;

namespace API_pets.Models
{
    public class Request_adoption
    {
        [Key]

        public int id_adoption { get; set; }
        public int id_user { get; set; }
        public int id_pet { get; set; }
        public DateOnly date_request { get; set; }
        public bool adoption_state { get; set; }
      
    }
}
