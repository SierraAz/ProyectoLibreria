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
    public partial class ayuda_productos : Form
    {
        csControlador cn = new csControlador();
        string table, ttipo;
        public ayuda_productos(string tabla, string tipo)
        {
            InitializeComponent();
            table = tabla;
            ttipo = tipo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell != null)
            {


                cn.IDS = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                this.Close();

            }
        }
        private void ayuda_productos_Load(object sender, EventArgs e)
        {
            cn.llenartablaa(table, dataGridView1);
        }
    }
}
