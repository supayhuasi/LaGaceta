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
using BusquedaLaGaceta.Utils;
using BusquedaLaGaceta.Gui;

namespace BusquedaLaGaceta
{
    public partial class Form1 : Form
    {
        private LuceneService luceneService;
        private ManejoRollos rollos;
        private Image imagenSeleccionada;
        private ImageUtils funcionesImagenes;
        public Form1()
        {
            luceneService= new LuceneService();
            rollos = new ManejoRollos();
            funcionesImagenes = new ImageUtils();
            InitializeComponent();
            panel1.Controls.Add(pictureBox1);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            int i=0;
            List<SearchResult> resultados;
            if(!chkDiario.Checked)
            resultados = luceneService.Search(txtBuscar.Text,fechaDesde.Value,fechaHasta.Value,true);
            else
                resultados = luceneService.Search(txtBuscar.Text, fechaDesde.Value, fechaDesde.Value, true);
            lresultado.Text = resultados.Count.ToString();
            foreach (var resultado in resultados)
            {
                if(i==0)
                setImage(rollos.FilePath(resultado.Name));
                    //
                    // Another node following the first node.
                    //
                    TreeNode treeNode = new TreeNode(rollos.nombreArchivoPagina(resultado.Name));
                    treeView1.Nodes.Add(treeNode);
                    i++;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }        

        public bool setImage(string path)
        {
            try
            {
                pictureBox1.Image = Image.FromFile(path);
                imagenSeleccionada = Image.FromFile(path);
                pictureBox1.Width = pictureBox1.Image.Width;
                pictureBox1.Height = pictureBox1.Image.Height;
                return true;

            }
            catch (Exception ex)
            {
                pictureBox1.Image = Image.FromFile("E:\\ARCHIVOS INDEXING\\noencontrada.png");
                imagenSeleccionada =  Image.FromFile("E:\\ARCHIVOS INDEXING\\noencontrada.png");
                return false;
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string selectedNodeText = e.Node.Text;
            setImage(rollos.FileRenamePath(selectedNodeText));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ancho = pictureBox1.Width + pictureBox1.Width / 2;
            var alto = pictureBox1.Height + pictureBox1.Height / 2;

            pictureBox1.Image = ImageUtils.ScaleImage(imagenSeleccionada, ancho, alto);
            pictureBox1.Width = pictureBox1.Image.Width;
            pictureBox1.Height = pictureBox1.Image.Height;
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void btnMinizar_Click(object sender, EventArgs e)
        {

            var ancho = pictureBox1.Width - pictureBox1.Width / 2;
            var alto = pictureBox1.Height - pictureBox1.Height / 2;

            pictureBox1.Image = ImageUtils.ScaleImage(pictureBox1.Image,ancho , alto);
            pictureBox1.Width = pictureBox1.Image.Width;
            pictureBox1.Height = pictureBox1.Image.Height;


        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void usuariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Usuarios usuarios = new Usuarios();
            usuarios.Show();  
        }

        private void chkDiario_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDiario.Checked == true)
            {
                fechaHasta.Enabled = false;
                chkRango.Checked = false;
            }
            else
            {
                fechaHasta.Enabled = true;
                chkRango.Checked = true;
            }
        }

        private void chkRango_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRango.Checked == true)
            {
                fechaHasta.Enabled = true;
                chkDiario.Checked = false;
            }
            else
            {
                fechaHasta.Enabled = false;
                chkDiario.Checked = true;
            }
        }

        private void perfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Perfiles usuarios = new Perfiles();
            usuarios.Show();  
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = "";
            treeView1.Nodes.Clear();
        }

    }
}
