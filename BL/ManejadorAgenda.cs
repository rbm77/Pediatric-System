using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using TO;

namespace BL
{
    public class ManejadorAgenda
    {
        public ManejadorAgenda()
        {

        }

        /// <summary>
        /// Actualiza la agenda del medico
        /// </summary>
        /// <param name="agenda">Agenda</param>
        /// <returns>Retorna un mensaje de confirmacion indicando si la transaccion se realizo</returns>
        public string ActualizarAgenda(List<BLAgendaEstandar> agenda)
        {
            string confirmacion = "Error";
            DAOAgendaEstandar dao = new DAOAgendaEstandar();
            List<TOAgendaEstandar> toAgenda = Convertir(agenda);
            confirmacion = dao.ActualizarAgenda(toAgenda);

            // Se limpia y carga la lista de agenda con la nueva actualizacion

            agenda.Clear();

            foreach (TOAgendaEstandar dia in toAgenda)
            {
                agenda.Add(new BLAgendaEstandar(dia.CodigoMedico, dia.Dia, dia.HoraInicio, dia.HoraFin));
            }

            return confirmacion;
        }

        /// <summary>
        /// Convierte una lista de objetos BLAgendaEstandar en una lista de TOAgendaEstandar 
        /// </summary>
        /// <param name="agenda">Agenda</param>
        /// <returns>Retorna una lista de objetos TOAgendaEstandar</returns>
        private List<TOAgendaEstandar> Convertir(List<BLAgendaEstandar> agenda)
        {
            List<TOAgendaEstandar> toAgenda = new List<TOAgendaEstandar>();
            foreach (BLAgendaEstandar dia in agenda)
            {
                toAgenda.Add(new TOAgendaEstandar(dia.CodigoMedico, dia.Dia, dia.HoraInicio, dia.HoraFin));
            }
            return toAgenda;
        }
    }
}
