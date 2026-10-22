using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;

namespace TiendaVideojuegos
{
    public class GestorUsuarios
    {
        private const string ArchivoPath = "usuarios.json";

        public List<Usuario> CargarUsuarios()
        {
            if (!File.Exists(ArchivoPath)) return new List<Usuario>();
            string json = File.ReadAllText(ArchivoPath);
            return JsonSerializer.Deserialize<List<Usuario>>(json) ?? new List<Usuario>();
        }

        public void GuardarUsuarios(List<Usuario> usuarios)
        {
            string json = JsonSerializer.Serialize(usuarios, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(ArchivoPath, json);
        }
    }
}