namespace BusquedaLaGaceta.Gui
{
    partial class Perfiles
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
            this.btnAlta = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tableUserBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.aIDataSet = new BusquedaLaGaceta.AIDataSet();
            this.table_UserTableAdapter = new BusquedaLaGaceta.AIDataSetTableAdapters.Table_UserTableAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.aIDataSet1 = new BusquedaLaGaceta.AIDataSet1();
            this.tablePerfilesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.table_PerfilesTableAdapter = new BusquedaLaGaceta.AIDataSet1TableAdapters.Table_PerfilesTableAdapter();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tableUserBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aIDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aIDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePerfilesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAlta
            // 
            this.btnAlta.Location = new System.Drawing.Point(27, 49);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(75, 23);
            this.btnAlta.TabIndex = 1;
            this.btnAlta.Text = "Alta";
            this.btnAlta.UseVisualStyleBackColor = true;
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(154, 49);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Baja";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(322, 49);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Modificacion";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // tableUserBindingSource
            // 
            this.tableUserBindingSource.DataMember = "Table_User";
            this.tableUserBindingSource.DataSource = this.aIDataSet;
            // 
            // aIDataSet
            // 
            this.aIDataSet.DataSetName = "AIDataSet";
            this.aIDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // table_UserTableAdapter
            // 
            this.table_UserTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tablePerfilesBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(27, 97);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 4;
            // 
            // aIDataSet1
            // 
            this.aIDataSet1.DataSetName = "AIDataSet1";
            this.aIDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tablePerfilesBindingSource
            // 
            this.tablePerfilesBindingSource.DataMember = "Table_Perfiles";
            this.tablePerfilesBindingSource.DataSource = this.aIDataSet1;
            // 
            // table_PerfilesTableAdapter
            // 
            this.table_PerfilesTableAdapter.ClearBeforeFill = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            // 
            // Usuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 280);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnAlta);
            this.Name = "Usuarios";
            this.Text = "Usuarios";
            this.Load += new System.EventHandler(this.Usuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tableUserBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aIDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aIDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePerfilesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAlta;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private AIDataSet aIDataSet;
        private System.Windows.Forms.BindingSource tableUserBindingSource;
        private AIDataSetTableAdapters.Table_UserTableAdapter table_UserTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private AIDataSet1 aIDataSet1;
        private System.Windows.Forms.BindingSource tablePerfilesBindingSource;
        private AIDataSet1TableAdapters.Table_PerfilesTableAdapter table_PerfilesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;

    }
}