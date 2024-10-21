namespace CinPadd.NoComunes
{
    partial class Criticas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Criticas));
            this.dtgCriticas = new System.Windows.Forms.DataGridView();
            this.txtCritica = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPublicar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnAtras = new System.Windows.Forms.Button();
            this.cmbPelis = new System.Windows.Forms.ComboBox();
            this.numPuntuacion = new System.Windows.Forms.NumericUpDown();
            this.btnCriticasPropias = new System.Windows.Forms.Button();
            this.btnTodas = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCriticas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPuntuacion)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgCriticas
            // 
            this.dtgCriticas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCriticas.Location = new System.Drawing.Point(37, 37);
            this.dtgCriticas.Margin = new System.Windows.Forms.Padding(4);
            this.dtgCriticas.Name = "dtgCriticas";
            this.dtgCriticas.RowHeadersWidth = 51;
            this.dtgCriticas.Size = new System.Drawing.Size(983, 299);
            this.dtgCriticas.TabIndex = 0;
            // 
            // txtCritica
            // 
            this.txtCritica.Location = new System.Drawing.Point(37, 442);
            this.txtCritica.Margin = new System.Windows.Forms.Padding(4);
            this.txtCritica.Multiline = true;
            this.txtCritica.Name = "txtCritica";
            this.txtCritica.Size = new System.Drawing.Size(507, 96);
            this.txtCritica.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(32, 351);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Puntuación: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(33, 418);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Comentario:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(212, 359);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Película:";
            // 
            // btnPublicar
            // 
            this.btnPublicar.Location = new System.Drawing.Point(608, 458);
            this.btnPublicar.Margin = new System.Windows.Forms.Padding(4);
            this.btnPublicar.Name = "btnPublicar";
            this.btnPublicar.Size = new System.Drawing.Size(220, 28);
            this.btnPublicar.TabIndex = 6;
            this.btnPublicar.Text = "Publicar Crítica";
            this.btnPublicar.UseVisualStyleBackColor = true;
            this.btnPublicar.Click += new System.EventHandler(this.btnPublicar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(608, 494);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(220, 28);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.Text = "Buscar críticas de película";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnAtras
            // 
            this.btnAtras.BackgroundImage = global::CinPadd2.Properties.Resources.flecha_pequeña;
            this.btnAtras.Location = new System.Drawing.Point(15, 7);
            this.btnAtras.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(67, 23);
            this.btnAtras.TabIndex = 49;
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // cmbPelis
            // 
            this.cmbPelis.FormattingEnabled = true;
            this.cmbPelis.Location = new System.Drawing.Point(316, 359);
            this.cmbPelis.Name = "cmbPelis";
            this.cmbPelis.Size = new System.Drawing.Size(121, 24);
            this.cmbPelis.TabIndex = 50;
            // 
            // numPuntuacion
            // 
            this.numPuntuacion.Location = new System.Drawing.Point(37, 374);
            this.numPuntuacion.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numPuntuacion.Name = "numPuntuacion";
            this.numPuntuacion.Size = new System.Drawing.Size(120, 22);
            this.numPuntuacion.TabIndex = 51;
            // 
            // btnCriticasPropias
            // 
            this.btnCriticasPropias.Location = new System.Drawing.Point(608, 386);
            this.btnCriticasPropias.Margin = new System.Windows.Forms.Padding(4);
            this.btnCriticasPropias.Name = "btnCriticasPropias";
            this.btnCriticasPropias.Size = new System.Drawing.Size(220, 28);
            this.btnCriticasPropias.TabIndex = 52;
            this.btnCriticasPropias.Text = "Mostrar mis críticas";
            this.btnCriticasPropias.UseVisualStyleBackColor = true;
            this.btnCriticasPropias.Click += new System.EventHandler(this.btnCriticasPropias_Click);
            // 
            // btnTodas
            // 
            this.btnTodas.Location = new System.Drawing.Point(608, 422);
            this.btnTodas.Margin = new System.Windows.Forms.Padding(4);
            this.btnTodas.Name = "btnTodas";
            this.btnTodas.Size = new System.Drawing.Size(220, 28);
            this.btnTodas.TabIndex = 53;
            this.btnTodas.Text = "Mostrar todas las críticas";
            this.btnTodas.UseVisualStyleBackColor = true;
            this.btnTodas.Click += new System.EventHandler(this.btnTodas_Click);
            // 
            // Criticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.btnTodas);
            this.Controls.Add(this.btnCriticasPropias);
            this.Controls.Add(this.numPuntuacion);
            this.Controls.Add(this.cmbPelis);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnPublicar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCritica);
            this.Controls.Add(this.dtgCriticas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Criticas";
            this.Text = "Críticas";
            ((System.ComponentModel.ISupportInitialize)(this.dtgCriticas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPuntuacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgCriticas;
        private System.Windows.Forms.TextBox txtCritica;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPublicar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.ComboBox cmbPelis;
        private System.Windows.Forms.NumericUpDown numPuntuacion;
        private System.Windows.Forms.Button btnCriticasPropias;
        private System.Windows.Forms.Button btnTodas;
    }
}