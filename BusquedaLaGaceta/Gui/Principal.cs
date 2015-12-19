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
using System.Drawing.Imaging;
using System.Threading;

namespace BusquedaLaGaceta
{
    public partial class Form1 : Form
    {
        private LuceneService luceneService { get; set; }
        private ManejoRollos rollos { get; set; }
        private Image imagenSeleccionada { get; set; }
        private ImageUtils funcionesImagenes { get; set; }
        private string NameImagen { get; set; }
        private string rolloImagen { get; set; }
        private Thread Busqueda = null;
        private string lbResultadoc { get; set; }
        private string tree { get; set; }
        //private TreeNode treePadree { get; set; }
        private string treePadreValor { get; set; }
        public delegate void UpdateUI();
        public Form1()
        {
            luceneService= new LuceneService();
            rollos = new ManejoRollos();
            funcionesImagenes = new ImageUtils();
            InitializeComponent();
            panel1.Controls.Add(pictureBox1);
            progressBar1.Value = 1;
            progressBar1.Maximum = 20;
            progressBar1.Minimum = 1;
            //fechaDesde.MinDate = new DateTime(int.Parse(Properties.Resources.AnioInicio),int.Parse(Properties.Resources.MesInicio),int.Parse(Properties.Resources.DiaInicio));
            //fechaDesde.Value = new DateTime(int.Parse(Properties.Resources.AnioInicio), int.Parse(Properties.Resources.MesInicio), int.Parse(Properties.Resources.DiaInicio));
            //fechaHasta.Value = new DateTime(int.Parse(Properties.Resources.AnioFin), int.Parse(Properties.Resources.MesFin), int.Parse(Properties.Resources.DiaFin));
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            deshabilitarBotonesImagenes();
            progressBar1.Value = 1;
            progressBar1.Maximum = 20;
            progressBar1.Minimum = 1;
            btnBuscar.Enabled = false;
            Busqueda= new Thread(new ThreadStart(SearchThread));

            Busqueda.IsBackground= true;
            Busqueda.Start();
            Thread.Sleep(500);
            
        }
        private void SearchThread()
        {            
            treeView1.Invoke(new UpdateUI(limpiezaTree));
            int i = 0;
            string aux="";
            //var fechaCortadas = txtFechaDesde.Text.Split('/');
            DateTime fechaHasta= new DateTime();
            //DateTime fechaDesde = new DateTime(int.Parse(fechaCortadas[2]), int.Parse(fechaCortadas[1]), int.Parse(fechaCortadas[0]));
            DateTime fechaDesde = dateDesde.Value;
            if (!chkDiario.Checked)
            {
             //   fechaCortadas = txtFechaHasta.Text.Split('/');
                fechaHasta = dateHasta.Value;
            }
            List<SearchResult> resultados;
            if (!chkDiario.Checked)
                resultados = luceneService.Search(txtBuscar.Text, fechaDesde, fechaHasta, true);
            else
                resultados = luceneService.Search(txtBuscar.Text, fechaDesde, fechaDesde, true);
            lbResultado = resultados.Count.ToString();
            lresultado.Invoke(new UpdateUI(updatelresultado));
            var listResultados = resultados.OrderBy(x=>x.Path);
            
            progressBar1.Invoke(new UpdateUI(setProgressBarMaximo));
            foreach (var resultado in listResultados)
            {
                if (i == 0)
                    setImage(resultado.Name);
                //
                // Another node following the first node.
                //
                progressBar1.Invoke(new UpdateUI(setProgressBarBusqueda));
                if (!aux.Equals(resultado.RollNumber))
                {
                    aux = resultado.RollNumber;                    
                    treePadreValor = resultado.RollNumber;
                    tree = rollos.nombreArchivoPagina(resultado.Name);
                    treeView1.Invoke(new UpdateUI(updateTreeView));    
                }
                else
                {
                    treePadreValor = resultado.RollNumber;
                    tree = rollos.nombreArchivoPagina(resultado.Name);
                    treeView1.Invoke(new UpdateUI(addTreePadre));
                    aux = treePadreValor;
                }
                //treeView1.Invoke(new UpdateUI(updateTreeView));
              //  setNodo(resultado.Name);
                i++;
            }
            btnBuscar.Invoke(new UpdateUI(habiliarBuscar));
            btnPantalla.Invoke(new UpdateUI(habilitarBotonesImagenes));
        }
        public void habiliarBuscar()
        {
            btnBuscar.Enabled = true;
        }
        public void setProgressBarMaximo()
        {
            progressBar1.Maximum = int.Parse(lbResultado)+1;
            progressBar1.Value = 1;            
            progressBar1.Minimum = 1;

        }
        public void setProgressBarBusqueda()
        {
            progressBar1.Value += 1;

        }
        public void limpiezaTree()
        {
            treeView1.Nodes.Clear();
        }
        public void updatelresultado()
        {
            lresultado.Text= lbResultado;
        }
        public void updateTreeView()
        {
            TreeNode aux = new TreeNode(tree);
            treeView1.Nodes.Add(treePadreValor,treePadreValor);
            int indice = treeView1.Nodes.IndexOfKey(treePadreValor);
            treeView1.Nodes[treePadreValor].Nodes.Add(aux);
//            treeView1.Nodes.Insert(indice, tree);
        }
        public void addTreePadre()
        {
            int indice = treeView1.Nodes.IndexOfKey(treePadreValor);
            //treeView1.Nodes.Insert(indice, tree);
            treeView1.Nodes[treePadreValor].Nodes.Add(new TreeNode(tree));
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            progressBar1.Value = 1;
            progressBar1.Maximum = 20;
            progressBar1.Minimum = 1;
            
        }        

