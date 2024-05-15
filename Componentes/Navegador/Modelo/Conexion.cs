//Revisado por Rene Alexander Fecha 26/02/2023
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Libreria--------
using System.Data.Odbc;

namespace NavegadorModelo
{
    class Conexion
    {
        //Clase de conexion --------------
        public OdbcConnection conexion()
        {
            //creacion de la conexion via ODBC
            OdbcConnection conn = new OdbcConnection("Dsn=libreria");
            try
            {
                conn.Open();
            }
            catch (OdbcException)
            {
                Console.WriteLine("Sin conexión");
            }
            return conn;
        }

        //metodo para cerrar la conexion
        public void cerrar_conexion(OdbcConnection conn)
        {
            try
            {
                conn.Close();
            }
            catch (OdbcException)
            {
                Console.WriteLine("conexion cerrada");
            }
        }
    }
}
