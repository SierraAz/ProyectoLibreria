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
    public partial class ayuda_venta : Form
    {
        csControlador cn = new csControlador();
        string table, ttipo;
        public ayuda_venta(string tabla, string tipo)
        {
            InitializeComponent();
            table = tabla;
            ttipo = tipo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ayuda_venta_Load(object sender, EventArgs e)
        {
            cn.llenartablaa(table, dataGridView1);
        }
    }
}
