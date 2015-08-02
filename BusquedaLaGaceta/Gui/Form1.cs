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
            int i=0;
            var resultados = luceneService.Search(txtBuscar.Text,fechaDesde.Value,fechaHasta.Value,true);
            foreach (var resultado in resultados)
            {
                if (i == 0)
                    imagenDiario.Image = Image.FromFile("E:\\ARCHIVOS INDEXING\\R341-21-03-1970-26-04-1970\\01-04-1970-1.jpg");
            }
        }
    }
}
