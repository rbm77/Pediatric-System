using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BLCita
    {
        public string CodigoMedico { get; set; }
        public string CorreoCuenta { get; set; }
        public string CedulaExpediente { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }

        public BLCita()
        {

        }
        public BLCita(string codigoMedico, string correoCuenta, string cedulaExpediente, string descripcion, DateTime fecha, string hora)
        {
            this.CodigoMedico = codigoMedico;
            this.CorreoCuenta = correoCuenta;
            this.CedulaExpediente = cedulaExpediente;
            this.Descripcion = descripcion;
            this.Fecha = fecha;
            this.Hora = hora;
        }
    }
}
