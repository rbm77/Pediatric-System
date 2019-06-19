using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TO;
using DAO;

namespace BL
{
    public class BLHistoriaClinica
    {
        public decimal AP_Talla { get; set; }
        public decimal AP_Peso { get; set; }
        public decimal AP_PerimetroCefalico { get; set; }
        public string AP_CalificacionUniversal { get; set; }
        public decimal AP_APGAR { get; set; }
        public decimal AP_EdadGestacional { get; set; }
        public Boolean AP_OtrasComplicaciones { get; set; }
        public string AP_OtrasComplicacionesDescripcion { get; set; }
        public Boolean HF_Asma { get; set; }
        public Boolean HF_Diabetes { get; set; }
        public Boolean HF_Hipertension { get; set; }
        public Boolean HF_Cardivasculares { get; set; }
        public Boolean HF_Displidemia { get; set; }
        public Boolean HF_Epilepsia { get; set; }
        public Boolean HF_Otros { get; set; }
        public string HF_DescripcionOtros { get; set; }
        public Boolean AP_Estado { get; set; }
        public string AP_Descripcion { get; set; }
        public Boolean AT_Estado { get; set; }
        public string AT_Descripcion { get; set; }
        public Boolean AQ_Estado { get; set; }
        public string AQ_Descripcion { get; set; }
        public Boolean Alergias { get; set; }
        public string AlegergiasDescripcion { get; set; }

        public BLHistoriaClinica()
        {

        }

        public BLHistoriaClinica(decimal apTalla, decimal apPeso, decimal apPerimetro, string apCalificacionU, decimal apAPGAR, decimal apEdad, Boolean apOtrasCom, string apDescripcionOtras)
        {
            this.AP_Talla = apTalla;
            this.AP_Peso = apPeso;
            this.AP_PerimetroCefalico = apPerimetro;
            this.AP_CalificacionUniversal = apCalificacionU;
            this.AP_APGAR = apAPGAR;
            this.AP_EdadGestacional = apEdad;
            this.AP_OtrasComplicaciones = apOtrasCom;
            this.AP_OtrasComplicacionesDescripcion = apDescripcionOtras;
        }

        public BLHistoriaClinica(Boolean hfAsma, Boolean hfDiabetes, Boolean hfHipertension, Boolean hfCardiovas, Boolean hfDisplidemia, Boolean hfEpilepsia, Boolean hfOtros, string hfDescripcionOtros, Boolean apEstado, string apDescripcion, 
            Boolean atEstado, string atDescripcion, Boolean aqEstado, string aqDescripcion, Boolean alergias, string descripcionAlergias)
        {
            this.HF_Asma = hfAsma;
            this.HF_Diabetes = hfDiabetes;
            this.HF_Hipertension = hfHipertension;
            this.HF_Cardivasculares = hfCardiovas;
            this.HF_Displidemia = hfDisplidemia;
            this.HF_Epilepsia = hfEpilepsia;
            this.HF_Otros = hfOtros;
            this.HF_DescripcionOtros = hfDescripcionOtros;
            this.AP_Estado = apEstado;
            this.AP_Descripcion = apDescripcion;
            this.AT_Estado = atEstado;
            this.AT_Descripcion = atDescripcion;
            this.AQ_Estado = aqEstado;
            this.AQ_Descripcion = aqDescripcion;
            this.Alergias = alergias;
            this.AlegergiasDescripcion = descripcionAlergias;
        }

    }
}
