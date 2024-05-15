using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVistaInventario
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void procesoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool abierto = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "proceso_restock")
                {
                    abierto = true;
                    f.Focus();
                    break;
                }
            }
            if (abierto == false)
            {
                proceso_restock rep = new proceso_restock();
                rep.MdiParent = this;
                rep.Show();
            }
        }

        private void procesoVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool abierto = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "proceso_venta")
                {
                    abierto = true;
                    f.Focus();
                    break;
                }
            }
            if (abierto == false)
            {
                proceso_venta rep = new proceso_venta();
                rep.MdiParent = this;
                rep.Show();
            }
        }

        private void mantenimientoProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool abierto = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "mantenimiento_proveedor")
                {
                    abierto = true;
                    f.Focus();
                    break;
                }
            }
            if (abierto == false)
            {
                mantenimiento_proveedor rep = new mantenimiento_proveedor();
                rep.MdiParent = this;
                rep.Show();
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void mantenimientoProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool abierto = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "mantenimiento_producto")
                {
                    abierto = true;
                    f.Focus();
                    break;
                }
            }
            if (abierto == false)
            {
                mantenimiento_producto rep = new mantenimiento_producto();
                rep.MdiParent = this;
                rep.Show();
            }
        }

        private void mantenimientoCatalogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool abierto = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "mantenimiento_categoria")
                {
                    abierto = true;
                    f.Focus();
                    break;
                }
            }
            if (abierto == false)
            {
                mantenimiento_categoria rep = new mantenimiento_categoria();
                rep.MdiParent = this;
                rep.Show();
            }
        }

        private void reporteVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool abierto = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "reporteventascs")
                {
                    abierto = true;
                    f.Focus();
                    break;
                }
            }
            if (abierto == false)
            {
                reporteventascs rep = new reporteventascs();
                rep.MdiParent = this;
                rep.Show();
            }
        }

        private void reporteComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool abierto = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "reportecompras")
                {
                    abierto = true;
                    f.Focus();
                    break;
                }
            }
            if (abierto == false)
            {
                reportecompras rep = new reportecompras();
                rep.MdiParent = this;
                rep.Show();
            }
        }

        private void reporteProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool abierto = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "reporteproducto")
                {
                    abierto = true;
                    f.Focus();
                    break;
                }
            }
            if (abierto == false)
            {
                reporteproducto rep = new reporteproducto();
                rep.MdiParent = this;
                rep.Show();
            }
        }

        private void reporteCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool abierto = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "reportecategoria")
                {
                    abierto = true;
                    f.Focus();
                    break;
                }
            }
            if (abierto == false)
            {
                reportecategoria rep = new reportecategoria();
                rep.MdiParent = this;
                rep.Show();
            }
        }

        private void reporteProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool abierto = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "reporteproveedor")
                {
                    abierto = true;
                    f.Focus();
                    break;
                }
            }
            if (abierto == false)
            {
                reporteproveedor rep = new reporteproveedor();
                rep.MdiParent = this;
                rep.Show();
            }
        }

        private void mantenimientoVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool abierto = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "mantenimiento_ventas")
                {
                    abierto = true;
                    f.Focus();
                    break;
                }
            }
            if (abierto == false)
            {
                mantenimiento_ventas rep = new mantenimiento_ventas();
                rep.MdiParent = this;
                rep.Show();
            }
        }

        private void mantenimientoComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool abierto = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "mantenimiento_compras")
                {
                    abierto = true;
                    f.Focus();
                    break;
                }
            }
            if (abierto == false)
            {
                mantenimiento_compras rep = new mantenimiento_compras();
                rep.MdiParent = this;
                rep.Show();
            }
        }
    }
}
