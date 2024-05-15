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
    public partial class mantenimiento_categoria : Form
    {
        string emp = "categoria";
        csControlador cn = new csControlador();
        public mantenimiento_categoria()
        {
            InitializeComponent();
        }
        public void actualizardatagriew()
        {

            DataTable dt = cn.llenarTbl(emp);
            dataGridView1.DataSource = dt;

        }
        public void limpiar()
        {
            textBox8.Clear();
            textBox7.Clear();
            textBox1.Clear();
            textBox6.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TextBox[] Grupo = { textBox8, textBox7, textBox1,  textBox6 };
            cn.ingresarm(Grupo, dataGridView1);
            actualizardatagriew();
            limpiar();
            MessageBox.Show("Registro insertado con éxito!!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TextBox[] Grupo = { textBox8, textBox7, textBox1, textBox6 };
            cn.delete(Grupo, dataGridView1);
            cn.ingresarm(Grupo, dataGridView1);
            actualizardatagriew();
            limpiar();
            MessageBox.Show("Registro modificado con éxito!!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextBox[] Grupo = { textBox8, textBox7, textBox1, textBox6 };
            cn.delete(Grupo, dataGridView1);
            actualizardatagriew();
            MessageBox.Show("Registro eliminado con éxito!!");
            limpiar();
        }

        private void mantenimiento_categoria_Load(object sender, EventArgs e)
        {
            actualizardatagriew();
        }
    }
}
