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
        /// <param name="expedienteBL"></param>
        /// <returns>Mensaje de confirmacion indicando si se realizo la transaccion</returns>
        public string crearExpediente(BLExpediente expedienteBL)
        {
            TOExpediente nuevoExpediente = new TOExpediente(expedienteBL.Nombre, expedienteBL.PrimerApellido, expedienteBL.SegundoApellido, expedienteBL.Cedula, expedienteBL.FechaNacimiento, expedienteBL.Sexo, expedienteBL.Foto, expedienteBL.ExpedienteAntiguo, expedienteBL.Direccion);
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
            BLExpediente blExpediente = new BLExpediente(toExpediente.Nombre, toExpediente.PrimerApellido, toExpediente.SegundoApellido, toExpediente.Cedula, toExpediente.FechaNacimiento, toExpediente.Sexo, toExpediente.Foto, toExpediente.ExpedienteAntiguo, toExpediente.Direccion);
            return blExpediente;
        }

        public string mostrarExpediente(string cedulaExpediente, BLExpediente expedienteBL, BLDireccion direccionPacienteBL, BLEncargado_Facturante encargadoBL, BLDireccion direccionEncargadoBL, BLEncargado_Facturante facturanteBL, BLDireccion direccionFacturanteBL, BLHistoriaClinica historiaClinicaBL)
        {
            DAOExpediente daoExpediente = new DAOExpediente();

            TOExpediente expedienteTO = new TOExpediente();
            TODireccion direccionPacienteTO = new TODireccion();
            TOEncargado_Facturante encargadoTO = new TOEncargado_Facturante();
            TODireccion direccionEncargadoTO = new TODireccion();
            TOEncargado_Facturante facturanteTO = new TOEncargado_Facturante();
            TODireccion direccionFacturanteTO = new TODireccion();
            TOHistoriaClinica historiaClinicaTO = new TOHistoriaClinica();

            string confirmacion = daoExpediente.CargarExpediente(cedulaExpediente ,expedienteTO, direccionPacienteTO, encargadoTO, direccionEncargadoTO, facturanteTO, direccionFacturanteTO, historiaClinicaTO);

            return confirmacion;
        }

        private void convertirExpedienteCompleto(BLExpediente expedienteBL, BLDireccion direccionPacienteBL, BLEncargado_Facturante encargadoBL, BLDireccion direccionEncargadoBL, BLEncargado_Facturante facturanteBL, BLDireccion direccionFacturanteBL, BLHistoriaClinica historiaClinicaBL,
            TOExpediente expediente, TODireccion direccionPaciente, TOEncargado_Facturante encargado, TODireccion direccionEncargado, TOEncargado_Facturante facturante, TODireccion direccionFacturante, TOHistoriaClinica historiaClinica)
        {
            //Objeto Expediente
            expedienteBL.Cedula = expediente.Cedula;
            expedienteBL.Nombre = expediente.Nombre;
            expedienteBL.PrimerApellido = expediente.PrimerApellido;
            expedienteBL.SegundoApellido = expediente.SegundoApellido;
            expedienteBL.FechaNacimiento = expediente.FechaNacimiento;
            expedienteBL.Sexo = expediente.Sexo;
            expedienteBL.Foto = expediente.Foto;
            expedienteBL.ExpedienteAntiguo = expediente.ExpedienteAntiguo;

            //Objeto Direccion Paciente
            direccionPacienteBL.Codigo = direccionPaciente.Codigo;
            direccionPacienteBL.Provincia = direccionPaciente.Provincia;
            direccionPacienteBL.Canton = direccionFacturante.Canton;
            direccionPacienteBL.Distrito = direccionPaciente.Distrito;

            //Objeto Encargado 
            encargadoBL.Cedula = encargado.Cedula;
            encargadoBL.Nombre = encargado.Nombre;
            encargadoBL.PrimerApellido = encargado.PrimerApellido;
            encargadoBL.SegundoApellido = encargado.SegundoApellido;
            encargadoBL.Parentesco = encargado.Parentesco;
            encargadoBL.CorreoElectronico = encargado.CorreoElectronico;
            encargadoBL.Telefono = encargado.Telefono;

            //Objeto Direccion Encargado
            direccionEncargadoBL.Codigo = direccionEncargado.Codigo;
            direccionEncargadoBL.Provincia = direccionEncargado.Provincia;
            direccionEncargadoBL.Canton = direccionEncargado.Canton;
            direccionEncargadoBL.Distrito = direccionEncargado.Distrito;
            direccionEncargadoBL.Barrio = direccionEncargado.Barrio;

            //Objeto Facturante 
            facturanteBL.Cedula = facturante.Cedula;
            facturanteBL.Nombre = facturante.Nombre;
            facturanteBL.PrimerApellido = facturante.PrimerApellido;
            facturanteBL.SegundoApellido = facturante.SegundoApellido;
            facturanteBL.CorreoElectronico = facturante.CorreoElectronico;
            facturanteBL.Telefono = facturante.Telefono;

            //Objeto Direccion Facturante 
            direccionFacturanteBL.Codigo = direccionFacturante.Codigo;
            direccionFacturanteBL.Provincia = direccionFacturante.Provincia;
            direccionFacturanteBL.Canton = direccionFacturante.Distrito;
            direccionFacturanteBL.Distrito = direccionFacturanteBL.Distrito;
            
            //Objeto Historia Clinica 

        }
    }
}
