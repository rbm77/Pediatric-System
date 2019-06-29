using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TO
{
    public class TODireccion
    {
        public string Codigo { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
        public string Barrio { get; set; }

        public TODireccion()
        {

        }

        public TODireccion(string cod, string provincia, string canton, string distrito, string barrio)
        {
            this.Codigo = cod;
            this.Provincia = provincia;
            this.Canton = canton;
            this.Distrito = distrito;
            this.Barrio = barrio;
        }

        public TODireccion(string cod, string provincia, string canton, string distrito)
        {
            this.Codigo = cod;
            this.Provincia = provincia;
            this.Canton = canton;
            this.Distrito = distrito;
        }
    }
}

