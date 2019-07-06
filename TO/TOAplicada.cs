using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TO
{
    public class TOAplicada
    {
        public string IDExpediente { get; set; }
        public string NombreVacuna { get; set; }
        public string Aplicacion { get; set; }

        public TOAplicada()
        {

        }

        public TOAplicada(string idExpediente, string nombreVacuna, string aplicacion)
        {
            this.IDExpediente = idExpediente;
            this.NombreVacuna = nombreVacuna;
            this.Aplicacion = aplicacion;
        }
    }
}
