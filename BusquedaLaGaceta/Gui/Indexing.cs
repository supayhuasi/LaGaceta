using BusquedaLaGaceta.Utils;
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
        private ManejoRollos manejoRollos { get; set; }
        public Indexing()
        {
            InitializeComponent();
            luceneService = new LuceneService();
            manejoRollos = new ManejoRollos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string directorio = txtDirTXT.Text;

            var ficheros = Directory.GetFiles(directorio);
            List<SampleDataFileRow> lista= new List<SampleDataFileRow>();
            var nombreImagenes = File.ReadAllText(txtImagenes.Text).Replace(".JPG","").Split(',');
            //var a = nombreImagenes.OrderByDescending(x=>x.fi)
            int i = 0;
            if (ficheros.Count() == nombreImagenes.Count())
            {
                foreach (var fichero in ficheros)
                {

                    string text = System.IO.File.ReadAllText(fichero);
                    SampleDataFileRow aux = new SampleDataFileRow();
                    aux.CONTENT = text.ToLower();
                    aux.PATH = fichero;
                    aux.NAME = Path.GetFileName(nombreImagenes[i]);
                    manejoRollos.InsertFileNames(Properties.Resources.Imagenes.Replace("\\\\","\\") + txtNombreRollo.Text, aux.NAME + ".JPG", aux.NAME + ".JPG");
                    lista.Add(aux);
                    i++;

                }
            }
            else
            {
                MessageBox.Show("La cantidad de archivos son diferentes");
            }
            luceneService.BuildIndex(lista,txtDirLucene.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1folder = new FolderBrowserDialog();
            if (folderBrowserDialog1folder.ShowDialog() == DialogResult.OK)
            {
                txtDirTXT.Text = folderBrowserDialog1folder.SelectedPath;                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1folder = new FolderBrowserDialog();
            if (folderBrowserDialog1folder.ShowDialog() == DialogResult.OK)
            {
                txtDirLucene.Text = folderBrowserDialog1folder.SelectedPath;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog folderBrowserDialog1folder= new OpenFileDialog();
            if (folderBrowserDialog1folder.ShowDialog() == DialogResult.OK)
            {
                txtImagenes.Text = folderBrowserDialog1folder.FileName;
            }
        }
    }
}
