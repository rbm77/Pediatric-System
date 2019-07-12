using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BLExpediente
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Cedula { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public byte[] Foto { get; set; }
        public string ExpedienteAntiguo { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }

        public BLExpediente()
        {

        }

        public BLExpediente(string cod, string nombre, string primerApellido, string segundoApellido)
        {
            this.Codigo = cod;
            this.Nombre = nombre;
            this.PrimerApellido = primerApellido;
            this.SegundoApellido = segundoApellido;
        }

        public BLExpediente(string cod, string nombre, string primerApellido, string segundoApellido, string cedula, DateTime fechaNacimiento, string sexo, byte[] foto, string expediente, string direccion)
        {
            this.Codigo = cod;
            this.Nombre = nombre;
            this.PrimerApellido = primerApellido;
            this.SegundoApellido = segundoApellido;
            this.Cedula = cedula;
            this.FechaNacimiento = fechaNacimiento;
            this.Sexo = sexo;
            this.Foto = foto;
            this.ExpedienteAntiguo = expediente;
            this.Direccion = direccion;
        }
    }
}
