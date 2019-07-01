using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ManejadorEdad
    {

        public ManejadorEdad()
        {

        }

        /// <summary>
        /// Obtiene la edad de un paciente a partir de la fecha de nacimiento
        /// </summary>
        /// <param name="fechaNacimiento"></param>
        /// <returns>Retorna una descripcion de la edad</returns>
        public string ExtraerEdad(DateTime fechaNacimiento)
        {

            TimeSpan d = DateTime.Now - fechaNacimiento;

            int dias = d.Days;

            int meses = 0;
            int annos = 0;

            if (dias < 30)
            {
                if (dias == 1)
                {
                    return dias + "día";
                }
                return dias + " días";
            }

            if (dias >= 30)
            {
                meses = dias / 30;

                if (meses >= 12)
                {
                    annos = meses / 12;

                    int sobranteMeses = meses - (annos * 12);

                    if (sobranteMeses == 0)
                    {
                        if (annos == 1)
                        {
                            return annos + "año";
                        }
                        return annos + " años";
                    }

                    if(annos == 1 && sobranteMeses == 1)
                    {
                        return annos + " año y " + sobranteMeses + " mes";
                    }
                    if (annos == 1 && sobranteMeses > 1)
                    {
                        return annos + " año y " + sobranteMeses + " meses";
                    }
                    if (annos > 1 && sobranteMeses == 1)
                    {
                        return annos + " años y " + sobranteMeses + " mes";
                    }
                    return annos + " años y " + sobranteMeses + " meses";
                }
                else
                {
                    if (meses == 1)
                    {
                        return meses + " mes";
                    }

                    return meses + " meses";
                }
            }
            return "error";
        }

        /// <summary>
        /// Extrae la cantidad de meses que tiene el paciente a partir de la fecha de naciemiento
        /// </summary>
        /// <param name="fechaNacimiento"></param>
        /// <returns>Retorna la cantidad de meses</returns>
        public int ExtraerMeses(DateTime fechaNacimiento)
        {
            TimeSpan d = DateTime.Now - fechaNacimiento;

            int dias = d.Days;

            return dias / 30;
        }

    }
}
