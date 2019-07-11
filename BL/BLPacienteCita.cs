using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BLPacienteCita
    {
        public string NombrePaciente { get; set; }
        public string EdadPaciente { get; set; }
        public string CorreoEncargado { get; set; }
        public string TelefonoEncargado { get; set; }

        public BLPacienteCita()
        {

        }

        public BLPacienteCita(string nombrePaciente, string edadPaciente, string correoEncargado, string telefonoEncargado)
        {
            this.NombrePaciente = nombrePaciente;
            this.EdadPaciente = edadPaciente;
            this.CorreoEncargado = correoEncargado;
            this.TelefonoEncargado = telefonoEncargado;
        }
    }
}
