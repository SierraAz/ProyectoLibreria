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
    public partial class proceso_restock : Form
    {
        csControlador cn = new csControlador();
        public proceso_restock()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox4.Text = dateTimePicker1.Text;
            textBox5.Text = richTextBox1.Text;

            if (textBox7.Text.Length == 0 || textBox1.Text.Length == 0 || textBox2.Text.Length == 0 ||
                textBox3.Text.Length == 0 || textBox4.Text.Length == 0)
            {
                MessageBox.Show("Error, debe de llenar todos los campos importantes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                cn.insertardatagridcompra(dataGridView1, textBox7.Text, textBox1.Text, textBox2.Text, textBox3.Text,
                textBox4.Text, textBox5.Text, groupBox1);
            }
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Agregar registro de tabla a restock y sumar a inventario
            cn.insertarbddetallecompra(dataGridView1);
            dataGridView1.Rows.Clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            cn.eliminarfilagrid(dataGridView1,  groupBox1);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            GroupBox[] groupBoxes = { groupBox1};
            cn.limpiardetallee(groupBoxes);
            dataGridView1.Rows.Clear();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            ayuda_productos a = new ayuda_productos("producto", "pk_idProducto");
            if (cn.IDS == null && textBox1.Text.Length == 0)
            {
                cn.IDS = null;
                a.Show();
            }
            else
            {
                textBox1.Text = cn.IDS;
                cn.IDS = null;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ayuda_restock a = new ayuda_restock("restock", "idrestock");
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Se deben de colocar datos numericos...", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 45) || (e.KeyChar >= 58 && e.KeyChar <= 255) || (e.KeyChar == 47))
            {
                MessageBox.Show("Se deben de colocar datos numericos...", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
    }
}
