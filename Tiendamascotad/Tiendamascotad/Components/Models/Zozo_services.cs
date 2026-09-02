using Microsoft.AspNetCore.Identity.Data;

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


        public async Task<Mascota> unamascota(int id)
        {
            return await http.GetFromJsonAsync<Mascota>($"/pets/{id}");



        }
       
        public async Task<List<Solicitud>> ObtenerSolicitudesUsuario(int id)
        {
            return await http.GetFromJsonAsync<List<Solicitud>>(
                $"/request/user/{id}"
            ) ?? new List<Solicitud>();
        }
        public async Task<HttpResponseMessage> iniciar(Ayudalogin login)
        {
            return await http.PostAsJsonAsync("/login", login);
        }

        public async Task<Solicitud?> CrearSolicitud(Solicitud solicitud)
        {
            var respuesta = await http.PostAsJsonAsync("/request", solicitud);

            if (!respuesta.IsSuccessStatusCode)
            {
                var error = await respuesta.Content.ReadAsStringAsync();

                Console.WriteLine("ERROR API:");
                Console.WriteLine(error);
                return null;
            }

            return await respuesta.Content.ReadFromJsonAsync<Solicitud>();
        }
        public async Task<bool> ActualizarSolicitud(int id, Solicitud solicitud)
        {
            var respuesta = await http.PutAsJsonAsync(
                $"/request/{id}",
                solicitud
            );

            return respuesta.IsSuccessStatusCode;
        }
    }
}
