using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TO
{
    public class TOCita
    {
        public string CodigoMedico { get; set; }
        public string Nombre { get; set; }
        public string Edad { get; set; }
        public string Correo { get; set; }
        public int Telefono { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }

        public TOCita()
        {

        }

        public TOCita(string hora)
        {
            this.Hora = hora;
        }
        public TOCita(string codigoMedico, string nombre, string edad, string correo, int telefono, string fecha, string hora)
        {
            this.CodigoMedico = codigoMedico;
            this.Correo = correo;
            this.Telefono = telefono;
            this.Nombre = nombre;
            this.Edad = edad;
            this.Fecha = fecha;
            this.Hora = hora;
        }
    }
}
