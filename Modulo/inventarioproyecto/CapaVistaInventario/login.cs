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
    public partial class login : Form
    {
        csControlador cn = new csControlador();

        public login()
        {
            InitializeComponent();
        }

        public void Login()
        {
            if (cn.validarLogin(TBusuario.Text, csControlador.SetHash(TBcontrasena.Text)))
            {
                csControlador.Username = csControlador.SetHash(TBusuario.Text);
                Form1 b = new Form1();
                b.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Contraseña o Usuario Incorrecta");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                // TBcontraseña.PasswordChar = '*';
                TBcontrasena.PasswordChar = '\0';
            }
            else
                       if (TBcontrasena.Text != "")
            {
                // TBcontraseña.PasswordChar = '\0';
                TBcontrasena.PasswordChar = '*';
            }
        }

        private void TBusuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
