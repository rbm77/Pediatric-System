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

        public string CargarCitas(List<BLCita> blLista, string codigoMedico, string fecha)
        {
            List<TOCita> toLista = new List<TOCita>();
            DAOCita dao = new DAOCita();
            string confirmacion = dao.CargarCitas(toLista, codigoMedico, fecha);

            foreach(TOCita toCita in toLista)
            {
                blLista.Add(Convertir(toCita));
            }

            return confirmacion;
        }

        private BLCita Convertir(TOCita toCita)
        {
            BLCita blCita = new BLCita(toCita.CodigoMedico, toCita.Nombre, toCita.Edad, toCita.Correo,
                toCita.Telefono, toCita.Fecha, toCita.Hora);
            return blCita;
        }
    }
}
