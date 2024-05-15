//Revisado por Ester Lopez fecha 26/02/2023
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using NavegadorControlador;
using Vista;

namespace NavegadorVista
{
    public partial class Navegador : UserControl
    {
        
        //Se cambio los nombres de las variables para que sean más clara la referencia
        csControlador conexionControlador = new csControlador();

        Seguridad_Controlador.Controlador conexionSeguridad = new Seguridad_Controlador.Controlador();
        public Navegador()
        {
            InitializeComponent();
        }

        public Form actual = new Form();
        public TextBox[] textbox = { };
        public TextBox[] textboxi = { };
        public DataGridView tabla;
        public static string idApp;

        public void consulta()
        {
            string tablan2 = tabla.Tag.ToString();
            Capa_VistaConsultas.Busqueda_Simple bs = new Capa_VistaConsultas.Busqueda_Simple();

            bs.tableN1 = tablan2;
            Console.WriteLine(tablan2);
            //bs.BuscarT();
            bs.Show();
           
            Console.WriteLine(bs.tableN1);
            
            
        }
        



        int opcion;

       
        public void cargar(DataGridView dtabla, TextBox[] text, string BD)
        {
            IconButton[] botongc = {btnInsert, btnModificar, btnDelete, btnUpdate, btnConsultar, btnReporte, btnNext,
                btnBack,btnStart,btnEnd
            };

            conexionControlador.evaluartabla(dtabla);
            conexionControlador.inicializargrid(dtabla);
            conexionControlador.llenartablainicio(dtabla.Tag.ToString(), dtabla, text);
            conexionControlador.evaluartags(text, dtabla, BD);
            conexionControlador.desactivar(actual);
            bloqStart(botongc);
            

        }
        public void bloqEnd(IconButton[] botongc3)
        {
            for (int i = 0; i < botongc3.Length; i++)
            {
                botongc3[i].Enabled = false;
            }
        }
        public void bloqStart(IconButton[] botongc)// bloque botones al principio
        {
            for (int i = 0; i < botongc.Length; i++)
            {
                botongc[i].Enabled = false;
            }
            
            int[] permisos= conexionSeguridad.getPermisosAplicaion(idApp);
            if (permisos[0] == 1)//Guardar
            {
                botongc[0].Enabled = true;
                botongc[3].Enabled = true;
                botongc[6].Enabled = true;
                botongc[7].Enabled = true;
                botongc[8].Enabled = true;
                botongc[9].Enabled = true;
            }
            if (permisos[1] == 1)//Modifcar
            { 
                botongc[1].Enabled = true;
                botongc[3].Enabled = true;
                botongc[6].Enabled = true;
                botongc[7].Enabled = true;
                botongc[8].Enabled = true;
                botongc[9].Enabled = true;
            }
            if (permisos[2] == 1)//Eliminar
            {
                botongc[2].Enabled = true;
                botongc[3].Enabled = true;
                botongc[6].Enabled = true;
                botongc[7].Enabled = true;
                botongc[8].Enabled = true;
                botongc[9].Enabled = true;
            }
            if (permisos[3] == 1)//Consultar
            {
                botongc[4].Enabled = true;
                botongc[3].Enabled = true;
                botongc[6].Enabled = true;
                botongc[7].Enabled = true;
                botongc[8].Enabled = true;
                botongc[9].Enabled = true;
            }
            if (permisos[4] == 1)//Reportes
            {
                botongc[5].Enabled = true;
            }

        }
       


        private void btnExit_Click(object sender, EventArgs e)
        {
            actual.Close();
        }

