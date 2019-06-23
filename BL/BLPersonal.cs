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

        public string correo;
        public string nombre;
        public string apellido;
        public int cedula;
        public int telefono;

        TOPersonal miTOPersonal = new TOPersonal();
        DAOPersonal miDAOPersonal = new DAOPersonal();


        public void insertarPersonal()
        {
            miTOPersonal.correo = this.correo;
            miTOPersonal.nombre = this.nombre;
            miTOPersonal.apellido = this.apellido;
            miTOPersonal.cedula = this.cedula;
            miTOPersonal.telefono = this.telefono;
            miDAOPersonal.insertarPersonal(miTOPersonal);
        }
    }
}
