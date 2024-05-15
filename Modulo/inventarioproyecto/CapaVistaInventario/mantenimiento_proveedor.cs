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
    public partial class mantenimiento_proveedor : Form
    {
        string emp = "proveedor";
        csControlador cn = new csControlador();
        public mantenimiento_proveedor()
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
            textBox2.Clear();
            textBox6.Clear();


        }
        private void mantenimiento_proveedor_Load(object sender, EventArgs e)
        {
            actualizardatagriew();
        }

        private void navegador1_Load(object sender, EventArgs e)
        {
            
        }

        private void navegador1_Load_1(object sender, EventArgs e)
        {
            /*NavegadorVista.Navegador.idApp = "3001";
            TextBox[] Grupotextbox = { textBox8, textBox7, textBox1, textBox2, textBox6};
            TextBox[] Idtextbox = { textBox8, textBox7 };
            navegador1.textbox = Grupotextbox;
            navegador1.tabla = dataGridView1;
            navegador1.textboxi = Idtextbox;
            navegador1.actual = this;
            navegador1.cargar(dataGridView1, Grupotextbox, "libreria");*/
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            TextBox[] Grupo = { textBox8, textBox7, textBox1, textBox2, textBox6 };
            cn.ingresarm(Grupo, dataGridView1);
            actualizardatagriew();
            limpiar();
            MessageBox.Show("Registro insertado con éxito!!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextBox[] Grupo = { textBox8, textBox7, textBox1, textBox2, textBox6 };
            cn.delete(Grupo, dataGridView1);
            actualizardatagriew();
            MessageBox.Show("Registro eliminado con éxito!!");
            limpiar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TextBox[] Grupo = { textBox8, textBox7, textBox1, textBox2, textBox6 };
            cn.delete(Grupo, dataGridView1);
            cn.ingresarm(Grupo, dataGridView1);
            actualizardatagriew();
            limpiar();
            MessageBox.Show("Registro modificado con éxito!!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            limpiar();
        }
    }
}
