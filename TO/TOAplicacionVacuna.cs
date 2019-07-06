using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TO
{
    public class TOAplicacionVacuna
    {
        public string IDExpediete { get; set; }
        public string NombreVacuna { get; set; }
        public bool Aplicacion1 { get; set; }
        public bool Aplicacion2 { get; set; }
        public bool Aplicacion3 { get; set; }
        public bool Refuerzo1 { get; set; }
        public bool Refuerzo2 { get; set; }
        public bool Refuerzo3 { get; set; }

        public TOAplicacionVacuna()
        {

        }


        public TOAplicacionVacuna(string idExpediente, string nombreVacuna, string aplicacion1, string aplicacion2, string aplicacion3,
            string refuerzo1, string refuerzo2, string refuerzo3)
        {
            this.IDExpediete = idExpediente;
            this.NombreVacuna = nombreVacuna;
            this.Aplicacion1 = Convertir(aplicacion1);
            this.Aplicacion2 = Convertir(aplicacion2);
            this.Aplicacion3 = Convertir(aplicacion3);
            this.Refuerzo1 = Convertir(refuerzo1);
            this.Refuerzo2 = Convertir(refuerzo2);
            this.Refuerzo3 = Convertir(refuerzo3);

        }

        private bool Convertir(string binario)
        {
            return bool.Parse(binario);
        }

    }
}
