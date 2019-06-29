using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BL
{
    public class BLDireccion
    {
        public string Codigo { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
        public string Barrio { get; set; }

        public BLDireccion()
        {

        }

        public BLDireccion(string cod, string provincia, string canton, string distrito, string barrio)
        {
            this.Codigo = cod;
            this.Provincia = provincia;
            this.Canton = canton;
            this.Distrito = distrito;
            this.Barrio = barrio;
        }

        public BLDireccion(string cod, string provincia, string canton, string distrito)
        {
            this.Codigo = cod;
            this.Provincia = provincia;
            this.Canton = canton;
            this.Distrito = distrito;
        }

    }
}
