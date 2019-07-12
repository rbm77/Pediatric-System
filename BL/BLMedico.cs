using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TO;
using DAO;

namespace BL
{
    public class BLMedico
    {
        public string codigo;
        public string correo;
        public string nombre;
        public string apellido;
        public int cedula;
        public int telefono;

        public BLMedico()
        {

        }
        public BLMedico(string codigo, string nombre, string apellido)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.apellido = apellido;
        }

        TOMedico miTOMedico = new TOMedico();
        DAOMedico miDAOMedico = new DAOMedico();

        /// <summary>
        /// Inserta un Medico dentro de la base de datos
        /// </summary>
        public void insertarMedico()
        {
            miTOMedico.codigo = this.codigo;
            miTOMedico.correo = this.correo;
            miTOMedico.nombre = this.nombre;
            miTOMedico.apellido = this.apellido;
            miTOMedico.cedula = this.cedula;
            miTOMedico.telefono = this.telefono;
            miDAOMedico.insertarMedico(miTOMedico);
        }

        /// <summary>
        /// Busca un medico segun su correo asignado
        /// </summary>
        public void buscarMedico()
        {
            miTOMedico.correo = this.correo;
            miDAOMedico.buscarMedico(miTOMedico);
            this.nombre = miTOMedico.nombre;
            this.apellido = miTOMedico.apellido;
            this.cedula = miTOMedico.cedula;
            this.telefono = miTOMedico.telefono;
            this.codigo = miTOMedico.codigo;
        }

        /// <summary>
        /// Edita un medico segun el correo asignado
        /// </summary>
        public void editarMedico()
        {
            miTOMedico.codigo = this.codigo;
            miTOMedico.correo = this.correo;
            miTOMedico.nombre = this.nombre;
            miTOMedico.apellido = this.apellido;
            miTOMedico.cedula = this.cedula;
            miTOMedico.telefono = this.telefono;
            miDAOMedico.editarMedico(miTOMedico);
        }

        /// <summary>
        /// Carga la lista de medicos disponibles para atender consultas
        /// </summary>
        /// <param name="blLista"></param>
        /// <returns>Retorna un mensaje de confirmacion indicando si se realizo la transaccion</returns>
        public string CargarMedicos(List<BLMedico> blLista)
        {
            string confirmacion = "error";

            DAOMedico dao = new DAOMedico();
            List<TOMedico> toLista = new List<TOMedico>();
            confirmacion = dao.CargarMedicos(toLista);


            // Conversion y carga de listas

            foreach (TOMedico med in toLista)
            {
                blLista.Add(new BLMedico(med.codigo, med.nombre, med.apellido));
            }
            return confirmacion;
        }

        /// <summary>
        /// Obtiene el nombre de un medico de acuerdo a su codigo
        /// </summary>
        /// <param name="codigoMedico"></param>
        /// <param name="nombreCompleto"></param>
        /// <returns>Retorna un mensaje de confirmacion indicando si se realizo la transaccion</returns>
        public string buscarNombreMedico(string codigoMedico, string nombreCompleto)
        {
            DAOMedico dao = new DAOMedico();
            string confirmacion = dao.buscarNombreMedico(codigoMedico, nombreCompleto);
            return confirmacion;
        }
    }
}
