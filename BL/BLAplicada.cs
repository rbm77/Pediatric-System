using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BLAplicada
    {
        public string IDExpediente { get; set; }
        public string NombreVacuna { get; set; }
        public string Aplicacion { get; set; }

        public BLAplicada()
        {

        }

        public BLAplicada(string idExpediente, string nombreVacuna, string aplicacion)
        {
            this.IDExpediente = idExpediente;
            this.NombreVacuna = nombreVacuna;
            this.Aplicacion = aplicacion;
        }

    }
}
