﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BLCita
    {
        public string CodigoMedico { get; set; }

        public string NombreMedico { get; set; }

        public string Nombre { get; set; }
        public string Edad { get; set; }
        public string Correo { get; set; }
        public int Telefono { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }

        public BLCita()
        {

        }

        public BLCita(string codigoMedico, string nombreMedico, string nombrePaciente, string fecha, string hora)
        {
            this.CodigoMedico = codigoMedico;
            this.NombreMedico = nombreMedico;
            this.Nombre = nombrePaciente;
            this.Fecha = fecha;
            this.Hora = hora;
        }

        public BLCita(string hora)
        {
            this.Hora = hora;
        }
        public BLCita(string codigoMedico, string nombre, string edad, string correo, int telefono, string fecha, string hora)
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
