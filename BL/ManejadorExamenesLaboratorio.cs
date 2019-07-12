using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using TO;

namespace BL
{
    public class ManejadorExamenesLaboratorio
    {
        public ManejadorExamenesLaboratorio()
        {

        }

        /// <summary>
        /// Carga la lista de examenes de laboratorio de un paciente
        /// </summary>
        /// <param name="blExamenes"></param>
        /// <param name="idExpediente"></param>
        /// <returns>Retorna un mensaje de confirmacion</returns>
        public string CargarExamenesLaboratorio(List<BLExamenLaboratorio> blExamenes, string idExpediente)
        {
            string confirmacion = "error";

            DAOExamenLaboratorio dao = new DAOExamenLaboratorio();

            List<TOExamenLaboratorio> toExamenes = new List<TOExamenLaboratorio>();

            confirmacion = dao.CargarExamenesLaboratorio(toExamenes, idExpediente);

            foreach (TOExamenLaboratorio exa in toExamenes)
            {
                blExamenes.Add(new BLExamenLaboratorio(exa.IDExpediente, exa.Fecha, exa.UbicacionArchivo, exa.Descripcion));
            }

            return confirmacion;
        }

        /// <summary>
        /// Ingresa una nueva cita al sistema
        /// </summary>
        /// <param name="codigoMedico">Código del Médico</param>
        /// <param name="nombre">Nombre Completo</param>
        /// <param name="correo">Correo Electrónico</param>
        /// <param name="telefono">Teléfono</param>
        /// <param name="fecha">Fecha</param>
        /// <param name="hora">Hora</param>
        /// <returns>Retorna un mensaje de confirmación indicando si se realizó la transacción</returns>
        public string IngresarExamenLaboratorio(string idExpediente, string fecha, string ubicacion, string descripcion)
        {
            TOExamenLaboratorio examen = new TOExamenLaboratorio(idExpediente, fecha, ubicacion, descripcion);
            DAOExamenLaboratorio dao = new DAOExamenLaboratorio();
            String confirmacion = dao.IngresarExamenLaboratorio(examen);
            return confirmacion;
        }

    }
}
