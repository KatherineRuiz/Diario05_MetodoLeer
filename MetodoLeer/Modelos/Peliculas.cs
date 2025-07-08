using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
//Agregamos la librería para conectarnos a SQL Server

namespace Modelos
{
    public class Peliculas
    {
        private int id;
        private string nombre;
        private string director;
        private DateTime fechaLanzamiento;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Director { get => director; set => director = value; }
        public DateTime FechaLanzamiento { get => fechaLanzamiento; set => fechaLanzamiento = value; }

        //Creamos un método estatico DataTable para poder cargar los registros que estan en la base de datos en una tabla y mostrarla
        public static DataTable CargarPeliculas() 
        { 
            //  Creamos una variable de tipo SqlConnection
            SqlConnection con = Conexion.Conectar();
            //Llamam0s al objeto que ya creamos en la clases Conexion
            string comando = "select * from peliculas;";

            //Creamos un objeto de SqlAdapter para poder obtener el resultado de nuestro select
            //Enviamos 2 parametros al constructor, uno donde se encuentre el comando de Sql y el segunod, la variable de tipo conexion
            SqlDataAdapter ad = new SqlDataAdapter(comando, con);
            //Ahora, creamos un objeto de tipo DataTable. Esta es una tabla en la que guardaremos la información que viene de SQL Server
            DataTable dt = new DataTable();
            ad.Fill(dt);
            //Ahora, "vertimos" o "echamos" la información del adaptador en la tabla
            return dt;
        }
    }
}
