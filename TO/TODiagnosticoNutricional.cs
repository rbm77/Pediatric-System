using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TO
{
    public class TODiagnosticoNutricional
    {
        public string CodigoMedico { get; set; }
        public string CodigoExpediente { get; set; }
        public DateTime Fecha_Hora { get; set; }
        public string Peso_Edad { get; set; }
        public string Talla_Edad_0 { get; set; }
        public string Cefalico_Edad { get; set; }
        public string Peso_Talla { get; set; }
        public string IMC_Edad { get; set; }
        public string Talla_Edad_5 { get; set; }

        public TODiagnosticoNutricional()
        {

        }

        public TODiagnosticoNutricional(string codMed, string codExpe, DateTime fecha, string pesoEdad, string tallaEdad0, string cefalicoEdad, string pesoTalla, string imcEdad, string tallaEdad5)
        {
            this.CodigoMedico = codMed;
            this.CodigoExpediente = codExpe;
            this.Fecha_Hora = fecha;
            this.Peso_Edad = pesoEdad;
            this.Talla_Edad_0 = tallaEdad0;
            this.Cefalico_Edad = cefalicoEdad;
            this.Peso_Talla = pesoTalla;
            this.IMC_Edad = imcEdad;
            this.Talla_Edad_5 = tallaEdad5;

        }
    }
}
