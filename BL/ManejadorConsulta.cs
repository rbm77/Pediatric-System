using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using TO;

namespace BL
{
    public class ManejadorConsulta
    {
        public string crearConsulta(BLConsulta consulta, BLExamenFisico examenFisico)
        {
            TOConsulta consultaTO = new TOConsulta();
            TOExamenFisico examenFisicoTO = new TOExamenFisico();


            convertirConsultaCompleta_BL_TO(consulta, examenFisico, consultaTO, examenFisicoTO);

            DAOConsulta dao = new DAOConsulta();
            string confirmacion = dao.CrearConsulta(consultaTO, examenFisicoTO);
            return confirmacion;

        }

        public string actualizarConsulta(BLConsulta consulta, BLExamenFisico examenFisico)
        {
            TOConsulta consultaTO = new TOConsulta();
            TOExamenFisico examenFisicoTO = new TOExamenFisico();

            convertirConsultaCompleta_BL_TO(consulta, examenFisico, consultaTO, examenFisicoTO);

            DAOConsulta dao = new DAOConsulta();
            string confirmacion = dao.ActualizarConsulta(consultaTO, examenFisicoTO);
            return confirmacion;
        }

        public string cargarListaConsultas(List<BLConsulta> blConsultas, string codExpediente)
        {
            List<TOConsulta> toConsultas = new List<TOConsulta>();
            DAOConsulta daoConsulta = new DAOConsulta();
            string confirmacion = daoConsulta.CargarListaConsultas(toConsultas, codExpediente);

            foreach (TOConsulta toConsulta in toConsultas)
            {
                blConsultas.Add(convertirConsulta(toConsulta));
            }
            return confirmacion;
        }
        public string cargarListaConsultasFiltrada(List<BLConsulta> blConsultas, string codMedico, string tipoRep, string ini, string fin)
        {
            List<TOConsulta> toConsultas = new List<TOConsulta>();
            DAOConsulta daoConsulta = new DAOConsulta();
            string confirmacion = daoConsulta.CargarListaConsultasFiltrada(toConsultas, codMedico, tipoRep, ini, fin);

            foreach (TOConsulta toConsulta in toConsultas)
            {
                blConsultas.Add(convertirConsulta(toConsulta));
            }
            return confirmacion;
        }

        public  string mostrarConsulta(string codExpediente, DateTime fecha, BLConsulta consultaBL, BLExamenFisico examenFisicoBL)
        {
            TOConsulta consultaTO = new TOConsulta();
            TOExamenFisico examenFisicoTO = new TOExamenFisico();

            DAOConsulta dao = new DAOConsulta();

            string confirmacion = dao.CargarConsulta(codExpediente, fecha, consultaTO, examenFisicoTO);

            convertirConsultaCompleta_TO_BL(consultaBL, examenFisicoBL, consultaTO, examenFisicoTO);

            return confirmacion;
        }

        public string mostrarConsultaFecha(DateTime fecha, BLConsulta consultaBL, BLExamenFisico examenFisicoBL)
        {
            TOConsulta consultaTO = new TOConsulta();
            TOExamenFisico examenFisicoTO = new TOExamenFisico();

            DAOConsulta dao = new DAOConsulta();

            string confirmacion = dao.CargarConsultaFecha(fecha, consultaTO, examenFisicoTO);

            convertirConsultaCompleta_TO_BL(consultaBL, examenFisicoBL, consultaTO, examenFisicoTO);

            return confirmacion;
        }

        public string cambiarEstadoConsulta(BLConsulta consulta)
        {
            TOConsulta consultaTO = new TOConsulta();
            consultaTO.CodigoExpediente = consulta.CodigoExpediente;
            consultaTO.Fecha_Hora = consulta.Fecha_Hora;
            consultaTO.Estado = consulta.Estado;

            DAOConsulta dao = new DAOConsulta();
            string confirmacion = dao.cambiarEstadoConsulta(consultaTO);
            return confirmacion;
        }

        public string actualizarReporteMedicinaMixta (BLConsulta consulta)
        {
            TOConsulta consultaTO = new TOConsulta();
            consultaTO.CodigoExpediente = consulta.CodigoExpediente;
            consultaTO.Fecha_Hora = consulta.Fecha_Hora;
            consultaTO.MedicinaMixta = consulta.MedicinaMixta;
            consultaTO.Frecuencia = consulta.Frecuencia;
            consultaTO.ReferidoA = consulta.ReferidoA;

            DAOConsulta dao = new DAOConsulta();
            string confirmacion = dao.actualizarReporteMedicinaMixta(consultaTO);
            return confirmacion;

        }

