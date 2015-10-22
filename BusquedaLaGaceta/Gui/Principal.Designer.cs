namespace BusquedaLaGaceta
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.grp1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFechaHasta = new System.Windows.Forms.TextBox();
            this.txtFechaDesde = new System.Windows.Forms.TextBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.lresultado = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblPalabrasBuscar = new System.Windows.Forms.Label();
            this.chkRango = new System.Windows.Forms.CheckBox();
            this.chkDiario = new System.Windows.Forms.CheckBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.perfilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnPantalla = new System.Windows.Forms.Button();
            this.btnOriginal = new System.Windows.Forms.Button();
            this.btnMinizar = new System.Windows.Forms.Button();
            this.btnMaximizar = new System.Windows.Forms.Button();
            this.btnCortar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.grp1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("flowLayoutPanel1.BackgroundImage")));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 26);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1137, 43);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // grp1
            // 
            this.grp1.Controls.Add(this.label2);
            this.grp1.Controls.Add(this.label1);
            this.grp1.Controls.Add(this.txtFechaHasta);
            this.grp1.Controls.Add(this.txtFechaDesde);
            this.grp1.Controls.Add(this.btnImprimir);
            this.grp1.Controls.Add(this.lresultado);
            this.grp1.Controls.Add(this.btnLimpiar);
            this.grp1.Controls.Add(this.btnBuscar);
            this.grp1.Controls.Add(this.txtBuscar);
            this.grp1.Controls.Add(this.lblPalabrasBuscar);
            this.grp1.Controls.Add(this.chkRango);
            this.grp1.Controls.Add(this.chkDiario);
            this.grp1.Controls.Add(this.radioButton1);
            this.grp1.Location = new System.Drawing.Point(0, 92);
            this.grp1.Name = "grp1";
            this.grp1.Size = new System.Drawing.Size(187, 279);
            this.grp1.TabIndex = 1;
            this.grp1.TabStop = false;
            this.grp1.Text = "Busqueda por Fecha";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Fecha Hasta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Fecha Desde:";
            // 
            // txtFechaHasta
            // 
            this.txtFechaHasta.Location = new System.Drawing.Point(16, 121);
            this.txtFechaHasta.Name = "txtFechaHasta";
            this.txtFechaHasta.Size = new System.Drawing.Size(150, 20);
            this.txtFechaHasta.TabIndex = 13;
            // 
            // txtFechaDesde
            // 
            this.txtFechaDesde.Location = new System.Drawing.Point(16, 80);
            this.txtFechaDesde.Name = "txtFechaDesde";
            this.txtFechaDesde.Size = new System.Drawing.Size(150, 20);
            this.txtFechaDesde.TabIndex = 12;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(16, 250);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(159, 23);
            this.btnImprimir.TabIndex = 11;
            this.btnImprimir.Text = "Cancelar Busqueda";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // lresultado
            // 
            this.lresultado.AutoSize = true;
            this.lresultado.Location = new System.Drawing.Point(16, 260);
            this.lresultado.Name = "lresultado";
            this.lresultado.Size = new System.Drawing.Size(0, 13);
            this.lresultado.TabIndex = 10;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(94, 201);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(81, 23);
            this.btnLimpiar.TabIndex = 9;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.Location = new System.Drawing.Point(16, 201);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(72, 23);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(16, 161);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(150, 20);
            this.txtBuscar.TabIndex = 6;
            // 
            // lblPalabrasBuscar
            // 
            this.lblPalabrasBuscar.AutoSize = true;
            this.lblPalabrasBuscar.Location = new System.Drawing.Point(13, 144);
            this.lblPalabrasBuscar.Name = "lblPalabrasBuscar";
            this.lblPalabrasBuscar.Size = new System.Drawing.Size(92, 13);
            this.lblPalabrasBuscar.TabIndex = 5;
            this.lblPalabrasBuscar.Text = "Palabras a buscar";
            this.lblPalabrasBuscar.Click += new System.EventHandler(this.label1_Click);
            // 
            // chkRango
            // 
            this.chkRango.AutoSize = true;
            this.chkRango.Checked = true;
            this.chkRango.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRango.Location = new System.Drawing.Point(100, 44);
            this.chkRango.Name = "chkRango";
            this.chkRango.Size = new System.Drawing.Size(58, 17);
            this.chkRango.TabIndex = 2;
            this.chkRango.Text = "Rango";
            this.chkRango.UseVisualStyleBackColor = true;
            this.chkRango.CheckedChanged += new System.EventHandler(this.chkRango_CheckedChanged);
            // 
            // chkDiario
            // 
            this.chkDiario.AutoSize = true;
            this.chkDiario.Location = new System.Drawing.Point(13, 44);
            this.chkDiario.Name = "chkDiario";
            this.chkDiario.Size = new System.Drawing.Size(53, 17);
            this.chkDiario.TabIndex = 1;
            this.chkDiario.Text = "Diario";
            this.chkDiario.UseVisualStyleBackColor = true;
            this.chkDiario.CheckedChanged += new System.EventHandler(this.chkDiario_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(13, 20);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(120, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "busqueda por fecha";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(7646, 11075);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(13, 377);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(174, 138);
            this.treeView1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(207, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(917, 566);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.menuStrip1);
            this.panel2.Location = new System.Drawing.Point(0, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(831, 32);
            this.panel2.TabIndex = 10;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(831, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosToolStripMenuItem1,
            this.perfilesToolStripMenuItem});
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.usuariosToolStripMenuItem.Text = "Parametricas";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // usuariosToolStripMenuItem1
            // 
            this.usuariosToolStripMenuItem1.Name = "usuariosToolStripMenuItem1";
            this.usuariosToolStripMenuItem1.Size = new System.Drawing.Size(119, 22);
            this.usuariosToolStripMenuItem1.Text = "Usuarios";
            this.usuariosToolStripMenuItem1.Click += new System.EventHandler(this.usuariosToolStripMenuItem1_Click);
            // 
            // perfilesToolStripMenuItem
            // 
            this.perfilesToolStripMenuItem.Name = "perfilesToolStripMenuItem";
            this.perfilesToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.perfilesToolStripMenuItem.Text = "Perfiles";
            this.perfilesToolStripMenuItem.Click += new System.EventHandler(this.perfilesToolStripMenuItem_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // btnPantalla
            // 
            this.btnPantalla.Enabled = false;
            this.btnPantalla.Location = new System.Drawing.Point(112, 615);
            this.btnPantalla.Name = "btnPantalla";
            this.btnPantalla.Size = new System.Drawing.Size(75, 23);
            this.btnPantalla.TabIndex = 14;
            this.btnPantalla.Text = "Pantalla";
            this.btnPantalla.UseVisualStyleBackColor = true;
            this.btnPantalla.Click += new System.EventHandler(this.button6_Click_1);
            // 
            // btnOriginal
            // 
            this.btnOriginal.Enabled = false;
            this.btnOriginal.Location = new System.Drawing.Point(112, 585);
            this.btnOriginal.Name = "btnOriginal";
            this.btnOriginal.Size = new System.Drawing.Size(75, 23);
            this.btnOriginal.TabIndex = 13;
            this.btnOriginal.Text = "Original";
            this.btnOriginal.UseVisualStyleBackColor = true;
            this.btnOriginal.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnMinizar
            // 
            this.btnMinizar.Enabled = false;
            this.btnMinizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMinizar.Image")));
            this.btnMinizar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMinizar.Location = new System.Drawing.Point(112, 556);
            this.btnMinizar.Name = "btnMinizar";
            this.btnMinizar.Size = new System.Drawing.Size(75, 23);
            this.btnMinizar.TabIndex = 12;
            this.btnMinizar.Text = "Minimizar";
            this.btnMinizar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMinizar.UseVisualStyleBackColor = true;
            this.btnMinizar.Click += new System.EventHandler(this.btnMinizar_Click);
            // 
            // btnMaximizar
            // 
            this.btnMaximizar.Enabled = false;
            this.btnMaximizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMaximizar.Image")));
            this.btnMaximizar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMaximizar.Location = new System.Drawing.Point(112, 527);
            this.btnMaximizar.Name = "btnMaximizar";
            this.btnMaximizar.Size = new System.Drawing.Size(75, 23);
            this.btnMaximizar.TabIndex = 11;
            this.btnMaximizar.Text = "Maximizar";
            this.btnMaximizar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMaximizar.UseVisualStyleBackColor = true;
            this.btnMaximizar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCortar
            // 
            this.btnCortar.Enabled = false;
            this.btnCortar.Location = new System.Drawing.Point(12, 585);
            this.btnCortar.Name = "btnCortar";
            this.btnCortar.Size = new System.Drawing.Size(75, 23);
            this.btnCortar.TabIndex = 17;
            this.btnCortar.Text = "Cortar";
            this.btnCortar.UseVisualStyleBackColor = true;
            this.btnCortar.Click += new System.EventHandler(this.btnCortar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Enabled = false;
            this.btnGuardar.Location = new System.Drawing.Point(13, 614);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 18;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(16, 645);
            this.progressBar1.Maximum = 20;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(171, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 19;
            this.progressBar1.Value = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1136, 667);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCortar);
            this.Controls.Add(this.btnPantalla);
            this.Controls.Add(this.btnOriginal);
            this.Controls.Add(this.btnMinizar);
            this.Controls.Add(this.btnMaximizar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.grp1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pantalla Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grp1.ResumeLayout(false);
            this.grp1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox grp1;
        private System.Windows.Forms.Label lresultado;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblPalabrasBuscar;
        private System.Windows.Forms.CheckBox chkRango;
        private System.Windows.Forms.CheckBox chkDiario;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem perfilesToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnPantalla;
        private System.Windows.Forms.Button btnOriginal;
        private System.Windows.Forms.Button btnMinizar;
        private System.Windows.Forms.Button btnMaximizar;
        private System.Windows.Forms.Button btnCortar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFechaHasta;
        private System.Windows.Forms.TextBox txtFechaDesde;
    }
}

