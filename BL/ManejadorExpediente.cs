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
        public string crearExpediente(BLExpediente expedienteBL, BLDireccion direccionPacienteBL, BLDireccion direccionEncargadoBL, BLDireccion direccionFacturanteBL, BLEncargado_Facturante encargadoBL, BLEncargado_Facturante facturanteBL, BLHistoriaClinica historiaClinicaBL)
        {
            TOExpediente expedienteTO = new TOExpediente();
            TODireccion direccionPacienteTO = new TODireccion();
            TODireccion direccionEncargadoTO = new TODireccion();
            TODireccion direccionFacturanteTO = new TODireccion();
            TOEncargado_Facturante encargadoTO = new TOEncargado_Facturante ();
            TOEncargado_Facturante facturanteTO = new TOEncargado_Facturante();
            TOHistoriaClinica historiaClinicaTO = new TOHistoriaClinica();

            convertirExpedienteCompleto_BL_TO(expedienteBL, direccionPacienteBL, encargadoBL, direccionEncargadoBL, facturanteBL, direccionFacturanteBL, historiaClinicaBL, expedienteTO, direccionPacienteTO, encargadoTO, direccionEncargadoTO, facturanteTO, direccionFacturanteTO, historiaClinicaTO);

            DAOExpediente dao = new DAOExpediente();
            string confirmacion = dao.CrearExpediente(expedienteTO, direccionPacienteTO, direccionEncargadoTO, direccionFacturanteTO, encargadoTO, facturanteTO, historiaClinicaTO);
            return confirmacion;

        }

        public string actualizarExpediente(BLExpediente expedienteBL, BLDireccion direccionPacienteBL, BLDireccion direccionEncargadoBL, BLDireccion direccionFacturanteBL, BLEncargado_Facturante encargadoBL, BLEncargado_Facturante facturanteBL, BLHistoriaClinica historiaClinicaBL)
        {
            TOExpediente expedienteTO = new TOExpediente();
            TODireccion direccionPacienteTO = new TODireccion();
            TODireccion direccionEncargadoTO = new TODireccion();
            TODireccion direccionFacturanteTO = new TODireccion();
            TOEncargado_Facturante encargadoTO = new TOEncargado_Facturante();
            TOEncargado_Facturante facturanteTO = new TOEncargado_Facturante();
            TOHistoriaClinica historiaClinicaTO = new TOHistoriaClinica();

            convertirExpedienteCompleto_BL_TO(expedienteBL, direccionPacienteBL, encargadoBL, direccionEncargadoBL, facturanteBL, direccionFacturanteBL, historiaClinicaBL, expedienteTO, direccionPacienteTO, encargadoTO, direccionEncargadoTO, facturanteTO, direccionFacturanteTO, historiaClinicaTO);

            DAOExpediente dao = new DAOExpediente();
            string confirmacion = dao.ActualizarExpediente(expedienteTO, direccionPacienteTO, direccionEncargadoTO, direccionFacturanteTO, encargadoTO, facturanteTO, historiaClinicaTO);
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

        public string cargarListaExpedientes(List<BLExpediente> blExpedientes, Boolean value)
        {
            List<TOExpediente> toExpedientes = new List<TOExpediente>();
            DAOExpediente daoExpedientes = new DAOExpediente();

            string confirmacion = daoExpedientes.CargarListaExpedientesSinCorreo(toExpedientes);

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
            BLExpediente blExpediente = new BLExpediente(toExpediente.Codigo, toExpediente.Nombre, toExpediente.PrimerApellido, toExpediente.SegundoApellido, toExpediente.Cedula, toExpediente.FechaNacimiento, toExpediente.Sexo, toExpediente.Foto, toExpediente.ExpedienteAntiguo, toExpediente.Direccion);
            return blExpediente;
        }

        public string mostrarExpediente(string codigoExpediente, BLExpediente expedienteBL, BLDireccion direccionPacienteBL, BLEncargado_Facturante encargadoBL, BLDireccion direccionEncargadoBL, BLEncargado_Facturante facturanteBL, BLDireccion direccionFacturanteBL, BLHistoriaClinica historiaClinicaBL)
        {
            DAOExpediente daoExpediente = new DAOExpediente();

            TOExpediente expedienteTO = new TOExpediente();
            TODireccion direccionPacienteTO = new TODireccion();
            TOEncargado_Facturante encargadoTO = new TOEncargado_Facturante();
            TODireccion direccionEncargadoTO = new TODireccion();
            TOEncargado_Facturante facturanteTO = new TOEncargado_Facturante();
            TODireccion direccionFacturanteTO = new TODireccion();
            TOHistoriaClinica historiaClinicaTO = new TOHistoriaClinica();

            string confirmacion = daoExpediente.CargarExpediente(codigoExpediente, expedienteTO, direccionPacienteTO, encargadoTO, direccionEncargadoTO, facturanteTO, direccionFacturanteTO, historiaClinicaTO);

            convertirExpedienteCompleto_TO_BL(expedienteBL, direccionPacienteBL, encargadoBL, direccionEncargadoBL, facturanteBL, direccionFacturanteBL, historiaClinicaBL, expedienteTO, direccionPacienteTO, encargadoTO, direccionEncargadoTO, facturanteTO, direccionFacturanteTO, historiaClinicaTO);

            return confirmacion;
        }

        private void convertirExpedienteCompleto_TO_BL(BLExpediente expedienteBL, BLDireccion direccionPacienteBL, BLEncargado_Facturante encargadoBL, BLDireccion direccionEncargadoBL, BLEncargado_Facturante facturanteBL, BLDireccion direccionFacturanteBL, BLHistoriaClinica historiaClinicaBL,
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
            expedienteBL.Codigo = expediente.Codigo;

            //Objeto Direccion Paciente
            direccionPacienteBL.Codigo = direccionPaciente.Codigo;
            direccionPacienteBL.Provincia = direccionPaciente.Provincia;
            direccionPacienteBL.Canton = direccionPaciente.Canton;
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
            direccionFacturanteBL.Canton = direccionFacturante.Canton;
            direccionFacturanteBL.Distrito = direccionFacturante.Distrito;
            direccionFacturanteBL.Barrio = direccionFacturante.Barrio;

            //Objeto Historia Clinica 
            historiaClinicaBL.Codigo = historiaClinica.Codigo;
            historiaClinicaBL.AP_Talla = historiaClinica.AP_Talla;
            historiaClinicaBL.AP_Peso = historiaClinica.AP_Peso;
            historiaClinicaBL.AP_PerimetroCefalico = historiaClinica.AP_PerimetroCefalico;
            historiaClinicaBL.AP_CalificacionUniversal = historiaClinica.AP_CalificacionUniversal;
            historiaClinicaBL.AP_APGAR = historiaClinica.AP_APGAR;
            historiaClinicaBL.AP_EdadGestacional = historiaClinica.AP_EdadGestacional;
            historiaClinicaBL.AP_OtrasComplicaciones = historiaClinica.AP_OtrasComplicaciones;
            historiaClinicaBL.AP_OtrasComplicacionesDescripcion = historiaClinica.AP_OtrasComplicacionesDescripcion;
            historiaClinicaBL.HF_Asma = historiaClinica.HF_Asma;
            historiaClinicaBL.HF_Diabetes = historiaClinica.HF_Diabetes;
            historiaClinicaBL.HF_Hipertension = historiaClinica.HF_Hipertension;
            historiaClinicaBL.HF_Cardivasculares = historiaClinica.HF_Cardivasculares;
            historiaClinicaBL.HF_Displidemia = historiaClinica.HF_Displidemia;
            historiaClinicaBL.HF_Epilepsia = historiaClinica.HF_Epilepsia;
            historiaClinicaBL.HF_Otros = historiaClinica.HF_Otros;
            historiaClinicaBL.HF_DescripcionOtros = historiaClinica.HF_DescripcionOtros;
            historiaClinicaBL.APAT_Estado = historiaClinica.APAT_Estado;
            historiaClinicaBL.APAT_Descripcion = historiaClinica.APAT_Descripcion;
            historiaClinicaBL.AT_Estado = historiaClinica.AT_Estado;
            historiaClinicaBL.AT_Descripcion = historiaClinica.AT_Descripcion;
            historiaClinicaBL.AQ_Estado = historiaClinica.AQ_Estado;
            historiaClinicaBL.AQ_Descripcion = historiaClinica.AQ_Descripcion;
            historiaClinicaBL.Alergias = historiaClinica.Alergias;
            historiaClinicaBL.AlegergiasDescripcion = historiaClinica.AlegergiasDescripcion;

        }

        private void convertirExpedienteCompleto_BL_TO(BLExpediente expedienteBL, BLDireccion direccionPacienteBL, BLEncargado_Facturante encargadoBL, BLDireccion direccionEncargadoBL, BLEncargado_Facturante facturanteBL, BLDireccion direccionFacturanteBL, BLHistoriaClinica historiaClinicaBL,
            TOExpediente expediente, TODireccion direccionPaciente, TOEncargado_Facturante encargado, TODireccion direccionEncargado, TOEncargado_Facturante facturante, TODireccion direccionFacturante, TOHistoriaClinica historiaClinica)
        {
            //Objeto Expediente
            expediente.Codigo = expedienteBL.Codigo;
            expediente.Cedula = expedienteBL.Cedula;
            expediente.Nombre = expedienteBL.Nombre;
            expediente.PrimerApellido = expedienteBL.PrimerApellido;
            expediente.SegundoApellido = expedienteBL.SegundoApellido;
            expediente.FechaNacimiento = expedienteBL.FechaNacimiento;
            expediente.Sexo = expedienteBL.Sexo;
            expediente.Foto = expedienteBL.Foto;
            expediente.ExpedienteAntiguo = expedienteBL.ExpedienteAntiguo;
            expediente.Direccion = expedienteBL.Direccion;

            //Objeto Direccion Paciente
            direccionPaciente.Codigo = direccionPacienteBL.Codigo;
            direccionPaciente.Provincia = direccionPacienteBL.Provincia;
            direccionPaciente.Canton = direccionFacturanteBL.Canton;
            direccionPaciente.Distrito = direccionPacienteBL.Distrito;

            //Objeto Encargado 
            encargado.Cedula = encargadoBL.Cedula;
            encargado.Nombre = encargadoBL.Nombre;
            encargado.PrimerApellido = encargadoBL.PrimerApellido;
            encargado.SegundoApellido = encargadoBL.SegundoApellido;
            encargado.Parentesco = encargadoBL.Parentesco;
            encargado.CorreoElectronico = encargadoBL.CorreoElectronico;
            encargado.Telefono = encargadoBL.Telefono;
            encargado.Direccion = encargadoBL.Direccion;

            //Objeto Direccion Encargado
            direccionEncargado.Codigo = direccionEncargadoBL.Codigo;
            direccionEncargado.Provincia = direccionEncargadoBL.Provincia;
            direccionEncargado.Canton = direccionEncargadoBL.Canton;
            direccionEncargado.Distrito = direccionEncargadoBL.Distrito;
            direccionEncargado.Barrio = direccionEncargadoBL.Barrio;

            //Objeto Facturante 
            facturante.Cedula = facturanteBL.Cedula;
            facturante.Nombre = facturanteBL.Nombre;
            facturante.PrimerApellido = facturanteBL.PrimerApellido;
            facturante.SegundoApellido = facturanteBL.SegundoApellido;
            facturante.CorreoElectronico = facturanteBL.CorreoElectronico;
            facturante.Telefono = facturanteBL.Telefono;
            facturante.Direccion = facturanteBL.Direccion;

            //Objeto Direccion Facturante 
            direccionFacturante.Codigo = direccionFacturanteBL.Codigo;
            direccionFacturante.Provincia = direccionFacturanteBL.Provincia;
            direccionFacturante.Canton = direccionFacturanteBL.Distrito;
            direccionFacturante.Distrito = direccionFacturanteBL.Distrito;
            direccionFacturante.Barrio = direccionFacturanteBL.Barrio;

            //Objeto Historia Clinica 
            historiaClinica.Codigo = historiaClinicaBL.Codigo;
            historiaClinica.AP_Talla = historiaClinicaBL.AP_Talla;
            historiaClinica.AP_Peso = historiaClinicaBL.AP_Peso;
            historiaClinica.AP_PerimetroCefalico = historiaClinicaBL.AP_PerimetroCefalico;
            historiaClinica.AP_CalificacionUniversal = historiaClinicaBL.AP_CalificacionUniversal;
            historiaClinica.AP_APGAR = historiaClinicaBL.AP_APGAR;
            historiaClinica.AP_EdadGestacional = historiaClinicaBL.AP_EdadGestacional;
            historiaClinica.AP_OtrasComplicaciones = historiaClinicaBL.AP_OtrasComplicaciones;
            historiaClinica.AP_OtrasComplicacionesDescripcion = historiaClinicaBL.AP_OtrasComplicacionesDescripcion;
            historiaClinica.HF_Asma = historiaClinicaBL.HF_Asma;
            historiaClinica.HF_Diabetes = historiaClinicaBL.HF_Diabetes;
            historiaClinica.HF_Hipertension = historiaClinicaBL.HF_Hipertension;
            historiaClinica.HF_Cardivasculares = historiaClinicaBL.HF_Cardivasculares;
            historiaClinica.HF_Displidemia = historiaClinicaBL.HF_Displidemia;
            historiaClinica.HF_Epilepsia = historiaClinicaBL.HF_Epilepsia;
            historiaClinica.HF_Otros = historiaClinicaBL.HF_Otros;
            historiaClinica.HF_DescripcionOtros = historiaClinicaBL.HF_DescripcionOtros;
            historiaClinica.APAT_Estado = historiaClinicaBL.APAT_Estado;
            historiaClinica.APAT_Descripcion = historiaClinicaBL.APAT_Descripcion;
            historiaClinica.AT_Estado = historiaClinicaBL.AT_Estado;
            historiaClinica.AT_Descripcion = historiaClinicaBL.AT_Descripcion;
            historiaClinica.AQ_Estado = historiaClinicaBL.AQ_Estado;
            historiaClinica.AQ_Descripcion = historiaClinicaBL.AQ_Descripcion;
            historiaClinica.Alergias = historiaClinicaBL.Alergias;
            historiaClinica.AlegergiasDescripcion = historiaClinicaBL.AlegergiasDescripcion;

        }

        public int contarExpediente()
        {
            DAOExpediente daoExpediente = new DAOExpediente();
            return daoExpediente.contarExpedientes();
        }

        public string asociarCuenta(String correoCuenta, String cedulaExpediente)
        {
            DAOExpediente daoExpediente = new DAOExpediente();
            String mensaje = daoExpediente.asociarCorreo(correoCuenta, cedulaExpediente);
            return mensaje;
        }
    }
}
