using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TO
{
    public class TOPacienteCita
    {
        public string NombrePaciente { get; set; }
        public string EdadPaciente { get; set; }
        public string CorreoEncargado { get; set; }
        public string TelefonoEncargado { get; set; }

        public TOPacienteCita()
        {

        }

        public TOPacienteCita(string nombrePaciente, string edadPaciente, string correoEncargado, string telefonoEncargado)
        {
            this.NombrePaciente = nombrePaciente;
            this.EdadPaciente = edadPaciente;
            this.CorreoEncargado = correoEncargado;
            this.TelefonoEncargado = telefonoEncargado;
        }
    }
}
