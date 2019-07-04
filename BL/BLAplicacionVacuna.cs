using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BLAplicacionVacuna
    {
        public string IDExpediete { get; set; }
        public string NombreVacuna { get; set; }
        public bool Aplicacion1 { get; set; }
        public bool Aplicacion2 { get; set; }
        public bool Aplicacion3 { get; set; }
        public bool Refuerzo1 { get; set; }
        public bool Refuerzo2 { get; set; }
        public bool Refuerzo3 { get; set; }

        public BLAplicacionVacuna()
        {

        }

        public BLAplicacionVacuna(string idExpediente, string nombreVacuna, bool aplicacion1, bool aplicacion2, bool aplicacion3,
            bool refuerzo1, bool refuerzo2, bool refuerzo3)
        {
            this.IDExpediete = idExpediente;
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
