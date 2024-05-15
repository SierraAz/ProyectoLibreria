using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Windows.Forms;

namespace CapaModeloInventario
{
    public class Sentencias
    {
        Conexion con = new Conexion();
        public OdbcDataAdapter llenarTbl(string tabla)// metodo  que obtinene el contenio de una tabla
        {
            //string para almacenar los campos de OBTENERCAMPOS y utilizar el 1ro
            string sql = "select * from " + tabla + " ; ";
            OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, con.conexion());
            return dataTable;
        }
        public void eliminar(int clave, string campo, string tabla)
        {
            try
            {
                string sql = "delete from " + tabla + " where " + campo + "=" + clave + ";";
                OdbcCommand cmd = new OdbcCommand(sql, con.conexion());
                cmd.ExecuteNonQuery();
                Console.WriteLine("Operacion correcta ");
            }
            catch (Exception e)
            {

            }

        }
        public OdbcDataAdapter buscartbl(string BD)
        {
            string sql = "SELECT TABLE_NAME From INFORMATION_SCHEMA.TABLES  WHERE TABLE_SCHEMA = '" + BD + "'";
            OdbcDataAdapter datatable = new OdbcDataAdapter(sql, con.conexion());

            return datatable;
        }

        //insertar datos
        public void insertar(string dato, string tipo, string tabla)
        {
            try
            {
                string sql = "insert into " + tabla + "(" + tipo + ") values (" + dato + ")";
                OdbcCommand cmd = new OdbcCommand(sql, con.conexion());
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

            }

        }
        public void actualizar(string dato, string condicion, string tabla)
        {
            try
            {
                string sql = "Update " + tabla + " " + dato + " where " + condicion;
                OdbcCommand cmd = new OdbcCommand(sql, con.conexion());
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

            }


        }

        public OdbcDataAdapter llenartabla(string tabla, string condicion)
        {


            string sql = "select * from " + tabla + " " + condicion;
            OdbcDataAdapter datatable = new OdbcDataAdapter(sql, con.conexion());



            return datatable;
        }

        public OdbcDataAdapter filtro(string tabla, string tipodato, string dato)
        {


            string sql = "select * from " + tabla + " where " + tipodato + " like ('" + dato + "%');";
            OdbcDataAdapter datatable = new OdbcDataAdapter(sql, con.conexion());



            return datatable;
        }

        public OdbcDataAdapter llenartabla(string tabla)
        {


            string sql = "select * from " + tabla + ";";
            OdbcDataAdapter datatable = new OdbcDataAdapter(sql, con.conexion());



            return datatable;
        }
        //-----------------------------------------------------------------------------------
        public void actualizartransaccionbd(string factura, string datocxp, string proveedor)
        {

            OdbcCommand command = new OdbcCommand();
            OdbcTransaction transaction = null;
            OdbcConnection conn = con.connection;
            command.Connection = conn;
            try
            {
                conn.Open();
                transaction = conn.BeginTransaction();
                command.Connection = conn;
                command.Transaction = transaction;

                string sql = "insert into tbl_factura (pk_id_factura,pk_id_almacen,pk_id_proveedor,fecha_emision_factura,fecha_vencimiento_factura,total_factura,estatus_factura) values (" + factura + ");";
                command.CommandText = sql;
                command.ExecuteNonQuery();



                string sqlcxp = "Insert into tbl_cuentaporpagar(pk_id_cuentaporpagar, pk_id_almacen, pk_id_proveedor, pk_id_factura, fk_id_tipopago, fk_id_moneda, fk_id_conceptocuentaporpagar, cambio_moneda_cuentaporpagar, fecha_emision_cuentaporpagar, fecha_movimiento_cuentaporpagar, saldo_pago_cuentaporpagar, monto_pago_cuentaporpagar, estado_cuentaporpagar ) values ( " + datocxp + " );";
                command.CommandText = sqlcxp;
                command.ExecuteNonQuery();


                command.CommandText = proveedor;
                command.ExecuteNonQuery();

                transaction.Commit();
                MessageBox.Show("Realizado con Exito");
                Console.WriteLine("guardado en base de datos");
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                try
                {

                    transaction.Rollback();

                }
                catch
                {

                }
                finally
                {
                    conn.Close();
                }
            }


        }

        public string buscarid(string tabla, string tipo)
        {
            string dato = " ";
            try
            {

                string sql = "select " + tipo + " from " + tabla + " Order by " + tipo + " Desc Limit 1";
                OdbcCommand cmd = new OdbcCommand(sql, con.conexion());
                OdbcDataReader lr = cmd.ExecuteReader();
                while (lr.Read())
                {
                    dato = lr.GetString(0);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e);
            }


            return dato;
        }

        //------------------------------------------
        public int estadotabla(string tabla)
        {
            int dato = 0;
            string sql = "select count(*) as total from " + tabla;
            OdbcCommand cmd = new OdbcCommand(sql, con.conexion());
            OdbcDataReader lr = cmd.ExecuteReader();
            while (lr.Read())
            {

                dato = lr.GetInt32(0);


            }
            return dato;
        }

