namespace CinPadd2.BotonesNoComunes.NoComunes
{
    partial class AddCasting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCasting));
            this.dtgCastings = new System.Windows.Forms.DataGridView();
            this.btnAtras = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtLugar = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.chbSinPeli = new System.Windows.Forms.CheckBox();
            this.chbConPeli = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.btnPublicar = new System.Windows.Forms.Button();
            this.cmbPelis = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCastings)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgCastings
            // 
            this.dtgCastings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCastings.Location = new System.Drawing.Point(109, 12);
            this.dtgCastings.Name = "dtgCastings";
            this.dtgCastings.RowHeadersWidth = 51;
            this.dtgCastings.RowTemplate.Height = 24;
            this.dtgCastings.Size = new System.Drawing.Size(679, 299);
            this.dtgCastings.TabIndex = 0;
            // 
            // btnAtras
            // 
            this.btnAtras.BackgroundImage = global::CinPadd2.Properties.Resources.flecha_pequeña;
            this.btnAtras.Location = new System.Drawing.Point(12, 11);
            this.btnAtras.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(67, 23);
            this.btnAtras.TabIndex = 50;
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 335);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 51;
            this.label1.Text = "Nombre: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(109, 376);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 52;
            this.label2.Text = "Descripción:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(109, 449);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 16);
            this.label4.TabIndex = 54;
            this.label4.Text = "Ubicación:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(368, 341);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(212, 16);
            this.label5.TabIndex = 55;
            this.label5.Text = "¿Está enlazado a alguna película?";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(214, 335);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(121, 22);
            this.txtNombre.TabIndex = 56;
            // 
            // txtLugar
            // 
            this.txtLugar.Location = new System.Drawing.Point(214, 449);
            this.txtLugar.Name = "txtLugar";
            this.txtLugar.Size = new System.Drawing.Size(121, 22);
            this.txtLugar.TabIndex = 57;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(214, 370);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(121, 60);
            this.txtDescripcion.TabIndex = 59;
            // 
            // chbSinPeli
            // 
            this.chbSinPeli.AutoSize = true;
            this.chbSinPeli.Location = new System.Drawing.Point(424, 376);
            this.chbSinPeli.Name = "chbSinPeli";
            this.chbSinPeli.Size = new System.Drawing.Size(47, 20);
            this.chbSinPeli.TabIndex = 62;
            this.chbSinPeli.Text = "No";
            this.chbSinPeli.UseVisualStyleBackColor = true;
            // 
            // chbConPeli
            // 
            this.chbConPeli.AutoSize = true;
            this.chbConPeli.Location = new System.Drawing.Point(375, 376);
            this.chbConPeli.Name = "chbConPeli";
            this.chbConPeli.Size = new System.Drawing.Size(41, 20);
            this.chbConPeli.TabIndex = 61;
            this.chbConPeli.Text = "Si";
            this.chbConPeli.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(368, 414);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 16);
            this.label6.TabIndex = 63;
            this.label6.Text = "¿Cual?";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(619, 341);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 16);
            this.label7.TabIndex = 64;
            this.label7.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(622, 376);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(200, 22);
            this.dtpFecha.TabIndex = 65;
            // 
            // btnPublicar
            // 
            this.btnPublicar.Location = new System.Drawing.Point(622, 434);
            this.btnPublicar.Name = "btnPublicar";
            this.btnPublicar.Size = new System.Drawing.Size(145, 23);
            this.btnPublicar.TabIndex = 66;
            this.btnPublicar.Text = "Publicar";
            this.btnPublicar.UseVisualStyleBackColor = true;
            this.btnPublicar.Click += new System.EventHandler(this.btnPublicar_Click);
            // 
            // cmbPelis
            // 
            this.cmbPelis.FormattingEnabled = true;
            this.cmbPelis.Location = new System.Drawing.Point(371, 440);
            this.cmbPelis.Name = "cmbPelis";
            this.cmbPelis.Size = new System.Drawing.Size(121, 24);
            this.cmbPelis.TabIndex = 68;
            // 
            // AddCasting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(877, 503);
            this.Controls.Add(this.cmbPelis);
            this.Controls.Add(this.btnPublicar);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chbSinPeli);
            this.Controls.Add(this.chbConPeli);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtLugar);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.dtgCastings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddCasting";
            this.Text = "AddCasting";
            ((System.ComponentModel.ISupportInitialize)(this.dtgCastings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgCastings;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtLugar;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.CheckBox chbSinPeli;
        private System.Windows.Forms.CheckBox chbConPeli;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button btnPublicar;
        private System.Windows.Forms.ComboBox cmbPelis;
    }
}