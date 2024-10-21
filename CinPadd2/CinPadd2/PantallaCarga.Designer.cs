namespace CinPadd2
{
    partial class PantallaCarga
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PantallaCarga));
            this.pgbTiempo = new System.Windows.Forms.ProgressBar();
            this.pbFotos = new System.Windows.Forms.PictureBox();
            this.imlFotos = new System.Windows.Forms.ImageList(this.components);
            this.CinPadd = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbFotos)).BeginInit();
            this.SuspendLayout();
            // 
            // pgbTiempo
            // 
            this.pgbTiempo.Location = new System.Drawing.Point(55, 337);
            this.pgbTiempo.Name = "pgbTiempo";
            this.pgbTiempo.Size = new System.Drawing.Size(662, 23);
            this.pgbTiempo.TabIndex = 0;
            // 
            // pbFotos
            // 
            this.pbFotos.Location = new System.Drawing.Point(55, 42);
            this.pbFotos.Name = "pbFotos";
            this.pbFotos.Size = new System.Drawing.Size(662, 274);
            this.pbFotos.TabIndex = 1;
            this.pbFotos.TabStop = false;
            // 
            // imlFotos
            // 
            this.imlFotos.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlFotos.ImageStream")));
            this.imlFotos.TransparentColor = System.Drawing.Color.Transparent;
            this.imlFotos.Images.SetKeyName(0, "silla.jpg");
            this.imlFotos.Images.SetKeyName(1, "cintas.jpg");
            this.imlFotos.Images.SetKeyName(2, "claqueta.jpg");
            this.imlFotos.Images.SetKeyName(3, "logo.jpg.png");
            // 
            // CinPadd
            // 
            this.CinPadd.AutoSize = true;
            this.CinPadd.Font = new System.Drawing.Font("Lucida Handwriting", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CinPadd.ForeColor = System.Drawing.Color.Indigo;
            this.CinPadd.Location = new System.Drawing.Point(352, 74);
            this.CinPadd.Name = "CinPadd";
            this.CinPadd.Size = new System.Drawing.Size(339, 78);
            this.CinPadd.TabIndex = 3;
            this.CinPadd.Text = "CinPadd";
            // 
            // PantallaCarga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CinPadd);
            this.Controls.Add(this.pbFotos);
            this.Controls.Add(this.pgbTiempo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PantallaCarga";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.PantallaCarga_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbFotos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pgbTiempo;
        private System.Windows.Forms.PictureBox pbFotos;
        private System.Windows.Forms.ImageList imlFotos;
        private System.Windows.Forms.Label CinPadd;
    }
}