        //-----------------------------------------------
        public string[] datosProveedor(string idproveedor)
        {
            string[] dato = new string[2];
            try
            {

                string sql = "select saldo_actual_proveedor, cargo_del_mes_proveedor from tbl_proveedor where pk_id_proveedor =  " + idproveedor + " ;";
                OdbcCommand cmd = new OdbcCommand(sql, con.conexion());
                OdbcDataReader lr = cmd.ExecuteReader();
                while (lr.Read())
                {
                    dato[0] = lr.GetString(0);
                    dato[1] = lr.GetString(1);

                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e);
            }


            return dato;
        }

        public string buscarcantidadproducto(string id)
        {
            string dato = " ";
            try
            {

                string sql = "select Cantidad_producto from producto where pk_idProducto = " + id + " ;";
                OdbcCommand cmd = new OdbcCommand(sql, con.conexion());
                OdbcDataReader lr = cmd.ExecuteReader();
                while (lr.Read())
                {
                    dato = lr.GetString(0);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e);
            }


            return dato;
        }
        public void actualizarproductoingresar(string sql)
        {
            try
            {
                OdbcCommand cmd = new OdbcCommand(sql, con.conexion());
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

            }


        }

        public string buscarexistenciasporingresar(string id)
        {
            string dato = " ";
            try
            {

                string sql = "select existencia_producto from tbl_producto where pk_codigo_producto = " + id + " ;";
                OdbcCommand cmd = new OdbcCommand(sql, con.conexion());
                OdbcDataReader lr = cmd.ExecuteReader();
                while (lr.Read())
                {
                    dato = lr.GetString(0);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e);
            }


            return dato;
        }

        public string buscarexistenciasporingresartabla(string id)
        {
            string dato = " ";
            try
            {

                string sql = "select saldo_existencia from tbl_existencia where fk_codigo_almacen and fk_codigo_producto = " + id + " ;";
                OdbcCommand cmd = new OdbcCommand(sql, con.conexion());
                OdbcDataReader lr = cmd.ExecuteReader();
                while (lr.Read())
                {
                    dato = lr.GetString(0);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e);
            }


            return dato;
        }

        public string buscarexistenciasporingresartabla2(string id, string codigoalmacen)
        {
            string dato = " ";
            try
            {

                string sql = "select saldo_existencia from tbl_existencia where fk_codigo_almacen and fk_codigo_producto = " + id + " ;";
                OdbcCommand cmd = new OdbcCommand(sql, con.conexion());
                OdbcDataReader lr = cmd.ExecuteReader();
                while (lr.Read())
                {
                    dato = lr.GetString(0);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e);
            }


            return dato;
        }


        public string buscarcodigoproducto(string id)
        {
            string dato = " ";
            try
            {

                string sql = "select saldo_existencia from tbl_existencia where fk_codigo_almacen and fk_codigo_producto = " + id + " ;";
                OdbcCommand cmd = new OdbcCommand(sql, con.conexion());
                OdbcDataReader lr = cmd.ExecuteReader();
                while (lr.Read())
                {
                    dato = lr.GetString(0);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e);
            }


            return dato;
        }

        public string[] buscarparacomparar(string almacen, string producto)
        {
            string[] dato = new string[3];
            try
            {

                string sql = "select fk_codigo_almacen,fk_codigo_producto, saldo_existencia from tbl_existencia where fk_codigo_almacen = " + almacen + " and fk_codigo_producto =  " + producto + ";";
                OdbcCommand cmd = new OdbcCommand(sql, con.conexion());
                OdbcDataReader lr = cmd.ExecuteReader();
                while (lr.Read())
                {
                    dato[0] = lr.GetString(0);
                    dato[1] = lr.GetString(1);
                    dato[2] = lr.GetString(2);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e);
            }


            return dato;
        }

        public void accionexistencia(string sql)
        {

            try
            {

                OdbcCommand cmd = new OdbcCommand(sql, con.conexion());
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e);
            }

        }
        //Metodo para obtener datos de la tabla usuario
        public string[] queryLogin(string user)
        {
            string[] Campos = new string[300];
            string[] auto = new string[300];
            int i = 0;
            string datos = "pk_id_usuario, username_usuario, password_usuario";
            string sql = "SELECT " + datos + " FROM tbl_usuarios where username_usuario='" + user + "';";
            try
            {
                OdbcCommand command = new OdbcCommand(sql, con.conexion());
                OdbcDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Campos[i] = reader.GetValue(0).ToString();
                    Campos[(i + 1)] = reader.GetValue(1).ToString();
                    Campos[(i + 2)] = reader.GetValue(2).ToString();
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nError en query hacia la tabla de usuarios"); }
            return Campos;
        }

    }
}
