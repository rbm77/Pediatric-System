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


        /// <summary>
        /// Inserta una cuenta en la Base de Datos
        /// </summary>
        /// <returns>Retorna un mensaje de confirmacion o Error en caso de no poder insertar la cuenta</returns>
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

        /// <summary>
        /// Busca que exista la relacion entre una cuenta y una contraseña
        /// </summary>
        public void buscar()
        {
            miTOCuenta.correo = this.correo;
            miTOCuenta.contrasena = this.contrasena;
            miDAOCuenta.buscarCuentaConContraseña(miTOCuenta);
            this.tipo = miTOCuenta.tipo;
            this.estado = miTOCuenta.estado;
        }

        /// <summary>
        /// Actualiza la contraseña actual de la cuenta por una contraseña nueva autogenerada que es 
        /// enviada al correo para recuperar
        /// </summary>
        public void actualizarContraseña()
        {
            miTOCuenta.correo = this.correo;
            miTOCuenta.contrasena = this.contrasena;
            miDAOCuenta.recuperarContraseña(miTOCuenta);
        }

        /// <summary>
        /// Revisa que la contraseña ingresada sea la correcta de la cuenta que desea editarla
        /// </summary>
        /// <returns>Retorna un valor Boolean en caso de que la contraseña sea correcta o no</returns>
        public Boolean revisarContrasena()
        {
            miTOCuenta.correo = this.correo;
            miTOCuenta.contrasena = this.contrasena;

            return miDAOCuenta.revisarContrasena(miTOCuenta);
        }

        /// <summary>
        /// Actualiza la contraseña de una cuenta segun una nueva contraseña ingresada
        /// </summary>
        public void editarContrasena()
        {
            miTOCuenta.correo = this.correo;
            miTOCuenta.contrasena = this.contrasena;

            miDAOCuenta.editarContrasena(miTOCuenta);
        }
       
    }


}
