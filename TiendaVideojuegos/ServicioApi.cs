using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace TiendaVideojuegos
{
    public class ServicioApi
    {
        private readonly HttpClient client;
       
        private const string UrlApiOficial = "https://www.freetogame.com/api/games";

        public ServicioApi()
        {
            this.client = new HttpClient();
        }

        public async Task<List<Juego>> ObtenerJuegosAsync()
        {
            try
            {
               
                HttpResponseMessage respuesta = await this.client.GetAsync(UrlApiOficial);

               
                if (!respuesta.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"La API devolvió un código de error HTTP: {(int)respuesta.StatusCode} ({respuesta.ReasonPhrase})");
                }

                string json = await respuesta.Content.ReadAsStringAsync();

               
                List<Juego> juegos = JsonSerializer.Deserialize<List<Juego>>(json);

               
                if (juegos == null || juegos.Count == 0)
                {
                    throw new FormatException("Los datos recibidos no cumplen con el formato de la lista de juegos de FreeToGame.");
                }

                return juegos;
            }
            catch (Exception ex)
            {
                
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n=======================================================");
                Console.WriteLine("[ERROR CRÍTICO DE INTEGRIDAD DE API]");
                Console.WriteLine($"Detalle: {ex.Message}");
                Console.WriteLine("El sistema se detendrá porque la API oficial fue alterada o no responde.");
                Console.WriteLine("=======================================================\n");
                Console.ResetColor();

                
                throw new InvalidOperationException("Falla crítica al conectar con la API oficial de FreeToGame.", ex);
            }
        }
    }
}
