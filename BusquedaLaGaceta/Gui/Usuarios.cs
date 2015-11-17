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
    public partial class Usuarios : Form
    {
        private ManejoUsuarios usuarioDAL { get; set; }
        public Usuarios()
        {
            usuarioDAL = new ManejoUsuarios();
            InitializeComponent();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'aIDataSet.Table_User' table. You can move, or remove it, as needed.
            this.table_UserTableAdapter.Fill(this.aIDataSet.Table_User);
            // TODO: This line of code loads data into the 'aIDataSet.Table_User' table. You can move, or remove it, as needed.            

        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            UsuarioAM usuarios = new UsuarioAM();
            usuarios.Show();  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var idUsuario = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            var resultado = usuarioDAL.EliminarUsuario(idUsuario);
            if (resultado)
                MessageBox.Show("Se elimino correctamente el usuario");
            else
                MessageBox.Show("No se pudo eliminar correctamente el usuario");
            this.table_UserTableAdapter.Fill(this.aIDataSet.Table_User);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var idUsuario = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            var usuario = usuarioDAL.buscarUsuario(idUsuario);
            UsuarioAM usuarios = new UsuarioAM(usuario);
            usuarios.Show();  
        }
    }
}
