using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaModeloInventario;
using System.Data.Odbc;
using System.Data;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Net;
namespace CapaControladorInventario
{
    public class csControlador
    {
        Sentencias sn = new Sentencias();
        public DataTable llenarTbl(string tabla)
        {
            //llenamos nuestro dataTable, entre consulta y el datagridview

            OdbcDataAdapter dt = sn.llenarTbl(tabla);
            DataTable table = new DataTable();
            //la llenamos con los datos obtenidos
            dt.Fill(table);
            return table;
        }
        public static string Username;

        public static string idUser;

        private static string ids;
        public string IDS
        {
            get { return ids; }
            set { ids = value; }
        }

        public static string SetHash(string inputString) //recibe una cadena de entrada inputString
        {
            string hash = "x2";
            byte[] bytes = UTF8Encoding.UTF8.GetBytes(inputString);
            MD5 mD5 = MD5.Create();
            TripleDES tripleDES = TripleDES.Create();
            tripleDES.Key = mD5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash)); //Se crea objeto TripleDES y se establece su clave utilizando el valor hash
            tripleDES.Mode = CipherMode.ECB; //se establece el modo de cifrado como ECB
            ICryptoTransform transform = tripleDES.CreateEncryptor();
            byte[] output = transform.TransformFinalBlock(bytes, 0, bytes.Length); // se cifra la matriz de byte de la cadena de entrada
            return Convert.ToBase64String(output); //se convierte la matriz de bytes cifrada a una cadena Base64 y se devuelve como salida de la funcion
        }

        public void ingresarm(TextBox[] textbox, DataGridView tabla)//Crea cadenas de datos para la insercion
        {
            try
            {
                string dato = " ";
                string tipo = " ";
                for (int x = 0; x < textbox.Length; x++)
                {

                    if (x == textbox.Length - 1)
                    {
                        dato += "'" + textbox[x].Text + "'";
                        tipo += textbox[x].Tag.ToString();
                    }
                    else
                    {
                        dato += "'" + textbox[x].Text + "',";
                        tipo += textbox[x].Tag.ToString() + ",";
                    }

                }

                sn.insertar(dato, tipo, tabla.Tag.ToString());

            }

            catch (Exception e)
            {
                Console.WriteLine("Error " + e);
            }

        }
        public void delete(TextBox[] textbox, DataGridView tabla)
        {
            try
            {
                string campo = textbox[0].Tag.ToString();
                int clave = int.Parse(textbox[0].Text);
                sn.eliminar(clave, campo, tabla.Tag.ToString());



            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e);
            }

        }

        public void ingresar(string[] tipos, string[] datos, string tabla)//Crea cadenas de datos para la insercion
        {
            try
            {
                string dato = " ";
                string tipo = " ";
                for (int x = 0; x < datos.Length; x++)
                {

                    if (x == datos.Length - 1)
                    {
                        dato += "'" + datos[x] + "'";
                        tipo += tipos[x];
                    }
                    else
                    {
                        dato += "'" + datos[x] + "',";
                        tipo += tipos[x] + ",";
                    }

                }
                sn.insertar(dato, tipo, tabla);

                MessageBox.Show("Dato Insertado");

            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e);
            }

        }
        public void actualizar(string[] tipos, string[] datos, string tabla, TextBox id)//Crea cadenas de datos para la actualizacion
        {
            try
            {
                string dato = " ";
                string condicion = "(" + id.Tag.ToString() + " = '" + id.Text + "')";

                for (int x = 1; x < tipos.Length; x++)
                {

                    if (x == tipos.Length - 1)
                    {
                        dato += " " + tipos[x] + " = '" + datos[x] + "' ";

                    }
                    else if (x == 1)
                    {
                        dato += "SET " + tipos[x] + " = '" + datos[x] + "', ";

                    }
                    else
                    {
                        dato += " " + tipos[x] + " = '" + datos[x] + "', ";

                    }

                }
                sn.actualizar(dato, condicion, tabla);

                MessageBox.Show("Dato actualizado");

            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e);
            }



        }
        //------------------------------------
        public void llenartxt(string tabla, TextBox[] textbox)
        {
            try
            {
                string condicion = " where " + textbox[0].Tag.ToString() + " = '" + textbox[0].Text + "' ;";
                OdbcDataAdapter dt = sn.llenartabla(tabla, condicion);
                DataTable table = new DataTable();
                dt.Fill(table);
                int longitud = textbox.Length;
                int contador = 0;

                for (int x = 0; x < longitud; x++)
                {
                    textbox[x].Text = table.Rows[contador][x].ToString();

                }



            }
            catch (Exception e)
            {
                MessageBox.Show(" " + e);
            }
        }
        public void llenarfiltro(string ntabla, DataGridView tabla, string tipo, string dato)//Funcion para llenar tabla
        {
            try
            {
                OdbcDataAdapter dt = sn.filtro(ntabla, tipo, dato);
                DataTable table = new DataTable();
                dt.Fill(table);
                tabla.DataSource = table;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error:" + e);
            }

        }

        public void llenartablaa(string ntabla, DataGridView tabla)//Funcion para llenar tabla
        {
            try
            {
                OdbcDataAdapter dt = sn.llenartabla(ntabla);
                DataTable table = new DataTable();
                dt.Fill(table);
                tabla.DataSource = table;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error:" + e);
            }

        }
        public void insertardatagrid(DataGridView tabla, string spk_id_detalle_orden_compra,
            string sfk_codigo_almacen, string sfk_id_orden_compra, string sfk_id_listado_productos,
            string scantidad_detalle_orden_compra, string scosto_unitario, TextBox total, TextBox cantidadtotal,
            GroupBox group)
        {
            double cantidad = Convert.ToDouble(scantidad_detalle_orden_compra);
            string[] datos = new string[7];
            datos[0] = spk_id_detalle_orden_compra;
            datos[1] = sfk_codigo_almacen;
            datos[2] = sfk_id_orden_compra;
            datos[3] = sfk_id_listado_productos;
            datos[4] = cantidad.ToString();
            double costo_unitario = Convert.ToDouble(scosto_unitario);
            datos[5] = scosto_unitario;
            datos[6] = (cantidad * costo_unitario).ToString();


            tabla.Rows.Add(datos[0], datos[1], datos[2], datos[3], datos[4], datos[5], datos[6]);
            double suma = 0, suma2 = 0;
            foreach (DataGridViewRow row in tabla.Rows)
            {
                suma += Convert.ToDouble(row.Cells["total_detalle_orden_compra"].Value);
                total.Text = suma.ToString();

                suma2 += Convert.ToDouble(row.Cells["cantidad_detalle_orden_compra"].Value);
                cantidadtotal.Text = suma2.ToString();
            }
            limpiardetalle(group);






        }

        public void insertardatagridventa(DataGridView tabla, string spk_idventa,
            string sfk_producto_venta, string scantidad_producto_venta, string sprecio_producto_venta,
            string ssfecha_venta, string sdescripcion_venta, GroupBox group)
        {
            double cantidad = Convert.ToDouble(scantidad_producto_venta);
            string[] datos = new string[7];
            datos[0] = spk_idventa;
            datos[1] = sfk_producto_venta;
            datos[2] = scantidad_producto_venta;
            datos[3] = sprecio_producto_venta;
            double costo_unitario = Convert.ToDouble(sprecio_producto_venta);
            datos[4] = ssfecha_venta;
            datos[5] = sdescripcion_venta;
            datos[6] = (cantidad * costo_unitario).ToString();


            tabla.Rows.Add(datos[0], datos[1], datos[2], datos[3], datos[4], datos[5], datos[6]);
            double suma = 0;
            foreach (DataGridViewRow row in tabla.Rows)
            {
                suma += Convert.ToDouble(row.Cells["total_venta"].Value);
                
            }
            limpiardetalle(group);

        }

        public void insertardatagridcompra(DataGridView tabla, string sidrestock,
            string sid_producto, string scantidad_restock, string scosto_restock, string sfecha_restock,
            string sdescripcion_restock, GroupBox group)
        {
            double cantidad = Convert.ToDouble(scantidad_restock);
            string[] datos = new string[7];
            datos[0] = sidrestock;
            datos[1] = sid_producto;
            datos[2] = scantidad_restock;
            datos[3] = scosto_restock;
            double costo_unitario = Convert.ToDouble(scosto_restock);
            datos[4] = sfecha_restock;
            datos[5] = sdescripcion_restock;
            datos[6] = (cantidad * costo_unitario).ToString(); 


            tabla.Rows.Add(datos[0], datos[1], datos[2], datos[3], datos[4], datos[5], datos[6]);
            limpiardetalle(group);

        }

        public void insertarbddetalle(DataGridView tabla)
        {

            if (tabla.Rows.Count > 1)
            {

                for (int x = 0; x < tabla.Rows.Count - 1; x++)
                {
                    string pk_id_detalle_orden_compra = tabla.Rows[x].Cells[0].Value.ToString();
                    string fk_codigo_almacen = tabla.Rows[x].Cells[1].Value.ToString();
                    string fk_id_orden_compra = tabla.Rows[x].Cells[2].Value.ToString();
                    string fk_id_listado_productos = tabla.Rows[x].Cells[3].Value.ToString();
                    string cantidad_detalle_orden_compra = tabla.Rows[x].Cells[4].Value.ToString();
                    string costo_unitario = tabla.Rows[x].Cells[5].Value.ToString();
                    string total_detalle_orden_compra = tabla.Rows[x].Cells[6].Value.ToString();

                    string productoingresar = sn.buscarcantidadproducto(fk_id_listado_productos);
                    string nuevoproductoingresar = ((Convert.ToDouble(productoingresar)) + (Convert.ToDouble(cantidad_detalle_orden_compra))).ToString();
                    string actualizar = "update tbl_producto set productos_por_ingresar = " + nuevoproductoingresar + " where pk_codigo_producto = " + fk_id_listado_productos + " ;";
                    sn.actualizarproductoingresar(actualizar);

                    string consultadetallepe = "'" + pk_id_detalle_orden_compra + "', '" + fk_codigo_almacen + "', '" + fk_id_orden_compra + "', '" + fk_id_listado_productos + "', '" + cantidad_detalle_orden_compra + "', '" + costo_unitario + "', '" + total_detalle_orden_compra + "'";
                    string consultadetallepe_campos = "pk_id_detalle_orden_compra, fk_codigo_almacen, fk_id_orden_compra, fk_id_listado_productos, cantidad_detalle_orden_compra,costo_unitario, total_detalle_orden_compra";
                    sn.insertar(consultadetallepe, consultadetallepe_campos, "tbl_detalle_orden_compra");

                }



            }

        }

        public void insertarbddetallecompra(DataGridView tabla)
        {

            if (tabla.Rows.Count > 1)
            {

                for (int x = 0; x < tabla.Rows.Count - 1; x++)
                {
                    string idrestock = tabla.Rows[x].Cells[0].Value.ToString();
                    string id_producto = tabla.Rows[x].Cells[1].Value.ToString();
                    string cantidad_restock = tabla.Rows[x].Cells[2].Value.ToString();
                    string costo_restock = tabla.Rows[x].Cells[3].Value.ToString();
                    string fecha_restock = tabla.Rows[x].Cells[4].Value.ToString();
                    string descripcion_restock = tabla.Rows[x].Cells[5].Value.ToString();
                    string total_restock = tabla.Rows[x].Cells[6].Value.ToString();

                    string cantidadingresar = sn.buscarcantidadproducto(id_producto);
                    string nuevacantidadingresar = ((Convert.ToDouble(cantidadingresar)) + (Convert.ToDouble(cantidad_restock))).ToString();
                    string actualizar = "update producto set Cantidad_producto = " + nuevacantidadingresar + " where pk_idProducto = " + id_producto + " ;";
                    sn.actualizarproductoingresar(actualizar);

                    string consultarestock = "'" + idrestock + "', '" + id_producto + "', '" + cantidad_restock + "', '" + costo_restock + "', '" + fecha_restock + "', '" + descripcion_restock + "', '" + total_restock + "'";
                    string consoltarestock_campos = "idrestock, id_producto, cantidad_restock, costo_restock, fecha_restock, descripcion_restock, total_restock";
                    sn.insertar(consultarestock, consoltarestock_campos, "restock");



                }



            }

        }

        public void insertarbddetalleventa(DataGridView tabla)
        {
            try {

                if (tabla.Rows.Count > 1)
                {

                    for (int x = 0; x < tabla.Rows.Count - 1; x++)
                    {
                        string idrestock = tabla.Rows[x].Cells[0].Value.ToString();
                        string id_producto = tabla.Rows[x].Cells[1].Value.ToString();
                        string cantidad_restock = tabla.Rows[x].Cells[2].Value.ToString();
                        string costo_restock = tabla.Rows[x].Cells[3].Value.ToString();
                        string fecha_restock = tabla.Rows[x].Cells[4].Value.ToString();
                        string descripcion_restock = tabla.Rows[x].Cells[5].Value.ToString();
                        string total_restock = tabla.Rows[x].Cells[6].Value.ToString();

                        string cantidadingresar = sn.buscarcantidadproducto(id_producto);
                        string nuevacantidadingresar = ((Convert.ToDouble(cantidadingresar)) - (Convert.ToDouble(cantidad_restock))).ToString();
                        string actualizar = "update producto set Cantidad_producto = " + nuevacantidadingresar + " where pk_idProducto = " + id_producto + " ;";
                        sn.actualizarproductoingresar(actualizar);

                        string consultarestock = "'" + idrestock + "', '" + id_producto + "', '" + cantidad_restock + "', '" + costo_restock + "', '" + fecha_restock + "', '" + descripcion_restock + "', '" + total_restock + "'";
                        string consoltarestock_campos = "pk_idventa, fk_producto_venta, cantidad_producto_venta, precio_producto_venta, fecha_venta, descripcion_venta, total_venta";
                        sn.insertar(consultarestock, consoltarestock_campos, "venta");

                    }

                }

                MessageBox.Show("Registros guardados!");


            }
            catch (Exception e)
            {
                MessageBox.Show("hubo un error en la insercion de registros" + e);
            }

        }




        public void vaciartextbox(TextBox[] textbox)
        {
            for (int x = 0; x < textbox.Length; x++)
            {
                textbox[x].Clear();
            }
        }

        public void bloqueartextbox(TextBox[] textbox)
        {
            for (int x = 0; x < textbox.Length; x++)
            {
                textbox[x].Enabled = false;
            }
        }
        public void desbloqueartextbox(TextBox[] textbox)
        {
            for (int x = 0; x < textbox.Length; x++)
            {
                textbox[x].Enabled = true;
            }
        }
        public void limpiardetallee(GroupBox[] group)
        {
            limpiardetalle(group[0]);
        }

        void limpiardetalle(GroupBox group)
        {


            foreach (Control c in group.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }

            }
        }

        public void eliminarfilagrid(DataGridView tabla, GroupBox group)
        {
            int fila = tabla.Rows.Count - 1;

            if (fila > 0 && tabla.CurrentRow.Index < fila)
            {

                tabla.Rows.RemoveAt(tabla.CurrentRow.Index);
   

            }
            limpiardetalle(group);

        }

        //-----------------------------------------------------------
        public string ingresarcambiosfactura(TextBox[] textbox)//Crea cadenas de datos para la insercion
        {
            string sql;
            string idProveedor = textbox[1].Text;
            string[] datosProveedor = sn.datosProveedor(idProveedor);

            double nuevosaldo = Convert.ToDouble(datosProveedor[0]) + Convert.ToDouble(textbox[4].Text);
            double nuevocargo = Convert.ToDouble(datosProveedor[1]) + Convert.ToDouble(textbox[4].Text);


            sql = "Update tbl_proveedor Set saldo_actual_proveedor = " + nuevosaldo + ", cargo_del_mes_proveedor = " + nuevocargo + " where pk_id_proveedor = " + idProveedor + " ;";
            return sql;

        }

        string ingresarcxpbd(TextBox[] textbox, string factura)//Crea cadenas de datos para la insercion
        {
            string dato;
            //string tipo = " ";
            string idcxp = crearidwo("tbl_cuentaporpagar", "pk_id_cuentaporpagar");
            dato = " " + idcxp + " , " + textbox[0].Text + " , " + textbox[1].Text + " , " + factura + " , 1, 1, 1, 1 " + " , '" + textbox[2].Text + "' , '" + textbox[3].Text + "' , " + textbox[4].Text + " , 0, 1 ";

            return dato;

        }
        public void ingresarfacturabd(TextBox[] textbox)//Crea cadenas de datos para la insercion
        {

            try
            {
                string idfac = crearidwo("tbl_factura", "pk_id_factura");
                string factura = ingresarfactura(textbox, idfac);
                string datocxp = ingresarcxpbd(textbox, idfac);
                string proveedor = ingresarcambiosfactura(textbox);

                sn.actualizartransaccionbd(factura, datocxp, proveedor);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e);
            }

        }
        string ingresarfactura(TextBox[] textbox, string idfac)//Crea cadenas de datos para la insercion
        {
            string dato;
            //string tipo = " ";

            dato = " " + idfac + " , " + textbox[0].Text + " , " + textbox[1].Text + " , '" + textbox[2].Text + "' , '" + textbox[3].Text + "' , " + textbox[4].Text + " , " + textbox[5].Text + " ";

            return dato;

        }

        //---------------------------------------------------------------
        public string crearidwo(string tabla, string campo)//Crea el id para tbl_cuentasPorPagar
        {
            string textbox = "";
            try
            {
                int incremento = 0;

                int permiso = comprobacionvacio(tabla);
                if (permiso != 0)
                {
                    string resultado = sn.buscarid(tabla, campo);
                    incremento = Convert.ToInt32(resultado) + 1;
                    textbox = incremento.ToString();
                }
                else
                {
                    incremento = 1;
                    textbox = incremento.ToString();
                }



            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e);
            }
            return textbox;
        }

        //-------------------------------------
        public int comprobacionvacio(string tabla)
        {
            int resultado = 0;
            resultado = sn.estadotabla(tabla);

            return resultado;
        }
        //-------------------------------------

        public void accionExistencia(string almacen, string producto, string existencia)
        {
            string[] datos = sn.buscarparacomparar(almacen, producto);
            string sql = "";
            if (String.IsNullOrEmpty(datos[0]) == true || String.IsNullOrEmpty(datos[1]) == true || String.IsNullOrEmpty(datos[2]) == true)
            {
                sql = "insert into tbl_existencia (fk_codigo_almacen, fk_codigo_producto, saldo_existencia) values(" + almacen + " , " + producto + " , " + existencia + ");";
            }
            else
            {
                double nuevaExistencia = ((Convert.ToDouble(datos[2])) + (Convert.ToDouble(existencia)));
                sql = "update tbl_existencia set saldo_existencia = " + nuevaExistencia + " where fk_codigo_almacen = " + datos[0] + " and fk_codigo_producto = " + datos[1] + " ;";
            }


            sn.accionexistencia(sql);

        }

        public Boolean validarLogin(string username, string password) //Valida en inicio de sesion del usuario
        {
            string[] datos = sn.queryLogin(username);
            for (int i = 0; i < datos.Length; i = i + 3)
            {
                if (datos[i + 1] == username)
                {
                    if (datos[i + 2] == password)
                    {
                        idUser = SetHash(datos[i]);
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