        private void ComponenteNavegador_Load(object sender, EventArgs e)
        {
            IconButton[] botongc = { btnSave, btnCancelar };
            conexionControlador.bloquearbotonesGC(botongc, true);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            conexionControlador.moverseIF(tabla, "b");
            conexionControlador.llenartxt(textbox, tabla);
            conexionControlador.desactivar(actual);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            conexionControlador.moverseIF(tabla, "s");
            conexionControlador.llenartxt(textbox, tabla);
            conexionControlador.desactivar(actual);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            conexionControlador.moverseIF(tabla, "i");
            conexionControlador.llenartxt(textbox, tabla);
            conexionControlador.desactivar(actual);
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            conexionControlador.moverseIF(tabla, "f");
            conexionControlador.llenartxt(textbox, tabla);
            conexionControlador.desactivar(actual);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            IconButton[] botongc = { btnSave, btnCancelar };
            IconButton[] botongc3 = {btnInsert, btnModificar, btnDelete, btnUpdate, btnConsultar, btnReporte, btnNext,
                btnBack,btnStart,btnEnd
            };
            bloqEnd(botongc3);
            opcion = 1;
            conexionControlador.limpiar(actual);
            conexionControlador.activar(actual);
            conexionControlador.crearid(textboxi, tabla);
            conexionControlador.bloquearbotonesGC(botongc, false);
            


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            opcion = 3;
            int permiso = conexionControlador.comprobacionvacio(tabla);
            if (permiso != 0)
            {
                IconButton[] botongc = { btnSave, btnCancelar };
                conexionControlador.bloquearbotonesGC(botongc, false);
                IconButton[] botongc3 = {btnInsert, btnModificar, btnDelete, btnUpdate, btnConsultar, btnReporte, btnNext,
                btnBack,btnStart,btnEnd
            };
                bloqEnd(botongc3);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            opcion = 2;
            int permiso = conexionControlador.comprobacionvacio(tabla);
            if(permiso != 0)
            {
                conexionControlador.activar(actual);
                conexionControlador.enfocar(textboxi);
                IconButton[] botongc = { btnSave, btnCancelar };
                conexionControlador.bloquearbotonesGC(botongc, false);
                IconButton[] botongc3 = {btnInsert, btnModificar, btnDelete, btnUpdate, btnConsultar, btnReporte, btnNext,
                btnBack,btnStart,btnEnd
            };
                bloqEnd(botongc3);
            }
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            IconButton[] botongc = { btnSave, btnCancelar };
           
            if (opcion == 1)
            {
                conexionControlador.ingresar(textbox, tabla, botongc, idApp, actual);
                IconButton[] botongc2 = {btnInsert, btnModificar, btnDelete, btnUpdate, btnConsultar, btnReporte, btnNext,
                btnBack,btnStart,btnEnd
                };
                bloqStart(botongc2);
            }
            else if (opcion == 2)
            {
                conexionControlador.actualizar(textbox, tabla, botongc, idApp, actual);
                IconButton[] botongc2 = {btnInsert, btnModificar, btnDelete, btnUpdate, btnConsultar, btnReporte, btnNext,
                btnBack,btnStart,btnEnd
                };
                bloqStart(botongc2);
                // cn.bloquearbotonesGC(botongc, true);
            }
            else if(opcion == 3)
            {
                DialogResult resultado = MessageBox.Show("Desea eliminar el Resgistro", "Eliminar", MessageBoxButtons.YesNo);
                if(resultado == DialogResult.Yes)
                {

                    conexionControlador.delete(textbox, tabla, botongc, idApp, actual);
                    IconButton[] botongc2 = {btnInsert, btnModificar, btnDelete, btnUpdate, btnConsultar, btnReporte, btnNext,
                    btnBack,btnStart,btnEnd
                    };
                    bloqStart(botongc2);
                    //cn.bloquearbotonesGC(botongc, true);
                }
                else if(resultado == DialogResult.No)
                {

                    conexionControlador.limpiar(actual);
                    conexionControlador.desactivar(actual);
                    conexionControlador.llenartxt(textbox, tabla);
                    conexionControlador.bloquearbotonesGC(botongc, true);
                }
               
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            conexionControlador.limpiar(actual);
            conexionControlador.desactivar(actual);
            conexionControlador.llenartxt(textbox, tabla);
            IconButton[] botongc = { btnSave, btnCancelar };
            conexionControlador.bloquearbotonesGC(botongc, true);
            opcion = 0;
            IconButton[] botongc2 = {btnInsert, btnModificar, btnDelete, btnUpdate, btnConsultar, btnReporte, btnNext,
                btnBack,btnStart,btnEnd
                };
            bloqStart(botongc2);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            conexionControlador.llenartablainicio(tabla.Tag.ToString(), tabla, textbox);
            conexionControlador.moverseIF(tabla, "i");
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            Ayuda ayuda = new Ayuda();
            ayuda.Show();

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            consulta();
            conexionSeguridad.setBtitacora(idApp, "Consulta");
            



        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            conexionSeguridad.setBtitacora(idApp, "Reportes");
            Report();
        }

        public void Report()
        {
            conexionControlador.reporte(idApp);
        }
    }
}
