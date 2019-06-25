﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TO;
using DAO;

namespace BL
{
   public class BLAdministrativo
    {

        public string correo;
        public string nombre;
        public string apellido;
        public int cedula;
        public int telefono;

        TOAdministrativo miTOAdministrativo = new TOAdministrativo();
        DAOAdministrativo miDAOAdministrativo = new DAOAdministrativo();


        public void insertarAdministrativo()
        {
            miTOAdministrativo.correo = this.correo;
            miTOAdministrativo.nombre = this.nombre;
            miTOAdministrativo.apellido = this.apellido;
            miTOAdministrativo.cedula = this.cedula;
            miTOAdministrativo.telefono = this.telefono;
            miDAOAdministrativo.insertarAdministrativo(miTOAdministrativo);
        }

        public void buscarAdministrativo()
        {
            miTOAdministrativo.correo = this.correo;
            miDAOAdministrativo.buscarAdministrativo(miTOAdministrativo);
            this.nombre = miTOAdministrativo.nombre;
            this.apellido = miTOAdministrativo.apellido;
            this.cedula = miTOAdministrativo.cedula;
            this.telefono = miTOAdministrativo.telefono;
        }

        public void editarAdministrativo()
        {
            miTOAdministrativo.correo = this.correo;
            miTOAdministrativo.nombre = this.nombre;
            miTOAdministrativo.apellido = this.apellido;
            miTOAdministrativo.cedula = this.cedula;
            miTOAdministrativo.telefono = this.telefono;
            miDAOAdministrativo.editarAdministrativo(miTOAdministrativo);
        }
    }
}