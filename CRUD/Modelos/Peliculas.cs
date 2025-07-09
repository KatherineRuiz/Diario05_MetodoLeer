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

        //Creamos el método necesario para insertar datos en SqlServer
        //Será de tipo bool para retornar true si pudimos insertar de manera o correcta o false si no
        public bool InsertarPeliculas()
        {
            SqlConnection con= Conexion.Conectar();
            //creamos el comando necesario para insertar datos
            string comando = "Insert into Peliculas(nombre, director, fechaLanzamiento)" + "values(@nombre, @director, @fechaLanzamiento);";
            //No sabemos qué valores vamos a ingresar a SQL Server, así que en el apartado "values" del Query, colocamos valores temporales,
            //precedidos de una @, eso le indica al programa que son temporales y que después los vamos a cambiar

            //creamos un comando de SQL. Debemos crear un objeto de tipo SqlCommand.
            SqlCommand cmd = new SqlCommand(comando, con);

            //sustituimos los valores que colocamos como temporales por valores reales: Los atributos de la clase
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@director", director);
            cmd.Parameters.AddWithValue("@fechaLanzamiento", fechaLanzamiento);

            //Enviamos el comando a SqlServer
            //Utilizaremos el comando ExecuteNonQuery() que retorna la cantidad de filas afectadas
            cmd.ExecuteNonQuery();
            if (cmd.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
