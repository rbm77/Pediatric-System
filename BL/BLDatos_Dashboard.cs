using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TO;
using DAO;

namespace BL
{
  public  class BLDatos_Dashboard
    {
        public string cantidadExpedientes { get; set; }
        public string cantidadCitasPendientes { get; set; }
        public string cantidadConsultasActivas { get; set; }

        public string cantidadExpedientesSinCuenta { get; set; }

        TODatosDashboard miTODatos = new TODatosDashboard();

        DAODatosDashboard miDAODatos = new DAODatosDashboard();


        public BLDatos_Dashboard()
    {

    }
    public BLDatos_Dashboard(string cantidadExpedientes, string cantidadCitasPendientes, string cantidadConsultasActivas)
    {
        this.cantidadExpedientes = cantidadExpedientes;
        this.cantidadCitasPendientes = cantidadCitasPendientes;
        this.cantidadConsultasActivas = cantidadConsultasActivas;
    }


        public void buscarDatosDashBoard(String CodigoMedico)
        {
            miDAODatos.buscarDatos(miTODatos, CodigoMedico);
            this.cantidadExpedientes = miTODatos.cantidadExpedientes;
            this.cantidadCitasPendientes = miTODatos.cantidadCitasPendientes;
            this.cantidadConsultasActivas = miTODatos.cantidadConsultasActivas;
            this.cantidadExpedientesSinCuenta = miTODatos.cantidadExpedientesSinCuenta;
        }


        public void buscarDatosDashBoardPaciente(String Correo)
        {
            miDAODatos.buscarDatosPaciente(miTODatos, Correo);
            this.cantidadExpedientes = miTODatos.cantidadExpedientes;
            this.cantidadCitasPendientes = miTODatos.cantidadCitasPendientes;
        }
    }
}
