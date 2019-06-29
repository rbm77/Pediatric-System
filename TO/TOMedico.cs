using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TO
{
   public class TOMedico
    {
        public string codigo { get; set; }
        public string correo { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int cedula { get; set; }
        public int telefono { get; set; }

        public TOMedico()
        {
        }

        public TOMedico(string codigo, string nombre, string apellido)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.apellido = apellido;
        }

        public TOMedico(string codigo, string correo, string nombre, string apellido, int cedula, int telefono)
        {
            this.codigo = codigo;
            this.correo = correo;
            this.nombre = nombre;
            this.apellido = apellido;
            this.cedula = cedula;
            this.telefono = telefono;
        }
    }
}
