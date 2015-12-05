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
    public partial class Renombrar : Form
    {
        public Renombrar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ficherosOrigen = Directory.GetFiles(txtOrigen.Text);
            var ficherosDestino = Directory.GetFiles(txtDestino.Text);
            if(ficherosDestino.Count()==ficherosOrigen.Count())
            {
                int i = 0;
                foreach(var fichero in ficherosOrigen)
                {
                    var nombreOrigen = Path.GetFileName(fichero);
                    var nombreDestino = Path.GetFileName(ficherosDestino[i]);
                    var newPath = ficherosDestino[i].Replace(nombreDestino,nombreOrigen);
                    File.Move(ficherosDestino[i], newPath);
                    i++;
                }
                MessageBox.Show("Se renombro correctamente " + i + " archivos");
            }
            else
            {
                MessageBox.Show("La cantidad de archivos son distintas");
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1folder = new FolderBrowserDialog();
            if (folderBrowserDialog1folder.ShowDialog() == DialogResult.OK)
            {
                txtOrigen.Text = folderBrowserDialog1folder.SelectedPath;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1folder = new FolderBrowserDialog();
            if (folderBrowserDialog1folder.ShowDialog() == DialogResult.OK)
            {
                txtDestino.Text = folderBrowserDialog1folder.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
