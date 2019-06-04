using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BLAgendaEstandar
    {
        public string Dia { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }

        public BLAgendaEstandar()
        {

        }
        public BLAgendaEstandar(string dia, string horaInicio, string horaFin)
        {
            this.Dia = dia;
            this.HoraInicio = horaInicio;
            this.HoraFin = horaFin;
        }
    }
}
