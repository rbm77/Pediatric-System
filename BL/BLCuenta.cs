using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TO;
using DAO;

namespace BL
{
    public class BLCuenta
    {

        public string correo;
        public string contrasena;
        public string tipo;
        public string estado;

        TOCuenta miTOCuenta = new TOCuenta();
        DAOCuenta miDAOCuenta = new DAOCuenta();



        public string insertarCuenta()
        {
            string confirmacion = "Error";
            miTOCuenta.correo = this.correo;
            miTOCuenta.contrasena = this.contrasena;
            miTOCuenta.tipo = this.tipo;
            miTOCuenta.estado = "Activo";
            confirmacion = miDAOCuenta.InsertarCuenta(miTOCuenta);
            return confirmacion;

        }


        public void buscar()
        {
            miTOCuenta.correo = this.correo;
            miTOCuenta.contrasena = this.contrasena;
            miDAOCuenta.buscarCuentaConContraseña(miTOCuenta);
            this.tipo = miTOCuenta.tipo;
            this.estado = miTOCuenta.estado;
        }

        public void actualizarContraseña()
        {
            miTOCuenta.correo = this.correo;
            miTOCuenta.contrasena = this.contrasena;
            miDAOCuenta.recuperarContraseña(miTOCuenta);
        }
    }


}
