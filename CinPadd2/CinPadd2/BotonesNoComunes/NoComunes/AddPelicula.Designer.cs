namespace CinPadd2.BotonesNoComunes.NoComunes
{
    partial class AddPelicula
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPelicula));
            this.btnAtras = new System.Windows.Forms.Button();
            this.dtgPelis = new System.Windows.Forms.DataGridView();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numActores = new System.Windows.Forms.NumericUpDown();
            this.cmbGuion = new System.Windows.Forms.ComboBox();
            this.cmbGuionista = new System.Windows.Forms.ComboBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnPublicar = new System.Windows.Forms.Button();
            this.txtGenero = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPelis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numActores)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAtras
            // 
            this.btnAtras.BackgroundImage = global::CinPadd2.Properties.Resources.flecha_pequeña;
            this.btnAtras.Location = new System.Drawing.Point(12, 11);
            this.btnAtras.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(67, 23);
            this.btnAtras.TabIndex = 51;
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // dtgPelis
            // 
            this.dtgPelis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPelis.Location = new System.Drawing.Point(133, 11);
            this.dtgPelis.Name = "dtgPelis";
            this.dtgPelis.RowHeadersWidth = 51;
            this.dtgPelis.RowTemplate.Height = 24;
            this.dtgPelis.Size = new System.Drawing.Size(694, 292);
            this.dtgPelis.TabIndex = 52;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(133, 359);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(121, 60);
            this.txtDescripcion.TabIndex = 63;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(133, 324);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(121, 22);
            this.txtNombre.TabIndex = 62;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 365);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 61;
            this.label2.Text = "Descripción:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 324);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 60;
            this.label1.Text = "Nombre: ";
            // 
            // numActores
            // 
            this.numActores.Location = new System.Drawing.Point(367, 359);
            this.numActores.Name = "numActores";
            this.numActores.Size = new System.Drawing.Size(138, 22);
            this.numActores.TabIndex = 64;
            // 
            // cmbGuion
            // 
            this.cmbGuion.FormattingEnabled = true;
            this.cmbGuion.Location = new System.Drawing.Point(367, 395);
            this.cmbGuion.Name = "cmbGuion";
            this.cmbGuion.Size = new System.Drawing.Size(138, 24);
            this.cmbGuion.TabIndex = 65;
            // 
            // cmbGuionista
            // 
            this.cmbGuionista.FormattingEnabled = true;
            this.cmbGuionista.Location = new System.Drawing.Point(367, 324);
            this.cmbGuionista.Name = "cmbGuionista";
            this.cmbGuionista.Size = new System.Drawing.Size(138, 24);
            this.cmbGuionista.TabIndex = 66;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(132, 471);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(200, 22);
            this.dtpFecha.TabIndex = 67;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(287, 330);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 68;
            this.label3.Text = "Guionista: ";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(287, 361);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(74, 16);
            this.label.TabIndex = 69;
            this.label.Text = "Nº Actores:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(287, 398);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 16);
            this.label5.TabIndex = 70;
            this.label5.Text = "Guion:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(82, 476);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 16);
            this.label6.TabIndex = 71;
            this.label6.Text = "Año:";
            // 
            // btnPublicar
            // 
            this.btnPublicar.Location = new System.Drawing.Point(367, 434);
            this.btnPublicar.Name = "btnPublicar";
            this.btnPublicar.Size = new System.Drawing.Size(138, 23);
            this.btnPublicar.TabIndex = 72;
            this.btnPublicar.Text = "Publicar";
            this.btnPublicar.UseVisualStyleBackColor = true;
            this.btnPublicar.Click += new System.EventHandler(this.btnPublicar_Click);
            // 
            // txtGenero
            // 
            this.txtGenero.Location = new System.Drawing.Point(133, 434);
            this.txtGenero.Name = "txtGenero";
            this.txtGenero.Size = new System.Drawing.Size(121, 22);
            this.txtGenero.TabIndex = 74;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 434);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 16);
            this.label4.TabIndex = 73;
            this.label4.Text = "Genero:";
            // 
            // AddPelicula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(897, 522);
            this.Controls.Add(this.txtGenero);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnPublicar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.cmbGuionista);
            this.Controls.Add(this.cmbGuion);
            this.Controls.Add(this.numActores);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtgPelis);
            this.Controls.Add(this.btnAtras);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddPelicula";
            this.Text = "AddPelicula";
            ((System.ComponentModel.ISupportInitialize)(this.dtgPelis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numActores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.DataGridView dtgPelis;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numActores;
        private System.Windows.Forms.ComboBox cmbGuion;
        private System.Windows.Forms.ComboBox cmbGuionista;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnPublicar;
        private System.Windows.Forms.TextBox txtGenero;
        private System.Windows.Forms.Label label4;
    }
}