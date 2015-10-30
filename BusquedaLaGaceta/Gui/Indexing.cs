using SimpleLuceneSearch;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusquedaLaGaceta.Gui
{
    public partial class Indexing : Form
    {
        private LuceneService luceneService { get; set; }
        public Indexing()
        {
            InitializeComponent();
            luceneService = new LuceneService();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string directorio = "E:\\Archivos de Texto\\R555-16-12-1999-15-01-2000";

            var ficheros = Directory.GetFiles(directorio);
            List<SampleDataFileRow> lista= new List<SampleDataFileRow>(); 
            foreach (var fichero in ficheros)
            {
                string text = System.IO.File.ReadAllText(fichero);
                SampleDataFileRow aux = new SampleDataFileRow();
                aux.CONTENT= text;
                aux.PATH = fichero;
                aux.NAME = fichero.Replace(directorio,"");
                lista.Add(aux);
            }
            luceneService.BuildIndex(lista);
        }
    }
}