        public bool setImage(string path)
        {
            try
            {
                NameImagen = path;
                path = rollos.FilePath(path);
                pictureBox1.Image = Image.FromFile(path);
                imagenSeleccionada = Image.FromFile(path);                
                return true;

            }
            catch (Exception ex)
            {
                pictureBox1.Image = Image.FromFile(Properties.Resources.ImagenNoEncontrada);
                imagenSeleccionada = Image.FromFile(Properties.Resources.ImagenNoEncontrada);
                return false;
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!e.Node.Text.Contains("R"))
            {
                string selectedNodeText = e.Node.Text;
                setImage(selectedNodeText);
            }
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
            Minimizar();
        }
        private void Minimizar()
        {
            var ancho = pictureBox1.Width - pictureBox1.Width / 2;
            var alto = pictureBox1.Height - pictureBox1.Height / 2;

            pictureBox1.Image = ImageUtils.ScaleImage(pictureBox1.Image, ancho, alto);
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
                dateHasta.Enabled = false;
                chkRango.Checked = false;
            }
            else
            {
                dateHasta.Enabled = true;
                chkRango.Checked = true;
            }
        }

        private void chkRango_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRango.Checked == true)
            {
                dateHasta.Enabled = true;
                chkDiario.Checked = false;
            }
            else
            {
                dateHasta.Enabled = false;
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

        private void btnMaximizar_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            try { 
            xUp = e.X;
            yUp = e.Y;

            Rectangle rec = new Rectangle(xDown, yDown, Math.Abs(xUp - xDown), Math.Abs(yUp - yDown));

            using (Pen pen = new Pen(Color.YellowGreen, 3))
            {

                pictureBox1.CreateGraphics().DrawRectangle(pen, rec);
            }

            xDown = xDown * pictureBox1.Image.Width / pictureBox1.Width;
            yDown = yDown * pictureBox1.Image.Height / pictureBox1.Height;

            xUp = xUp * pictureBox1.Image.Width / pictureBox1.Width;
            yUp = yUp * pictureBox1.Image.Height / pictureBox1.Height;

            rectCropArea = new Rectangle(xDown, yDown, Math.Abs(xUp - xDown), Math.Abs(yUp - yDown));
            }
            catch(Exception ex)
            {
                
            }
        }


        public int xDown { get; set; }

        public int yDown { get; set; }

        public int xUp { get; set; }

        public int yUp { get; set; }

        public Rectangle rectCropArea { get; set; }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox1.Invalidate();

            xDown = e.X;
            yDown = e.Y;
        }

        private void btnCortar_Click(object sender, EventArgs e)
        {

            imagenSeleccionada = ImageUtils.recortarImagen(pictureBox1.Image, rectCropArea);
            pictureBox1.Image = imagenSeleccionada;
            btnGuardar.Enabled = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1folder = new FolderBrowserDialog();
            if (folderBrowserDialog1folder.ShowDialog() == DialogResult.OK)
            {                
                pictureBox1.Image.Save(folderBrowserDialog1folder.SelectedPath + "\\" + NameImagen, ImageFormat.Jpeg);
                
            }
            
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if(Busqueda!=null)
            Busqueda.Abort();
            progressBar1.Value = 1;
            progressBar1.Maximum = 20;
            progressBar1.Minimum = 1;
            limpiezaTree();
            Busqueda = null;
            btnBuscar.Enabled = true;
            luceneService = new LuceneService();
            rollos = new ManejoRollos();
            funcionesImagenes = new ImageUtils();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            if(pictureBox1.Width > 1500)
            { 
            var ancho = pictureBox1.Width / 6;
            var alto =  pictureBox1.Height / 6;

            pictureBox1.Image = ImageUtils.ScaleImage(pictureBox1.Image, ancho, alto);
            pictureBox1.Width = pictureBox1.Image.Width;
            pictureBox1.Height = pictureBox1.Image.Height;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
        private void habilitarBotonesImagenes()
        {
            btnCortar.Enabled = true;            
            btnMaximizar.Enabled = true;
            btnMinizar.Enabled = true;
            btnOriginal.Enabled = true;
            btnPantalla.Enabled = true;
        }
        private void deshabilitarBotonesImagenes()
        {
            btnCortar.Enabled = false;
            btnMaximizar.Enabled = false;
            btnMinizar.Enabled = false;
            btnOriginal.Enabled = false;
            btnPantalla.Enabled = false;
        }

        public string lbResultado { get; set; }

        private void indexarTXTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Indexing usuarios = new Indexing();
            usuarios.Show();  
        }

        private void generarTXTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerarTXT generar = new GenerarTXT();
            generar.Show();
        }

        private void renombrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Renombrar generar = new Renombrar();
            generar.Show();
        }

        private void actualizarPaginasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateNames generar = new UpdateNames();
            generar.Show();
        }
    }
}

