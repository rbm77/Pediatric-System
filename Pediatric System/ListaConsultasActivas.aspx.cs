using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pediatric_System
{
    public partial class ListaConsultasActivas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gridConsultasActivas_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void regresar_Click(object sender, EventArgs e)
        {

        }

        private class ListaItem
        {
            public DateTime Fecha { get; set; }
            public string Doctor { get; set; }
            public string Estado { get; set; }

            public ListaItem()
            {

            }
            public ListaItem(DateTime fecha, string Doctor, string estado)
            {
                this.Fecha = fecha;
                this.Doctor = Doctor;
                this.Estado = estado;
            }
        }
    }
}