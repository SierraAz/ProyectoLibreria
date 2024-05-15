
namespace CapaVistaInventario
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.procesosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.procesoVentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.procesoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mantenimientosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mantenimientoProveedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mantenimientoProductoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mantenimientoCatalogoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mantenimientoVentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mantenimientoComprasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.herramientasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generarReporteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteVentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteComprasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteProductosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteCategoriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteProveedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionarUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(209)))), ((int)(((byte)(235)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.procesosToolStripMenuItem,
            this.mantenimientosToolStripMenuItem,
            this.herramientasToolStripMenuItem,
            this.cerrarSesiónToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1143, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // procesosToolStripMenuItem
            // 
            this.procesosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.procesoVentasToolStripMenuItem,
            this.procesoToolStripMenuItem});
            this.procesosToolStripMenuItem.Name = "procesosToolStripMenuItem";
            this.procesosToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.procesosToolStripMenuItem.Text = "Procesos";
            // 
            // procesoVentasToolStripMenuItem
            // 
            this.procesoVentasToolStripMenuItem.Name = "procesoVentasToolStripMenuItem";
            this.procesoVentasToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.procesoVentasToolStripMenuItem.Text = "Proceso ventas";
            this.procesoVentasToolStripMenuItem.Click += new System.EventHandler(this.procesoVentasToolStripMenuItem_Click);
            // 
            // procesoToolStripMenuItem
            // 
            this.procesoToolStripMenuItem.Name = "procesoToolStripMenuItem";
            this.procesoToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.procesoToolStripMenuItem.Text = "Proceso compras";
            this.procesoToolStripMenuItem.Click += new System.EventHandler(this.procesoToolStripMenuItem_Click);
            // 
            // mantenimientosToolStripMenuItem
            // 
            this.mantenimientosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mantenimientoProveedorToolStripMenuItem,
            this.mantenimientoProductoToolStripMenuItem,
            this.mantenimientoCatalogoToolStripMenuItem,
            this.mantenimientoVentasToolStripMenuItem,
            this.mantenimientoComprasToolStripMenuItem});
            this.mantenimientosToolStripMenuItem.Name = "mantenimientosToolStripMenuItem";
            this.mantenimientosToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.mantenimientosToolStripMenuItem.Text = "Mantenimientos";
            // 
            // mantenimientoProveedorToolStripMenuItem
            // 
            this.mantenimientoProveedorToolStripMenuItem.Name = "mantenimientoProveedorToolStripMenuItem";
            this.mantenimientoProveedorToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
            this.mantenimientoProveedorToolStripMenuItem.Text = "Mantenimiento proveedor";
            this.mantenimientoProveedorToolStripMenuItem.Click += new System.EventHandler(this.mantenimientoProveedorToolStripMenuItem_Click);
            // 
            // mantenimientoProductoToolStripMenuItem
            // 
            this.mantenimientoProductoToolStripMenuItem.Name = "mantenimientoProductoToolStripMenuItem";
            this.mantenimientoProductoToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
            this.mantenimientoProductoToolStripMenuItem.Text = "Mantenimiento producto";
            this.mantenimientoProductoToolStripMenuItem.Click += new System.EventHandler(this.mantenimientoProductoToolStripMenuItem_Click);
            // 
            // mantenimientoCatalogoToolStripMenuItem
            // 
            this.mantenimientoCatalogoToolStripMenuItem.Name = "mantenimientoCatalogoToolStripMenuItem";
            this.mantenimientoCatalogoToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
            this.mantenimientoCatalogoToolStripMenuItem.Text = "Mantenimiento categoria de producto";
            this.mantenimientoCatalogoToolStripMenuItem.Click += new System.EventHandler(this.mantenimientoCatalogoToolStripMenuItem_Click);
            // 
            // mantenimientoVentasToolStripMenuItem
            // 
            this.mantenimientoVentasToolStripMenuItem.Name = "mantenimientoVentasToolStripMenuItem";
            this.mantenimientoVentasToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
            this.mantenimientoVentasToolStripMenuItem.Text = "Mantenimiento ventas";
            this.mantenimientoVentasToolStripMenuItem.Click += new System.EventHandler(this.mantenimientoVentasToolStripMenuItem_Click);
            // 
            // mantenimientoComprasToolStripMenuItem
            // 
            this.mantenimientoComprasToolStripMenuItem.Name = "mantenimientoComprasToolStripMenuItem";
            this.mantenimientoComprasToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
            this.mantenimientoComprasToolStripMenuItem.Text = "Mantenimiento compras";
            this.mantenimientoComprasToolStripMenuItem.Click += new System.EventHandler(this.mantenimientoComprasToolStripMenuItem_Click);
            // 
            // herramientasToolStripMenuItem
            // 
            this.herramientasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generarReporteToolStripMenuItem,
            this.gestionarUsuarioToolStripMenuItem});
            this.herramientasToolStripMenuItem.Name = "herramientasToolStripMenuItem";
            this.herramientasToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.herramientasToolStripMenuItem.Text = "Herramientas";
            // 
            // generarReporteToolStripMenuItem
            // 
            this.generarReporteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reporteVentasToolStripMenuItem,
            this.reporteComprasToolStripMenuItem,
            this.reporteProductosToolStripMenuItem,
            this.reporteCategoriaToolStripMenuItem,
            this.reporteProveedorToolStripMenuItem});
            this.generarReporteToolStripMenuItem.Name = "generarReporteToolStripMenuItem";
            this.generarReporteToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.generarReporteToolStripMenuItem.Text = "Generar reporte";
            // 
            // reporteVentasToolStripMenuItem
            // 
            this.reporteVentasToolStripMenuItem.Name = "reporteVentasToolStripMenuItem";
            this.reporteVentasToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.reporteVentasToolStripMenuItem.Text = "Reporte ventas";
            this.reporteVentasToolStripMenuItem.Click += new System.EventHandler(this.reporteVentasToolStripMenuItem_Click);
            // 
            // reporteComprasToolStripMenuItem
            // 
            this.reporteComprasToolStripMenuItem.Name = "reporteComprasToolStripMenuItem";
            this.reporteComprasToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.reporteComprasToolStripMenuItem.Text = "Reporte compras";
            this.reporteComprasToolStripMenuItem.Click += new System.EventHandler(this.reporteComprasToolStripMenuItem_Click);
            // 
            // reporteProductosToolStripMenuItem
            // 
            this.reporteProductosToolStripMenuItem.Name = "reporteProductosToolStripMenuItem";
            this.reporteProductosToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.reporteProductosToolStripMenuItem.Text = "Reporte productos";
            this.reporteProductosToolStripMenuItem.Click += new System.EventHandler(this.reporteProductosToolStripMenuItem_Click);
            // 
            // reporteCategoriaToolStripMenuItem
            // 
            this.reporteCategoriaToolStripMenuItem.Name = "reporteCategoriaToolStripMenuItem";
            this.reporteCategoriaToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.reporteCategoriaToolStripMenuItem.Text = "Reporte categoria";
            this.reporteCategoriaToolStripMenuItem.Click += new System.EventHandler(this.reporteCategoriaToolStripMenuItem_Click);
            // 
            // reporteProveedorToolStripMenuItem
            // 
            this.reporteProveedorToolStripMenuItem.Name = "reporteProveedorToolStripMenuItem";
            this.reporteProveedorToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.reporteProveedorToolStripMenuItem.Text = "Reporte proveedor";
            this.reporteProveedorToolStripMenuItem.Click += new System.EventHandler(this.reporteProveedorToolStripMenuItem_Click);
            // 
            // gestionarUsuarioToolStripMenuItem
            // 
            this.gestionarUsuarioToolStripMenuItem.Name = "gestionarUsuarioToolStripMenuItem";
            this.gestionarUsuarioToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.gestionarUsuarioToolStripMenuItem.Text = "Gestionar usuario";
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            this.cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            this.cerrarSesiónToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
            this.cerrarSesiónToolStripMenuItem.Text = "Salir del programa";
            this.cerrarSesiónToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesiónToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 592);
            this.ControlBox = false;
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Menu principal";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem procesosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mantenimientosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem herramientasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem procesoVentasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mantenimientoProveedorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mantenimientoProductoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generarReporteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionarUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem procesoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mantenimientoCatalogoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteVentasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteComprasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteProductosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteCategoriaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteProveedorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mantenimientoVentasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mantenimientoComprasToolStripMenuItem;
    }
}

