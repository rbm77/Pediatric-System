using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TO
{
   public class TOCuenta
    {

        public string correo { get; set; }
        public string contrasena { get; set; }
        public string tipo { get; set; }

        public string estado { get; set; }

        public TOCuenta()
        {
        }
        public TOCuenta(string correo, string contrasena, string tipo, string estado)
        {
            this.correo = correo;
            this.contrasena = contrasena;
            this.tipo = tipo;
            this.estado = estado;
        }
    }
}
