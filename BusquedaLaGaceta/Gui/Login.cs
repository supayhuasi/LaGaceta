using BusquedaLaGaceta.Seguridad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusquedaLaGaceta
{
    public partial class Login : Form
    {
        private SeguridadLogin segLogin;
        public Login()
        {
            InitializeComponent();
            segLogin = new SeguridadLogin();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var bREsultado =segLogin.ValidarUsuario(textBox1.Text, textBox2.Text);
            if (bREsultado)
            {
                Form1 settingsForm = new Form1();
                settingsForm.Show();                
            }
        }
        
    }
}
