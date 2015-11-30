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
    public partial class GenerarTXT : Form
    {
        public GenerarTXT()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1folder = new FolderBrowserDialog();
            if (folderBrowserDialog1folder.ShowDialog() == DialogResult.OK)
            {
                txtImagenes.Text = folderBrowserDialog1folder.SelectedPath;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1folder = new FolderBrowserDialog();
            if (folderBrowserDialog1folder.ShowDialog() == DialogResult.OK)
            {
                txtTxt.Text = folderBrowserDialog1folder.SelectedPath;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string directorio = txtImagenes.Text;

            var ficheros = Directory.GetFiles(directorio);
            string nombres= "";
            int i = 0;
            var directorioDestino = txtTxt.Text;

            //List<SampleDataFileRow> lista = new List<SampleDataFileRow>();
            foreach (var fichero in ficheros)
            {
                nombres = nombres + "," + fichero.Replace(directorio + "\\", "");                

            }
            File.WriteAllText(directorioDestino + "/55.txt", nombres);
            //luceneService.BuildIndex(lista, txtDirLucene.Text);
        }
    }
}
