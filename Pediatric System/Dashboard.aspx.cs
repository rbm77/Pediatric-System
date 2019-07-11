using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pediatric_System
{
    public partial class dashboard : System.Web.UI.Page
    {
    
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["pagina"] = "dashboard";
            conteos();
        }

        public void conteos()
        {
            ManejadorExpediente me = new ManejadorExpediente();
            Session["countExpe"] = me.contarExpediente();

        }
       
    }
}