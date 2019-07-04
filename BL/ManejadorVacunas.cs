using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using TO;

namespace BL
{
    public class ManejadorVacunas
    {

        public ManejadorVacunas()
        {

        }

        /// <summary>
        /// Carga el esquema de vacunacion y las aplicaciones
        /// </summary>
        /// <param name="vacunas"></param>
        /// <param name="aplicaciones"></param>
        /// <param name="idExpediente"></param>
        /// <returns>Retorna un mensaje de confirmacion indicando si se realizo la transaccion</returns>
        public string CargarVacunas(List<BLVacuna> vacunas)
        {
            string confirmacion = "error";
            List<TOVacuna> toVacunas = new List<TOVacuna>();

            DAOVacuna dao = new DAOVacuna();

            confirmacion = dao.CargarVacunas(toVacunas);

            foreach (TOVacuna v in toVacunas)
            {
                vacunas.Add(new BLVacuna(v.NombreVacuna, v.Aplicacion1, v.Aplicacion2, v.Aplicacion3, v.Refuerzo1,
                    v.Refuerzo2, v.Refuerzo3));
            }
            return confirmacion;
        }

        /// <summary>
        /// Carga el esquema de vacunacion y las aplicaciones
        /// </summary>
        /// <param name="vacunas"></param>
        /// <param name="aplicaciones"></param>
        /// <param name="idExpediente"></param>
        /// <returns>Retorna un mensaje de confirmacion indicando si se realizo la transaccion</returns>
        public string CargarAplicaciones(List<BLAplicacionVacuna> aplicaciones, string idExpediente)
        {
            string confirmacion = "error";
            List<TOAplicacionVacuna> toAplicaciones = new List<TOAplicacionVacuna>();

            DAOAplicacionVacuna dao = new DAOAplicacionVacuna();

            confirmacion = dao.CargarAplicaciones(toAplicaciones, idExpediente);

            foreach (TOAplicacionVacuna v in toAplicaciones)
            {
                aplicaciones.Add(new BLAplicacionVacuna(v.IDExpediete, v.NombreVacuna, v.Aplicacion1, v.Aplicacion2, v.Aplicacion3, v.Refuerzo1,
                    v.Refuerzo2, v.Refuerzo3));
            }
            return confirmacion;
        }

    }
}
