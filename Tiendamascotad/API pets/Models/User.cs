using System.ComponentModel.DataAnnotations;

namespace API_pets.Models
{
    public class User
    {
        [Key]
        int id_user { get; set; }
        string firstname { get; set; }
        string lastname { get; set; }
        string email { get; set; }
        int phone { get; set; }
        int adress { get; set; }
        int password { get; set; }
        int rol { get; set; }
    }
}
