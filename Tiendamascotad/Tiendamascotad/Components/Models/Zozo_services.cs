namespace Tiendamascotad.Components.Models
{
    public class Zozo_services
    {
        private readonly HttpClient http;

        public Zozo_services(HttpClient http)
        {
            this.http = http;
        }

        public async Task<List<Mascota>> obtenermascotas()
        {
            return await http.GetFromJsonAsync<List<Mascota>>("/pets")
                   ?? new List<Mascota>();
        }

        public async Task<bool> RegistrarPersona(Persona persona)
        {
            var respuesta = await http.PostAsJsonAsync("/users/registrar", persona);

            return respuesta.IsSuccessStatusCode;
        }
    }
}
