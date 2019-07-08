using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TO
{
    public class TOVacuna
    {
        public string NombreVacuna { get; set; }
        public string Aplicacion1 { get; set; }
        public string Aplicacion2 { get; set; }
        public string Aplicacion3 { get; set; }
        public string Refuerzo1 { get; set; }
        public string Refuerzo2 { get; set; }
        public string Refuerzo3 { get; set; }

        public TOVacuna()
        {

        }

        public TOVacuna(string nombreVacuna, string aplicacion1, string aplicacion2, string aplicacion3,
            string refuerzo1, string refuerzo2, string refuerzo3)
        {
            this.NombreVacuna = nombreVacuna;
            this.Aplicacion1 = aplicacion1;
            this.Aplicacion2 = aplicacion2;
            this.Aplicacion3 = aplicacion3;
            this.Refuerzo1 = refuerzo1;
            this.Refuerzo2 = refuerzo2;
            this.Refuerzo3 = refuerzo3;
        }
    }
}
