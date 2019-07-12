﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TO
{
    public class TOAdministrativo
    { 
    public string correo { get; set; }
    public string nombre { get; set; }
    public string apellido { get; set; }
    public int cedula { get; set; }
    public int telefono { get; set; }
    public string cod_Asist { get; set; }

    public TOAdministrativo()
    {
    }

    public TOAdministrativo(string correo, string nombre, string apellido, int cedula, int telefono, string cod_Asist)
    {
        this.correo = correo;
        this.nombre = nombre;
        this.apellido = apellido;
        this.cedula = cedula;
        this.telefono = telefono;
        this.cod_Asist = cod_Asist;
    }
}
}
