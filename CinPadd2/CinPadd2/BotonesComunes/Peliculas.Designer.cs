namespace CinPadd2.BotonesComunes
{
    partial class Peliculas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Peliculas));
            this.dtpAño = new System.Windows.Forms.DateTimePicker();
            this.lblGenero = new System.Windows.Forms.Label();
            this.lblGuion = new System.Windows.Forms.Label();
            this.lblDirector = new System.Windows.Forms.Label();
            this.lblActores = new System.Windows.Forms.Label();
            this.lblDescripción = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnAtras = new System.Windows.Forms.Button();
            this.btnSiguientePeli = new System.Windows.Forms.Button();
            this.btnAnteriorPeli = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtpAño
            // 
            this.dtpAño.Location = new System.Drawing.Point(134, 415);
            this.dtpAño.Margin = new System.Windows.Forms.Padding(4);
            this.dtpAño.Name = "dtpAño";
            this.dtpAño.Size = new System.Drawing.Size(265, 22);
            this.dtpAño.TabIndex = 65;
            // 
            // lblGenero
            // 
            this.lblGenero.AutoSize = true;
            this.lblGenero.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.lblGenero.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblGenero.Location = new System.Drawing.Point(138, 368);
            this.lblGenero.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Size = new System.Drawing.Size(95, 27);
            this.lblGenero.TabIndex = 64;
            this.lblGenero.Text = "Genero: ";
            // 
            // lblGuion
            // 
            this.lblGuion.AutoSize = true;
            this.lblGuion.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.lblGuion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblGuion.Location = new System.Drawing.Point(134, 329);
            this.lblGuion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGuion.Name = "lblGuion";
            this.lblGuion.Size = new System.Drawing.Size(110, 27);
            this.lblGuion.TabIndex = 63;
            this.lblGuion.Text = "Guionista:";
            // 
            // lblDirector
            // 
            this.lblDirector.AutoSize = true;
            this.lblDirector.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.lblDirector.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDirector.Location = new System.Drawing.Point(134, 289);
            this.lblDirector.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDirector.Name = "lblDirector";
            this.lblDirector.Size = new System.Drawing.Size(104, 27);
            this.lblDirector.TabIndex = 62;
            this.lblDirector.Text = "Director: ";
            // 
            // lblActores
            // 
            this.lblActores.AutoSize = true;
            this.lblActores.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.lblActores.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblActores.Location = new System.Drawing.Point(134, 254);
            this.lblActores.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblActores.Name = "lblActores";
            this.lblActores.Size = new System.Drawing.Size(99, 27);
            this.lblActores.TabIndex = 61;
            this.lblActores.Text = "Actores: ";
            // 
            // lblDescripción
            // 
            this.lblDescripción.AutoSize = true;
            this.lblDescripción.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripción.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDescripción.Location = new System.Drawing.Point(128, 158);
            this.lblDescripción.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescripción.Name = "lblDescripción";
            this.lblDescripción.Size = new System.Drawing.Size(139, 27);
            this.lblDescripción.TabIndex = 60;
            this.lblDescripción.Text = "Descripción: ";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Times New Roman", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitulo.Location = new System.Drawing.Point(43, 68);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(215, 67);
            this.lblTitulo.TabIndex = 59;
            this.lblTitulo.Text = "Título: ";
            // 
            // btnAtras
            // 
            this.btnAtras.BackgroundImage = global::CinPadd2.Properties.Resources.flecha_pequeña;
            this.btnAtras.Location = new System.Drawing.Point(12, 11);
            this.btnAtras.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(67, 23);
            this.btnAtras.TabIndex = 57;
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // btnSiguientePeli
            // 
            this.btnSiguientePeli.Location = new System.Drawing.Point(739, 480);
            this.btnSiguientePeli.Name = "btnSiguientePeli";
            this.btnSiguientePeli.Size = new System.Drawing.Size(169, 23);
            this.btnSiguientePeli.TabIndex = 67;
            this.btnSiguientePeli.Text = "Película Siguiente";
            this.btnSiguientePeli.UseVisualStyleBackColor = true;
            this.btnSiguientePeli.Click += new System.EventHandler(this.btnSiguientePeli_Click);
            // 
            // btnAnteriorPeli
            // 
            this.btnAnteriorPeli.Location = new System.Drawing.Point(93, 480);
            this.btnAnteriorPeli.Name = "btnAnteriorPeli";
            this.btnAnteriorPeli.Size = new System.Drawing.Size(125, 23);
            this.btnAnteriorPeli.TabIndex = 66;
            this.btnAnteriorPeli.Text = "Película Anterior";
            this.btnAnteriorPeli.UseVisualStyleBackColor = true;
            this.btnAnteriorPeli.Click += new System.EventHandler(this.btnAnteriorPeli_Click);
            // 
            // Películas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(985, 543);
            this.Controls.Add(this.btnSiguientePeli);
            this.Controls.Add(this.btnAnteriorPeli);
            this.Controls.Add(this.dtpAño);
            this.Controls.Add(this.lblGenero);
            this.Controls.Add(this.lblGuion);
            this.Controls.Add(this.lblDirector);
            this.Controls.Add(this.lblActores);
            this.Controls.Add(this.lblDescripción);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnAtras);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Películas";
            this.Text = "Películas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpAño;
        private System.Windows.Forms.Label lblGenero;
        private System.Windows.Forms.Label lblGuion;
        private System.Windows.Forms.Label lblDirector;
        private System.Windows.Forms.Label lblActores;
        private System.Windows.Forms.Label lblDescripción;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Button btnSiguientePeli;
        private System.Windows.Forms.Button btnAnteriorPeli;
    }
}