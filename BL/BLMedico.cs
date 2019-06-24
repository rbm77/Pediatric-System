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

        TOMedico miTOMedico = new TOMedico();
        DAOMedico miDAOMedico = new DAOMedico();


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
    }
}
