using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TO
{
   public class TOPersonal
    {
        public string correo { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int cedula { get; set; }
        public int telefono { get; set; }

        public TOPersonal()
        {
        }

        public TOPersonal(string correo, string nombre, string apellido, int cedula, int telefono)
        {
            this.correo = correo;
            this.nombre = nombre;
            this.apellido = apellido;
            this.cedula = cedula;
            this.telefono = telefono;
        }
    }
}