        public string actualizarReferenciaMedica(BLConsulta consulta)
        {
            TOConsulta consultaTO = new TOConsulta();
            consultaTO.CodigoExpediente = consulta.CodigoExpediente;
            consultaTO.Fecha_Hora = consulta.Fecha_Hora;
            consultaTO.ReferenciaMedica = consulta.ReferenciaMedica;
            consultaTO.Especialidad = consulta.Especialidad;
            consultaTO.MotivoReferecnia = consulta.MotivoReferecnia;

            DAOConsulta dao = new DAOConsulta();
            string confirmacion = dao.actualizarReferenciaMedica(consultaTO);
            return confirmacion;
        }

        public DataTable generarMedMixta(string f1, string ff2, string code)
        {
            DAOConsulta dap = new DAOConsulta();
           return  dap.generarMedMixta(f1, ff2, code);
        }

        public string obtnerConsultasActivas(string codDoctor, List<BLConsulta> consultas)
        {
            List<TOConsulta> toConsultas = new List<TOConsulta>();
            DAOConsulta daoConsulta = new DAOConsulta();
            string confirmacion = daoConsulta.obtenerConsultasActivas(toConsultas, codDoctor);

            foreach (TOConsulta toConsulta in toConsultas)
            {
                consultas.Add(convertirConsulta(toConsulta));
            }
            return confirmacion;
        }

        private BLConsulta convertirConsulta(TOConsulta consultaTO)
        {
            BLConsulta consultaBl = new BLConsulta(consultaTO.CodigoMedico, consultaTO.CodigoExpediente, consultaTO.Fecha_Hora, consultaTO.Analisis, consultaTO.ImpresionDiagnostica, consultaTO.Plan, consultaTO.MedicinaMixta, consultaTO.Frecuencia, consultaTO.ReferidoA, consultaTO.Estado, consultaTO.PadecimientoActual, consultaTO.ReferenciaMedica, consultaTO.Especialidad, consultaTO.MotivoReferecnia);
            return consultaBl;
        }
        
        private void convertirConsultaCompleta_BL_TO (BLConsulta consultaBL, BLExamenFisico examenFisicoBL, TOConsulta consultaTO, TOExamenFisico examenFisicoTO)
        {
            //Objeto Consulta 
            consultaTO.CodigoMedico = consultaBL.CodigoMedico;
            consultaTO.CodigoExpediente = consultaBL.CodigoExpediente;
            consultaTO.Fecha_Hora = consultaBL.Fecha_Hora;
            consultaTO.Analisis = consultaBL.Analisis;
            consultaTO.ImpresionDiagnostica = consultaBL.ImpresionDiagnostica;
            consultaTO.Plan = consultaBL.Plan;
            consultaTO.MedicinaMixta = consultaBL.MedicinaMixta;
            consultaTO.Frecuencia = consultaBL.Frecuencia;
            consultaTO.ReferidoA = consultaBL.ReferidoA;
            consultaTO.Estado = consultaBL.Estado;
            consultaTO.PadecimientoActual = consultaBL.PadecimientoActual;
            consultaTO.ReferenciaMedica = consultaBL.ReferenciaMedica;
            consultaTO.Especialidad = consultaBL.Especialidad;
            consultaTO.MotivoReferecnia = consultaBL.MotivoReferecnia;

            //Objeto ExamenFisico
            examenFisicoTO.CodigoMedico = examenFisicoBL.CodigoMedico;
            examenFisicoTO.CodigoExpediente = examenFisicoBL.CodigoExpediente;
            examenFisicoTO.Fecha_Hora = examenFisicoBL.Fecha_Hora;
            examenFisicoTO.Talla = examenFisicoBL.Talla;
            examenFisicoTO.Peso = examenFisicoBL.Peso;
            examenFisicoTO.PerimetroCefalico = examenFisicoBL.PerimetroCefalico;
            examenFisicoTO.SO2 = examenFisicoBL.SO2;
            examenFisicoTO.IMC = examenFisicoBL.IMC;
            examenFisicoTO.Temperatura = examenFisicoBL.Temperatura;
            examenFisicoTO.EstadoAlerta = examenFisicoBL.EstadoAlerta;
            examenFisicoTO.EstadoHidratacion = examenFisicoBL.EstadoHidratacion;
            examenFisicoTO.RuidosCardiacos = examenFisicoBL.RuidosCardiacos;
            examenFisicoTO.CamposPulmonares = examenFisicoBL.CamposPulmonares;
            examenFisicoTO.Abdomen = examenFisicoBL.Abdomen;
            examenFisicoTO.Faringe = examenFisicoBL.Faringe;
            examenFisicoTO.Nariz = examenFisicoBL.Nariz;
            examenFisicoTO.Oidos = examenFisicoBL.Oidos;
            examenFisicoTO.SNC = examenFisicoBL.SNC;
            examenFisicoTO.Osteomuscular = examenFisicoBL.Osteomuscular;
            examenFisicoTO.Piel = examenFisicoBL.Piel;
            examenFisicoTO.Neurodesarrollo = examenFisicoBL.Neurodesarrollo;
            examenFisicoTO.Otros = examenFisicoBL.Otros;
        }

