using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BLExamenFisico
    {
        public string CodigoMedico { get; set; }
        public string CodigoExpediente { get; set; }
        public DateTime Fecha_Hora { get; set; }
        public float Talla { get; set; }
        public float Peso { get; set; }
        public float PerimetroCefalico { get; set; }
        public float SO2 { get; set; }
        public string EstadoAlerta { get; set; }
        public string EstadoHidratacion { get; set; }
        public string RuidosCardiacos { get; set; }
        public string CamposPulmonares { get; set; }
        public string Abdomen { get; set; }
        public string Faringe { get; set; }
        public string Nariz { get; set; }
        public string Oidos { get; set; }
        public string SNC { get; set; }
        public string Osteomuscular { get; set; }
        public string Piel { get; set; }
        public string Neurodesarrollo { get; set; }
        public string Otros { get; set; }

        public BLExamenFisico()
        {

        }

        public BLExamenFisico(string codMed, string codExp, DateTime fecha, float talla, float peso, float perimetro, float so2, string alerta, string hidratacion, string ruidos, string campos, string abdomen, string faringe, 
            string nariz, string oidos, string snc, string oseteo, string piel, string neurode, string otros)
        {
            this.CodigoMedico = codMed;
            this.CodigoExpediente = codExp;
            this.Fecha_Hora = fecha;
            this.Talla = talla;
            this.Peso = peso;
            this.PerimetroCefalico = perimetro;
            this.SO2 = so2;
            this.EstadoAlerta = alerta;
            this.EstadoHidratacion = hidratacion;
            this.RuidosCardiacos = ruidos;
            this.CamposPulmonares = campos;
            this.Abdomen = abdomen;
            this.Faringe = faringe;
            this.Nariz = nariz;
            this.Oidos = oidos;
            this.SNC = snc;
            this.Osteomuscular = oseteo;
            this.Piel = piel;
            this.Neurodesarrollo = neurode;
            this.Otros = otros;
        }
    }
}
