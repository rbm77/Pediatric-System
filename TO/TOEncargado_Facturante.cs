﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TO
{
    class TOEncargado_Facturante
    {
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public decimal Cedula { get; set; }
        public decimal Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public string Parentezco { get; set; }

        public TOEncargado_Facturante()
        {

        }

        public TOEncargado_Facturante(string nombre, string primerApellido, string segundoApellido, decimal cedula, decimal telefono, string correo, string parentezco)
        {
            this.Nombre = nombre;
            this.PrimerApellido = primerApellido;
            this.SegundoApellido = segundoApellido;
            this.Cedula = cedula;
            this.Telefono = telefono;
            this.CorreoElectronico = correo;
            this.Parentezco = parentezco;
        }

        public TOEncargado_Facturante(string nombre, string primerApellido, string segundoApellido, decimal cedula, decimal telefono, string correo)
        {
            this.Nombre = nombre;
            this.PrimerApellido = primerApellido;
            this.SegundoApellido = segundoApellido;
            this.Cedula = cedula;
            this.Telefono = telefono;
            this.CorreoElectronico = correo;
        }
    }
}