using Microsoft.EntityFrameworkCore;

namespace API_pets.Models
{
    public class zozo_context : DbContext
    {

        public zozo_context(DbContextOptions<zozo_context> options) : base(options)
        { }

        public DbSet<Pet> pets { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Request_adoption> adoption_request  { get; set; }

    }
}
