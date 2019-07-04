using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TO;
using DAO;
namespace BL
{
   public class BLPersonal
    {
        TOPersonal miTOPersonal = new TOPersonal();
        DAOPersonal miDAOPersonal = new DAOPersonal();
        public string correo;
        public string nombre;
        public string apellido;
        public int cedula;
        public int telefono;
        public List<BL_ManejadorPersonal> listaPersonal = new List<BL_ManejadorPersonal>();


        /// <summary>
        /// Inserta una cuenta de tipo personal
        /// </summary>
        public void insertarPersonal()
        {
            miTOPersonal.correo = this.correo;
            miTOPersonal.nombre = this.nombre;
            miTOPersonal.apellido = this.apellido;
            miTOPersonal.cedula = this.cedula;
            miTOPersonal.telefono = this.telefono;
            miDAOPersonal.insertarPersonal(miTOPersonal);
        }

        /// <summary>
        /// Edita una cuenta de tipo personal
        /// </summary>
        public void editarPersonal()
        {
            miTOPersonal.correo = this.correo;
            miTOPersonal.nombre = this.nombre;
            miTOPersonal.apellido = this.apellido;
            miTOPersonal.cedula = this.cedula;
            miTOPersonal.telefono = this.telefono;
            miDAOPersonal.editarPersonal(miTOPersonal);
        }

        /// <summary>
        /// Llena una lista con cada una de las cuentas de tipo personal
        /// </summary>
        /// <returns>Retorna la lista con cuentas de personal</returns>
        public List<BL_ManejadorPersonal> buscarListaPersonal()
        {
            List<TOPersonal> listaTransferencia = miDAOPersonal.buscarListaPersonal();
            foreach (var personal in listaTransferencia ) {
                BL_ManejadorPersonal miPersonal = new BL_ManejadorPersonal();
                miPersonal.correo = personal.correo;
                miPersonal.nombre = personal.nombre;
                miPersonal.apellido = personal.apellido;
                miPersonal.cedula = personal.cedula;
                miPersonal.telefono = personal.telefono;
                miPersonal.estado = personal.estado;
                listaPersonal.Add(miPersonal);
            }
            return listaPersonal;
        }
    }
}
