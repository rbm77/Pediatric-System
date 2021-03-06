﻿using System;
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
        public List<BL_Manejador_Cuentas> listaPacientes = new List<BL_Manejador_Cuentas>();
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
            miTOCuenta.estado = "Habilitada";
            confirmacion = miDAOCuenta.InsertarCuenta(miTOCuenta);
            return confirmacion;

        }


        /// <summary>
        /// Busca los datos de una cuenta segun un correo ingresado
        /// </summary>
        public void buscarCuentaPorCorreo()
        {
            miTOCuenta.correo = this.correo;
            miDAOCuenta.buscarCuentaPorCorreo(miTOCuenta);
            this.tipo = miTOCuenta.tipo;
            this.estado = miTOCuenta.estado;
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

        public void editarEstado(String accion)
        {
            miTOCuenta.correo = this.correo;
            miDAOCuenta.editarEstado(miTOCuenta, accion);
        }

        public List<BL_Manejador_Cuentas> buscarListaCuentas()
        {
            List<TOCuenta> listaTransferencia = miDAOCuenta.buscarListaPacientes();
            foreach (var personal in listaTransferencia)
            {
                BL_Manejador_Cuentas miPaciente = new BL_Manejador_Cuentas();
                miPaciente.correo = personal.correo;
                listaPacientes.Add(miPaciente);
            }
            return listaPacientes;
        }

    }


}
