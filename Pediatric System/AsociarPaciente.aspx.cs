using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using System.Text;

namespace Pediatric_System
{
    public partial class AsociarPaciente : System.Web.UI.Page
    {
        public List<BL_Manejador_Cuentas> listaPersonal = new List<BL_Manejador_Cuentas>();

        BLCuenta miBLCuenta = new BLCuenta();
    
        protected void Page_Load(object sender, EventArgs e)
        {
            mensajeConfirmacion.Visible = false;
            if (!Page.IsPostBack)
            {
                listaPersonal = miBLCuenta.buscarListaCuentas();
                gridCuentas.DataSource = listaPersonal;
                gridCuentas.DataBind();
            }
        }



        protected void gridCuentas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AsociarExpediente")
            {
                int indice = Convert.ToInt32(e.CommandArgument);
                GridViewRow filaSeleccionada = gridCuentas.Rows[indice];
                TableCell estado = filaSeleccionada.Cells[0];
                string correo = estado.Text;
                lblCorreo.Text = correo;
                Session["CuentaParaAsociar"] = correo;
                Response.Redirect("SelecionExpedientes.aspx");
        
        //ManejadorExpediente manejador = new ManejadorExpediente();
        //List<BLExpediente> expedientes = new List<BLExpediente>();
        //manejador.cargarListaExpedientes(expedientes, true);
        //gridExpedientes.DataSource = expedientes;
        //gridExpedientes.DataBind();
        //modalExpedientes.Show();
    }
        }


        protected void grdExpedientes(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text;
            string contrasena = CrearPassword(7);
            string tipo = "Paciente";
            BLCuenta miBLCuenta = new BLCuenta();
            miBLCuenta.correo = correo;
            miBLCuenta.contrasena = contrasena;
            miBLCuenta.tipo = tipo;
            String mensaje = miBLCuenta.insertarCuenta();
           if (mensaje == "Correcto")
            {
                mensajeAviso("success", "La cuenta se creó correctamente");
                listaPersonal = miBLCuenta.buscarListaCuentas();
                gridCuentas.DataSource = listaPersonal;
                gridCuentas.DataBind();
                BLEnviarCorreo miEnviar = new BLEnviarCorreo(correo, "Bienvenido a PediatricSystem", "Bienvenido a Pediatric System \nLa aplicación para utilizar el sistema de la Clínica Pediátrica Divino Niño, su cuenta posee el rol de Paciente y su contraseña es: " + contrasena + "\nLe recomendamos cambiar su contraseña al iniciar sesión para mas seguridad");
            } else
            {
                mensajeAviso("danger", "La cuenta no se pudo crear debido a que el correo ingresado ya esta en uso");
            }
        }





        public void mensajeAviso(String color, String texto)
        {
            //Colores:  primary = Azul
            //          secondary = Gris
            //          success = Verde
            //          danger = Rojo
            //          warning = Amarillo
            mensajeConfirmacion.Text = "<div class=\"alert alert-" + color + " alert-dismissible fade show\" " +
           "role=\"alert\"> <strong></strong>" + texto + "<button" +
         " type = \"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">" +
         " <span aria-hidden=\"true\">&times;</span> </button> </div>";
            mensajeConfirmacion.Visible = true;
        }


        public string CrearPassword(int longitud)
        {
            string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < longitud--)
            {
                res.Append(caracteres[rnd.Next(caracteres.Length)]);
            }
            return res.ToString();
        }

        protected void Regresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx");
        }
    }
}