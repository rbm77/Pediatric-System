using System;
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

        /// <summary>
        /// Inserta un usuario personal de tipo administrativo
        /// </summary>
        public void insertarAdministrativo()
        {
            miTOAdministrativo.correo = this.correo;
            miTOAdministrativo.nombre = this.nombre;
            miTOAdministrativo.apellido = this.apellido;
            miTOAdministrativo.cedula = this.cedula;
            miTOAdministrativo.telefono = this.telefono;
            miDAOAdministrativo.insertarAdministrativo(miTOAdministrativo);
        }

        /// <summary>
        /// Busca un Administrador basaco en un correo
        /// </summary>
        public void buscarAdministrativo()
        {
            miTOAdministrativo.correo = this.correo;
            miDAOAdministrativo.buscarAdministrativo(miTOAdministrativo);
            this.nombre = miTOAdministrativo.nombre;
            this.apellido = miTOAdministrativo.apellido;
            this.cedula = miTOAdministrativo.cedula;
            this.telefono = miTOAdministrativo.telefono;
        }

        /// <summary>
        /// Edita un administrador basado en un correo
        /// </summary>
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
