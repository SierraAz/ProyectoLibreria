using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaControladorInventario;
namespace CapaVistaInventario
{
    public partial class proceso_venta : Form
    {
        csControlador cn = new csControlador();
        public proceso_venta()
        {
            InitializeComponent();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            ayuda_productos a = new ayuda_productos("producto", "pk_idProducto");
            if (cn.IDS == null && textBox6.Text.Length == 0)
            {
                cn.IDS = null;
                a.Show();
            }
            else
            {
                textBox6.Text = cn.IDS;
                cn.IDS = null;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox4.Text = dateTimePicker1.Text;
            textBox5.Text = richTextBox1.Text;

            if (textBox7.Text.Length == 0 || textBox1.Text.Length == 0 || textBox2.Text.Length == 0 ||
                textBox3.Text.Length == 0 || textBox4.Text.Length == 0 )
            {
                MessageBox.Show("Error, debe de llenar todos los campos importantes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                cn.insertardatagridventa(dataGridView1, textBox7.Text, textBox1.Text, textBox2.Text,
                textBox3.Text, textBox4.Text, textBox5.Text, groupBox1);
            }

           


        }

        private void proceso_venta_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Agregar registro de tabla a ventas y restar a inventario
            cn.insertarbddetalleventa(dataGridView1);
            dataGridView1.Rows.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cn.eliminarfilagrid(dataGridView1, groupBox1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GroupBox[] groupBoxes = { groupBox1 };
            cn.limpiardetallee(groupBoxes);
            dataGridView1.Rows.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ayuda_venta a = new ayuda_venta("venta", "pk_idventa");
            if (cn.IDS == null && textBox7.Text.Length == 0)
            {
                cn.IDS = null;
                a.Show();
            }
            else
            {
                textBox7.Text = cn.IDS;
                cn.IDS = null;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.TextLength > 0)
            {
                TextBox[] llenar = {textBox6, textBox8, textBox9, textBox10, textBox11,
                textBox12, textBox13, textBox14};
                cn.llenartxt("producto", llenar);
            }
            textBox1.Text = textBox6.Text;
            textBox3.Text = textBox10.Text;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Se deben de colocar datos numericos...", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 45) || (e.KeyChar >= 58 && e.KeyChar <= 255)|| (e.KeyChar == 47 ))
            {
                MessageBox.Show("Se deben de colocar datos numericos...", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