        private void convertirConsultaCompleta_TO_BL(BLConsulta consultaBL, BLExamenFisico examenFisicoBL, TOConsulta consultaTO, TOExamenFisico examenFisicoTO)
        {
            //Objeto Consulta 
            consultaBL.CodigoMedico = consultaTO.CodigoMedico;
            consultaBL.CodigoExpediente = consultaTO.CodigoExpediente;
            consultaBL.Fecha_Hora = consultaTO.Fecha_Hora;
            consultaBL.Analisis = consultaTO.Analisis;
            consultaBL.ImpresionDiagnostica = consultaTO.ImpresionDiagnostica;
            consultaBL.Plan = consultaTO.Plan;
            consultaBL.MedicinaMixta = consultaTO.MedicinaMixta;
            consultaBL.Frecuencia = consultaTO.Frecuencia;
            consultaBL.ReferidoA = consultaTO.ReferidoA;
            consultaBL.Estado = consultaTO.Estado;
            consultaBL.PadecimientoActual = consultaTO.PadecimientoActual;
            consultaBL.ReferenciaMedica = consultaTO.ReferenciaMedica;
            consultaBL.Especialidad = consultaTO.Especialidad;
            consultaBL.MotivoReferecnia = consultaTO.MotivoReferecnia;

            //Objeto ExamenFisico
            examenFisicoBL.CodigoMedico = examenFisicoTO.CodigoMedico;
            examenFisicoBL.CodigoExpediente = examenFisicoTO.CodigoExpediente;
            examenFisicoBL.Fecha_Hora = examenFisicoTO.Fecha_Hora;
            examenFisicoBL.Talla = examenFisicoTO.Talla;
            examenFisicoBL.Peso = examenFisicoTO.Peso;
            examenFisicoBL.PerimetroCefalico = examenFisicoTO.PerimetroCefalico;
            examenFisicoBL.SO2 = examenFisicoTO.SO2;
            examenFisicoBL.IMC = examenFisicoTO.IMC;
            examenFisicoBL.Temperatura = examenFisicoTO.Temperatura;
            examenFisicoBL.EstadoAlerta = examenFisicoTO.EstadoAlerta;
            examenFisicoBL.EstadoHidratacion = examenFisicoTO.EstadoHidratacion;
            examenFisicoBL.RuidosCardiacos = examenFisicoTO.RuidosCardiacos;
            examenFisicoBL.CamposPulmonares = examenFisicoTO.CamposPulmonares;
            examenFisicoBL.Abdomen = examenFisicoTO.Abdomen;
            examenFisicoBL.Faringe = examenFisicoTO.Faringe;
            examenFisicoBL.Nariz = examenFisicoTO.Nariz;
            examenFisicoBL.Oidos = examenFisicoTO.Oidos;
            examenFisicoBL.SNC = examenFisicoTO.SNC;
            examenFisicoBL.Osteomuscular = examenFisicoTO.Osteomuscular;
            examenFisicoBL.Piel = examenFisicoTO.Piel;
            examenFisicoBL.Neurodesarrollo = examenFisicoTO.Neurodesarrollo;
            examenFisicoBL.Otros = examenFisicoTO.Otros;
        }

        
    }
}
