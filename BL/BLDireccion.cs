using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BL
{
    public class BLDireccion
    {
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
        public string OtrasSeñas { get; set; }

        public BLDireccion()
        {

        }

        public BLDireccion(string provincia, string canton, string distrito, string otrasSenas)
        {
            this.Provincia = provincia;
            this.Canton = canton;
            this.Distrito = distrito;
            this.OtrasSeñas = otrasSenas;
        }

        public BLDireccion(string provincia, string canton, string distrito)
        {
            this.Provincia = provincia;
            this.Canton = canton;
            this.Distrito = distrito;
        }

    }
}
