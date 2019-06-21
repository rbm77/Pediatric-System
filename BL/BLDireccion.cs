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
        public decimal IdProvincia { get; set; }
        public string Canton { get; set; }
        public decimal IdCanton { get; set; }
        public string Distrito { get; set; }
        public decimal IdDistrito { get; set; }
        public string Barrio { get; set; }
        public decimal IdBarrio { get; set; }

        public BLDireccion()
        {

        }

        public BLDireccion(string provincia, decimal idPro, string canton, decimal idCan, string distrito, decimal idDis, string barrio, decimal idBar)
        {
            this.Provincia = provincia;
            this.IdProvincia = idPro;
            this.Canton = canton;
            this.IdCanton = idCan;
            this.Distrito = distrito;
            this.IdDistrito = idDis;
            this.Barrio = barrio;
            this.IdBarrio = idBar;
        }

        public BLDireccion(string provincia, decimal idPro, string canton, decimal idCan, string distrito, decimal idDis)
        {
            this.Provincia = provincia;
            this.IdProvincia = idPro;
            this.Canton = canton;
            this.IdCanton = idCan;
            this.Distrito = distrito;
            this.IdDistrito = idDis;
        }

    }
}
