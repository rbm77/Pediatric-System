using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using TO;

namespace DAO
{
  public  class DAOCuenta
    {
        SqlConnection conexion = new SqlConnection("server=. ; database=Clinica ; integrated security = true");

        public void buscar(TOCuenta myTOCuenta)
        {
            string sql = "select * from Cuenta where CORREO = @Correo and CONTRASENA = @Contraseña";
            SqlCommand command = new SqlCommand(sql, conexion);
            command.Parameters.AddWithValue("@Correo", myTOCuenta.correo);
            command.Parameters.AddWithValue("@Contraseña", myTOCuenta.contrasena);
            conexion.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                myTOCuenta.estado = reader["ESTADO"].ToString();
                myTOCuenta.tipo = reader["TIPO"].ToString();
            }
        }


        public void recuperarContraseña(TOCuenta myTOCuenta)
        {
            string sql = "update CUENTA set CONTRASENA = @Contraseña where CORREO = @Correo";
            SqlCommand command = new SqlCommand(sql, conexion);
            command.Parameters.AddWithValue("@Correo", myTOCuenta.correo);
            command.Parameters.AddWithValue("@Contraseña", myTOCuenta.contrasena);
            conexion.Open();
            command.ExecuteNonQuery();
            //SqlDataReader reader = command.ExecuteReader();
            conexion.Close();
        }
    }
}
