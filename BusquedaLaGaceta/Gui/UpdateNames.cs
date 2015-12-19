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
    public partial class UpdateNames : Form
    {
        public UpdateNames()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1folder = new FolderBrowserDialog();
            if (folderBrowserDialog1folder.ShowDialog() == DialogResult.OK)
            {
                txtRollo.Text = folderBrowserDialog1folder.SelectedPath;
            }
        }

        private void UpdateNames_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string nombres= "";
            int numeroPagina = 0;
            string sNumeroPagina="";
            
            var ficherosOrigen = Directory.GetFiles(txtRollo.Text);                        
                int i = 0;
                foreach (var fichero in ficherosOrigen)
                {
                    var nombreOrigen = Path.GetFileName(fichero);
                    var numeroPaginas = fichero.Replace(txtRollo.Text + "\\", "").Split('-');
                    numeroPagina = Convert.ToInt32(numeroPaginas[3].Replace(".JPG", "").ToString());
                    if (numeroPagina < 10)
                        sNumeroPagina = "0" + numeroPagina;
                    else
                        sNumeroPagina = numeroPagina.ToString();
                    nombres = fichero.Replace(txtRollo.Text + "\\", "").Replace(numeroPagina + ".JPG", sNumeroPagina + ".JPG");
                    var newPath = fichero.Replace(nombreOrigen, nombres);
                    File.Move(fichero, newPath);                   
                    i++;
                }
                MessageBox.Show("Se renombro correctamente " + i + " archivos");
            }            
        }
    }

