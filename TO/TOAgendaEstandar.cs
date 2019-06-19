using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TO
{
    public class TOAgendaEstandar
    {
        public string CodigoMedico { get; set; }
        public string Dia { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }

        public TOAgendaEstandar()
        {

        }
        public TOAgendaEstandar(string codigoMedico, string dia, string horaInicio, string horaFin)
        {
            this.CodigoMedico = codigoMedico;
            this.Dia = dia;
            this.HoraInicio = horaInicio;
            this.HoraFin = horaFin;
        }
    }
}
