using BusquedaLaGaceta.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusquedaLaGaceta.Gui
{
    public partial class UsuarioAM : Form
    {
        private ManejoUsuarios usuarioDAL { get; set; }
        private bool modificar { get; set; }
        private int idUsuario { get; set; }
        public UsuarioAM()
        {
            InitializeComponent();
            usuarioDAL = new ManejoUsuarios();
            cboPerfiles.DataSource = usuarioDAL.listaPerfiles();
            cboPerfiles.DisplayMember = "name";
            cboPerfiles.ValueMember = "id";
            modificar = false;
        }
        public UsuarioAM(Table_User usuario)
        {
            InitializeComponent();
            usuarioDAL = new ManejoUsuarios();
            cboPerfiles.DataSource = usuarioDAL.listaPerfiles();
            cboPerfiles.DisplayMember = "name";
            cboPerfiles.ValueMember = "id";
            txtUsuario.Text = usuario.User_Name;
            txtContrasenia.Text = usuario.User_Password;
            idUsuario = usuario.ID_User;
            modificar = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!modificar)
            {
                var resultado = usuarioDAL.AgregarUsuario(txtUsuario.Text, txtContrasenia.Text, txtContrasenia2.Text);
                if (resultado)
                {
                    MessageBox.Show("Se agrego el usuario correctamente");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Claves no coinciden.");
                }
            }
            else
            {
                var resultado = usuarioDAL.ModificarUsuario(idUsuario,txtUsuario.Text, txtContrasenia.Text, txtContrasenia2.Text);
                if (resultado)
                {
                    MessageBox.Show("Se agrego el usuario correctamente");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Claves no coinciden.");
                }
            }
            

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
