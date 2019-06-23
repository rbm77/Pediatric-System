using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAO;
using TO;

namespace BL
{
    public class ManejadorExpediente
    {
        public string crearExpediente(string nombre, string primerApellido, string segundoApellido, string cedula, DateTime fechaNacimiento, string sexo, byte[] foto, string expedienteAnti)
        {
            TOExpediente nuevoExpediente = new TOExpediente(nombre, primerApellido, segundoApellido, cedula, fechaNacimiento, sexo, foto, expedienteAnti);
            DAOExpediente dao = new DAOExpediente();
            string confirmacion = dao.CrearExpediente(nuevoExpediente);
            return confirmacion;

        }
    }
}
