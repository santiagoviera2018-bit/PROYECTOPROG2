using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace TiendaVideojuegos
{
    public class Juego : IMostrable
    {
        private int id;
        private string titulo;
        private string genero;
        private string plataforma;

        [JsonPropertyName("id")]
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        [JsonPropertyName("title")]
        public string Titulo
        {
            get { return this.titulo; }
            set { this.titulo = value; }
        }

        [JsonPropertyName("genre")]
        public string Genero
        {
            get { return this.genero; }
            set { this.genero = value; }
        }

        [JsonPropertyName("platform")]
        public string Plataforma
        {
            get { return this.plataforma; }
            set { this.plataforma = value; }
        }

        void IMostrable.MostrarDetalle()
        {
            Console.WriteLine($"[{this.id}] {this.titulo} | Género: {this.genero} | Plataforma: {this.plataforma}");
        }
    }
}