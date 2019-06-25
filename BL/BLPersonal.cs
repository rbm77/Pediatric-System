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



        public void insertarPersonal()
        {
            miTOPersonal.correo = this.correo;
            miTOPersonal.nombre = this.nombre;
            miTOPersonal.apellido = this.apellido;
            miTOPersonal.cedula = this.cedula;
            miTOPersonal.telefono = this.telefono;
            miDAOPersonal.insertarPersonal(miTOPersonal);
        }


        public void editarPersonal()
        {
            miTOPersonal.correo = this.correo;
            miTOPersonal.nombre = this.nombre;
            miTOPersonal.apellido = this.apellido;
            miTOPersonal.cedula = this.cedula;
            miTOPersonal.telefono = this.telefono;
            miDAOPersonal.editarPersonal(miTOPersonal);
        }

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
                listaPersonal.Add(miPersonal);
            }
            return listaPersonal;
        }
    }
}
