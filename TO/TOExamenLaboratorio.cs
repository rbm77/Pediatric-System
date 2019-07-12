using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TO
{
    public class TOExamenLaboratorio
    {
        public string IDExpediente { get; set; }
        public string Fecha { get; set; }
        public string UbicacionArchivo { get; set; }
        public string Descripcion { get; set; }

        public TOExamenLaboratorio()
        {

        }

        public TOExamenLaboratorio(string idExpediente, string fecha, string ubicacionArchivo, string descripcion)
        {
            this.IDExpediente = idExpediente;
            this.Fecha = fecha;
            this.UbicacionArchivo = ubicacionArchivo;
            this.Descripcion = descripcion;
        }
    }
}
