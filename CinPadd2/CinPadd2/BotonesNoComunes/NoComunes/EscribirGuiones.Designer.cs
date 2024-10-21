namespace CinPadd.NoComunes
{
    partial class EscribirGuiones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EscribirGuiones));
            this.btnAtras = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtGenero = new System.Windows.Forms.TextBox();
            this.txtSinopsis = new System.Windows.Forms.TextBox();
            this.btnSubir = new System.Windows.Forms.Button();
            this.dtgGuiones = new System.Windows.Forms.DataGridView();
            this.btnGuionesPropios = new System.Windows.Forms.Button();
            this.btnTodosGuiones = new System.Windows.Forms.Button();
            this.dtpAño = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGuiones)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAtras
            // 
            this.btnAtras.BackgroundImage = global::CinPadd2.Properties.Resources.flecha_pequeña;
            this.btnAtras.Location = new System.Drawing.Point(15, 10);
            this.btnAtras.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(67, 23);
            this.btnAtras.TabIndex = 49;
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Purple;
            this.label1.Location = new System.Drawing.Point(42, 397);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 19);
            this.label1.TabIndex = 51;
            this.label1.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Purple;
            this.label2.Location = new System.Drawing.Point(214, 397);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 19);
            this.label2.TabIndex = 52;
            this.label2.Text = "Genero:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Purple;
            this.label3.Location = new System.Drawing.Point(364, 397);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 19);
            this.label3.TabIndex = 53;
            this.label3.Text = "Año:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Purple;
            this.label4.Location = new System.Drawing.Point(158, 474);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 19);
            this.label4.TabIndex = 54;
            this.label4.Text = "Sinopsis:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(46, 434);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 22);
            this.txtNombre.TabIndex = 55;
            // 
            // txtGenero
            // 
            this.txtGenero.Location = new System.Drawing.Point(218, 434);
            this.txtGenero.Name = "txtGenero";
            this.txtGenero.Size = new System.Drawing.Size(100, 22);
            this.txtGenero.TabIndex = 56;
            // 
            // txtSinopsis
            // 
            this.txtSinopsis.Location = new System.Drawing.Point(270, 473);
            this.txtSinopsis.Multiline = true;
            this.txtSinopsis.Name = "txtSinopsis";
            this.txtSinopsis.Size = new System.Drawing.Size(298, 69);
            this.txtSinopsis.TabIndex = 58;
            // 
            // btnSubir
            // 
            this.btnSubir.Location = new System.Drawing.Point(620, 433);
            this.btnSubir.Name = "btnSubir";
            this.btnSubir.Size = new System.Drawing.Size(188, 23);
            this.btnSubir.TabIndex = 59;
            this.btnSubir.Text = "Subir guión";
            this.btnSubir.UseVisualStyleBackColor = true;
            this.btnSubir.Click += new System.EventHandler(this.btnSubir_Click);
            // 
            // dtgGuiones
            // 
            this.dtgGuiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgGuiones.Location = new System.Drawing.Point(43, 65);
            this.dtgGuiones.Name = "dtgGuiones";
            this.dtgGuiones.RowHeadersWidth = 51;
            this.dtgGuiones.RowTemplate.Height = 24;
            this.dtgGuiones.Size = new System.Drawing.Size(973, 306);
            this.dtgGuiones.TabIndex = 50;
            // 
            // btnGuionesPropios
            // 
            this.btnGuionesPropios.Location = new System.Drawing.Point(620, 470);
            this.btnGuionesPropios.Name = "btnGuionesPropios";
            this.btnGuionesPropios.Size = new System.Drawing.Size(188, 23);
            this.btnGuionesPropios.TabIndex = 60;
            this.btnGuionesPropios.Text = "Ver mis guiones";
            this.btnGuionesPropios.UseVisualStyleBackColor = true;
            this.btnGuionesPropios.Click += new System.EventHandler(this.btnGuionesPropios_Click);
            // 
            // btnTodosGuiones
            // 
            this.btnTodosGuiones.Location = new System.Drawing.Point(620, 508);
            this.btnTodosGuiones.Name = "btnTodosGuiones";
            this.btnTodosGuiones.Size = new System.Drawing.Size(188, 23);
            this.btnTodosGuiones.TabIndex = 61;
            this.btnTodosGuiones.Text = "Ver todos los guiones";
            this.btnTodosGuiones.UseVisualStyleBackColor = true;
            this.btnTodosGuiones.Click += new System.EventHandler(this.btnTodosGuiones_Click);
            // 
            // dtpAño
            // 
            this.dtpAño.Location = new System.Drawing.Point(368, 434);
            this.dtpAño.Name = "dtpAño";
            this.dtpAño.Size = new System.Drawing.Size(200, 22);
            this.dtpAño.TabIndex = 62;
            // 
            // EscribirGuiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.dtpAño);
            this.Controls.Add(this.btnTodosGuiones);
            this.Controls.Add(this.btnGuionesPropios);
            this.Controls.Add(this.btnSubir);
            this.Controls.Add(this.txtSinopsis);
            this.Controls.Add(this.txtGenero);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtgGuiones);
            this.Controls.Add(this.btnAtras);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "EscribirGuiones";
            this.Text = "Guiones";
            ((System.ComponentModel.ISupportInitialize)(this.dtgGuiones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtGenero;
        private System.Windows.Forms.TextBox txtSinopsis;
        private System.Windows.Forms.Button btnSubir;
        private System.Windows.Forms.DataGridView dtgGuiones;
        private System.Windows.Forms.Button btnGuionesPropios;
        private System.Windows.Forms.Button btnTodosGuiones;
        private System.Windows.Forms.DateTimePicker dtpAño;
    }
}