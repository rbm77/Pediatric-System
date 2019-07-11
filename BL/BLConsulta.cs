using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BLConsulta
    {
        public string CodigoMedico { get; set; }
        public string CodigoExpediente { get; set; }
        public DateTime Fecha_Hora { get; set; }
        public string Analisis { get; set; }
        public string ImpresionDiagnostica { get; set; }
        public string Plan { get; set; }
        public Boolean MedicinaMixta { get; set; }
        public string Frecuencia { get; set; }
        public string ReferidoA { get; set; }
        public Boolean Estado { get; set; }
        public string PadecimientoActual { get; set; }
        public BLConsulta()
        {

        }

        public BLConsulta(string codMedico, string codExpediente, DateTime fecha, string analisis, string impresion, string plan, Boolean medicinaMix, string frecuencia, string refererido, Boolean estado, string padecimiento)
        {
            this.CodigoMedico = codMedico;
            this.CodigoExpediente = CodigoExpediente;
            this.Fecha_Hora = fecha;
            this.Analisis = analisis;
            this.ImpresionDiagnostica = impresion;
            this.Plan = plan;
            this.MedicinaMixta = medicinaMix;
            this.Frecuencia = frecuencia;
            this.ReferidoA = refererido;
            this.Estado = estado;
            this.PadecimientoActual = padecimiento;
        }
    }
}
