using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using TO;

namespace BL
{
    public class ManejadorCita
    {
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
        public string CrearCita(string codigoMedico, string nombre, string edad, string correo, int telefono, string fecha, string hora)
        {
            TOCita nuevaCita = new TOCita(codigoMedico, nombre, edad, correo, telefono, fecha, hora);
            DAOCita dao = new DAOCita();
            String confirmacion = dao.CrearCita(nuevaCita);
            return confirmacion;
        }

        /// <summary>
        /// Obtiene una lista de citas en una fecha particular
        /// </summary>
        /// <param name="blLista">Lista de citas</param>
        /// <param name="codigoMedico">Codigo del medico</param>
        /// <param name="fecha">Fecha de cita</param>
        /// <returns>Retorna un mensaje de confirmacion indicando si se realizo la transaccion</returns>
        public string CargarCitas(List<BLCita> blLista, string codigoMedico, string fecha)
        {
            List<TOCita> toLista = new List<TOCita>();
            DAOCita dao = new DAOCita();
            string confirmacion = dao.CargarCitas(toLista, codigoMedico, fecha);

            foreach (TOCita toCita in toLista)
            {
                blLista.Add(Convertir(toCita));
            }

            return confirmacion;
        }

        /// <summary>
        /// Convierte un objeto TOCita a un objeto BLCita
        /// </summary>
        /// <param name="toCita">CitaTO</param>
        /// <returns>Retorna un nuevo objeto de BLCita</returns>
        private BLCita Convertir(TOCita toCita)
        {
            BLCita blCita = new BLCita(toCita.CodigoMedico, toCita.Nombre, toCita.Edad, toCita.Correo,
                toCita.Telefono, toCita.Fecha, toCita.Hora);
            return blCita;
        }

        /// <summary>
        /// Elimina una cita de la base de datos
        /// </summary>
        /// <param name="codigoMedico"></param>
        /// <param name="fecha"></param>
        /// <param name="hora"></param>
        /// <returns>Retorna un mensaje de confirmacion indicando si se realizo la transaccion</returns>
        public string CancelarCita(string codigoMedico, string fecha, string hora)
        {
            string confirmacion = "error";
            DAOCita dao = new DAOCita();
            confirmacion = dao.CancelarCita(codigoMedico, fecha, hora);
            return confirmacion;
        }

        /// <summary>
        /// Carga el horario de las citas
        /// </summary>
        /// <param name="blLista"></param>
        /// <param name="codigoMedico"></param>
        /// <param name="fecha"></param>
        /// <returns>Retorna un mensaje de confirmacion de la transaccion</returns>
        public string CargarHorasCita(List<BLCita> blLista, string codigoMedico, string fecha)
        {
            string confirmacion = "error";
            DAOCita dao = new DAOCita();
            List<TOCita> toLista = new List<TOCita>();
            confirmacion = dao.CargarHorasCita(toLista, codigoMedico, fecha);

            foreach (TOCita t in toLista)
            {
                blLista.Add(new BLCita(t.Hora));
            }
            return confirmacion;
        }

        /// <summary>
        /// Carga las citas pendientes que se mostraran al usuario
        /// </summary>
        /// <param name="listaNombres"></param>
        /// <param name="listaCitas"></param>
        /// <param name="cuenta"></param>
        /// <returns>Retorna un mensaje de confirmacion de la transaccion</returns>
        public string CargarCitasUsuario(List<BLCita> listaCitas, string cuenta)
        {
            string confirmacion = "error";

            List<TOCita> toCitas = new List<TOCita>();
            DAOCita dao = new DAOCita();
            confirmacion = dao.CargarCitasUsuario(toCitas, cuenta);

            foreach (TOCita cit in toCitas)
            {
                listaCitas.Add(new BLCita(cit.CodigoMedico, cit.NombreMedico, cit.Nombre, cit.Fecha, cit.Hora));
            }

            return confirmacion;
        }

        /// <summary>
        /// Carga la lista de pacientes que pertenecen a una misma cuenta
        /// </summary>
        /// <param name="listaPacientes"></param>
        /// <param name="cuenta"></param>
        /// <returns>Retorna un mensaje de confirmacion</returns>
        public string CargarPacientes(List<BLPacienteCita> listaPacientes, string cuenta)
        {
            string confirmacion = "error";

            DAOCita dao = new DAOCita();

            List<TOPacienteCita> toPacientes = new List<TOPacienteCita>();

            confirmacion = dao.CargarPacientes(toPacientes, cuenta);

            foreach (TOPacienteCita p in toPacientes)
            {
                listaPacientes.Add(new BLPacienteCita(p.NombrePaciente, p.EdadPaciente, p.CorreoEncargado, p.TelefonoEncargado));
            }

            return confirmacion;
        }

    }
}
