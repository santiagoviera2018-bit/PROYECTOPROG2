using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaVideojuegos
{
    public class Usuario : Persona, IMostrable
    {
        private RolUsuario rol;
        private List<Juego> juegosComprados;

        public RolUsuario Rol
        {
            get { return this.rol; }
            set { this.rol = value; }
        }

        public List<Juego> JuegosComprados
        {
            get { return this.juegosComprados; }
            set { this.juegosComprados = value; }
        }

        public Usuario(string nombre, string email, string password, RolUsuario rol)
            : base(nombre, email, password)
        {
            this.rol = rol;
            this.juegosComprados = new List<Juego>();
        }

        void IMostrable.MostrarDetalle()
        {
            Console.WriteLine($"Usuario: {this.Nombre} | Email: {this.Email} | Rol: {this.rol} | Compras: {this.juegosComprados.Count}");
        }
    }
}
