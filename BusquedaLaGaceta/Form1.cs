using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleLuceneSearch;

namespace BusquedaLaGaceta
{
    public partial class Form1 : Form
    {
        private LuceneService luceneService;
        public Form1()
        {
            luceneService= new LuceneService();            
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            luceneService.Search(txtBuscar.Text);
        }
    }
}
