using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace Modelos
{
    public class Conexion
    {
        private static string servidor = "LAB03-DS-EQ06\\SQLEXPRESS";
        private static string baseDeDatos = "MetodoLeer";
        private static string cadena;

        public static SqlConnection Conectar()
        {
            //creamos una cadena de conexion, un string que tiene todos los parametros para poder acceder a sql server
            string cadena = 
                $"Data Source = {servidor}" +
                $"Initial Catalog = {baseDeDatos};" +
                $"Integrated Security = true;";
            //Initial Catalog indica la base de datos que vamos a leer

            //Creamos un objeto de tipo SqlConnection
            SqlConnection con = new SqlConnection(cadena);

            //Abrimos la conexion entre SQL Server y nuestra aplicacion
            con.Open();
            return con;
        }

    }
}
