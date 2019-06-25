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
        /// <summary>
        /// Envia los datos a la capa de DAO para realizar la inserccion en la tabla Expediente de la BD
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="primerApellido"></param>
        /// <param name="segundoApellido"></param>
        /// <param name="cedula"></param>
        /// <param name="fechaNacimiento"></param>
        /// <param name="sexo"></param>
        /// <param name="foto"></param>
        /// <param name="expedienteAnti"></param>
        /// <returns>Mensaje de confirmacion indicando si se realizo la transaccion</returns>
        public string crearExpediente(string nombre, string primerApellido, string segundoApellido, string cedula, DateTime fechaNacimiento, string sexo, byte[] foto, string expedienteAnti)
        {
            TOExpediente nuevoExpediente = new TOExpediente(nombre, primerApellido, segundoApellido, cedula, fechaNacimiento, sexo, foto, expedienteAnti);
            DAOExpediente dao = new DAOExpediente();
            string confirmacion = dao.CrearExpediente(nuevoExpediente);
            return confirmacion;

        }

        /// <summary>
        /// Obtiene una lista de objetos Expediente que son enviados desde la capa DAO 
        /// </summary>
        /// <param name="blExpedientes"></param>
        /// <returns>Mensaje de confirmacion indicando si se realizo la transaccion</returns>
        public string cargarListaExpedientes(List<BLExpediente> blExpedientes)
        {
            List<TOExpediente> toExpedientes = new List<TOExpediente>();
            DAOExpediente daoExpedientes = new DAOExpediente();

            string confirmacion = daoExpedientes.CargarListaExpedientes(toExpedientes);

            foreach (TOExpediente toExpediente in toExpedientes)
            {
                blExpedientes.Add(convertirExpedientes(toExpediente));
            }

            return confirmacion;
        }

        /// <summary>
        /// Realiza la conversion de objetos Expediente del tipo TOExpediente a BLExpediente
        /// </summary>
        /// <param name="toExpediente"></param>
        /// <returns>El objeto de tipo BLExpediente convertido</returns>
        private BLExpediente convertirExpedientes(TOExpediente toExpediente)
        {
            BLExpediente blExpediente = new BLExpediente(toExpediente.Nombre, toExpediente.PrimerApellido, toExpediente.SegundoApellido, toExpediente.Cedula, toExpediente.FechaNacimiento, toExpediente.Sexo, toExpediente.Foto, toExpediente.ExpedienteAntiguo);
            return blExpediente;
        }
    }
}
