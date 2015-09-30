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
        public Usuarios()
        {
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
    }
}
