using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace PruebaTaller
{
    class Crud
    {
        public SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-2IIMGTL;Initial Catalog=PruebaTaller;Integrated Security=True");
        public SqlDataAdapter da;
        public SqlCommand comando;
        public SqlCommandBuilder cmb;
        public DataSet ds = new DataSet();
        public SqlDataReader dr;
        //Metodo para conectarse a la base de datos

        public void conectarBD()
        {
            try
            {
                conexion.Open();
                MessageBox.Show("Conexion Exitosa");

            }
            catch
            {
                MessageBox.Show("Conexion Fallida");
                Application.Exit();
            }
            finally
            {
                conexion.Close();
            }
        }
        //Funcion para leer el registro en la base de datos
        public void ConsultarTextto(string Cadenasql)
        {
            conexion.Open();
            comando = new SqlCommand(Cadenasql, conexion);
            dr = comando.ExecuteReader();
        }
        //Para Insertar y modificar
        public bool Operacion(string sql)
        {
            conexion.Close();
            conexion.Open();
            comando = new SqlCommand(sql, conexion);
            int i = comando.ExecuteNonQuery();
            conexion.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void cerrarConn()
        {
            conexion.Close();
        }
    }
}
