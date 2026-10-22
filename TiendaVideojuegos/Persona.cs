using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaVideojuegos
{
    public abstract class Persona
    {
       
        private string nombre;
        private string email;
        private string password;

       
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }

        protected Persona(string nombre, string email, string password)
        {
            this.nombre = nombre;
            this.email = email;
            this.password = password;
        }
    }
}
