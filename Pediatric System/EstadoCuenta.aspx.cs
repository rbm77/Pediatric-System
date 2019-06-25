using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BL;

namespace Pediatric_System
{
    public partial class EstadoCuenta : System.Web.UI.Page
    {
        public List<BL_ManejadorPersonal> listaPersonal = new List<BL_ManejadorPersonal>();
        BLPersonal miBLPersonal = new BLPersonal();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                listaPersonal = miBLPersonal.buscarListaPersonal();
                //bind the gridview data
                gridCuentas.DataSource = listaPersonal;
                gridCuentas.DataBind();
            }

        }




    
        //public List<BL_ManejadorPersonal> retornarLista()
        //{
        //    return 
        //}
    }
}