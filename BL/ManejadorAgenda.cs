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
        public string ActualizarAgenda(List<BLAgendaEstandar> agenda, string codigo)
        {
            string confirmacion = "Error";
            DAOAgendaEstandar dao = new DAOAgendaEstandar();
            List<TOAgendaEstandar> toAgenda = Convertir(agenda);
            confirmacion = dao.ActualizarAgenda(toAgenda, codigo);

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

        /// <summary>
        ///  Obtiene los dias laborales del medico y su respectivo horario
        /// </summary>
        /// <param name="diaSeleccionado">Dia seleccionado</param>
        /// <returns>Retorna un mensaje de confirmacion indicando si se realizo la transaccion</returns>
        public string CargarDisponibilidad(BLAgendaEstandar diaSeleccionado)
        {
            string confirmacion = "Error";
            DAOAgendaEstandar dao = new DAOAgendaEstandar();
            TOAgendaEstandar toDisponibilidad = new TOAgendaEstandar();
            toDisponibilidad.CodigoMedico = diaSeleccionado.CodigoMedico;
            toDisponibilidad.Dia = diaSeleccionado.Dia;
            confirmacion = dao.CargarDisponibilidad(toDisponibilidad);
            diaSeleccionado.HoraInicio = toDisponibilidad.HoraInicio;
            diaSeleccionado.HoraFin = toDisponibilidad.HoraFin;
            return confirmacion;
        }
    }
}
