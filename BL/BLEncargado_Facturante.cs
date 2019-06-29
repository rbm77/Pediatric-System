using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BLEncargado_Facturante
    {
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Cedula { get; set; }
        public decimal Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public string Parentesco { get; set; }
        public string Direccion { get; set; }

        public BLEncargado_Facturante()
        {

        }

        public BLEncargado_Facturante(string nombre, string primerApellido, string segundoApellido, string cedula, decimal telefono, string correo, string parentesco, string direccion)
        {
            this.Nombre = nombre;
            this.PrimerApellido = primerApellido;
            this.SegundoApellido = segundoApellido;
            this.Cedula = cedula;
            this.Telefono = telefono;
            this.CorreoElectronico = correo;
            this.Parentesco = parentesco;
            this.Direccion = direccion;
        }

        public BLEncargado_Facturante(string nombre, string primerApellido, string segundoApellido, string cedula, decimal telefono, string correo, string direccion)
        {
            this.Nombre = nombre;
            this.PrimerApellido = primerApellido;
            this.SegundoApellido = segundoApellido;
            this.Cedula = cedula;
            this.Telefono = telefono;
            this.CorreoElectronico = correo;
            this.Direccion = direccion;
        }
    }
}
