using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TO
{
    public class TOConsulta
    {
        public string CodigoMedico { get; set; }
        public string CodigoExpediente { get; set; }
        public DateTime Fecha_Hora { get; set; }
        public string Analisis { get; set; }
        public string ImpresionDiagnostica { get; set; }
        public string Plan { get; set; }
        public Boolean MedicinaMixta { get; set; }
        public string Frecuencia { get; set; }
        public string Referido_A { get; set; }
        public Boolean Estado { get; set; }
        public string PadecimientoActual { get; set; }
        public Boolean ReferenciaMedica { get; set; }
        public string Especialidad { get; set; }
        public string MotivoReferecnia { get; set; }
        public string Paciente { get; set; }

        public TOConsulta()
        {

        }

        public TOConsulta(string codMedico, string codExpediente, DateTime fecha, string analisis, string impresion, string plan, Boolean medicinaMix, string frecuencia, string refererido, Boolean estado, string padecimiento, Boolean referencia, string especialidad, string motivo)
        {
            this.CodigoMedico = codMedico;
            this.CodigoExpediente = CodigoExpediente;
            this.Fecha_Hora = fecha;
            this.Analisis = analisis;
            this.ImpresionDiagnostica = impresion;
            this.Plan = plan;
            this.MedicinaMixta = medicinaMix;
            this.Frecuencia = frecuencia;
            this.Referido_A = refererido;
            this.Estado = estado;
            this.PadecimientoActual = padecimiento;
            this.ReferenciaMedica = referencia;
            this.Especialidad = especialidad;
            this.MotivoReferecnia = motivo;
        }

        public TOConsulta(string codMedico, string codExpediente, DateTime fecha, string analisis, string impresion, string plan, Boolean medicinaMix, string frecuencia, string refererido, Boolean estado, string padecimiento, Boolean referencia, string especialidad, string motivo, string paciente)
        {
            this.CodigoMedico = codMedico;
            this.CodigoExpediente = CodigoExpediente;
            this.Fecha_Hora = fecha;
            this.Analisis = analisis;
            this.ImpresionDiagnostica = impresion;
            this.Plan = plan;
            this.MedicinaMixta = medicinaMix;
            this.Frecuencia = frecuencia;
            this.Referido_A = refererido;
            this.Estado = estado;
            this.PadecimientoActual = padecimiento;
            this.ReferenciaMedica = referencia;
            this.Especialidad = especialidad;
            this.MotivoReferecnia = motivo;
            this.Paciente = paciente;
        }
    }
}
