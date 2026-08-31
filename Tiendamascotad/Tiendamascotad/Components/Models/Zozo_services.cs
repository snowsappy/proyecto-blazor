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
            return await http.GetFromJsonAsync<List<Mascota>>("api/mascotas")
                   ?? new List<Mascota>();
        }
    }
}
