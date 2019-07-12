using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pediatric_System
{
    public partial class RecuperarImagen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            try
            {

                string filename = Session["examenSeleccionado"].ToString();

                Response.Clear();
                Response.AddHeader("content-disposition", string.Format("inline;filename={0}", filename));
                //Response.AddHeader("content-disposition", string.Format("attachment;filename={0}", filename));

                switch (Path.GetExtension(filename).ToLower())
                {
                    case ".jpg":
                        Response.ContentType = "image/jpg";
                        break;
                    case ".png":
                        Response.ContentType = "image/png";
                        break;
                    case ".jpeg":
                        Response.ContentType = "image/jpeg";
                        break;
                }

                Response.WriteFile(Server.MapPath(Path.Combine("~/examenes", filename)));
                Response.End();
            }
            catch (Exception)
            {
                
            }
        }
    }
}